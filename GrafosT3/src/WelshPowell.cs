using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class WelshPowell
    {
        private int numVertices;
        private List<int>[] adjacencyList;
        //private Graph graph;

        public WelshPowell(int vertices)
        {
            numVertices = vertices;
            adjacencyList = new List<int>[numVertices];
            //this.graph = graph; 
            for (int i = 0; i < numVertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }

        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
            adjacencyList[w].Add(v);
        }

        public void WelshPowellColoring()
        {
            int[] colors = new int[numVertices];
            Array.Fill(colors, -1);

            // Ordena os vértices em ordem decrescente de grau
            List<int> sortedVertices = new List<int>();
            for (int i = 0; i < numVertices; i++)
            {
                sortedVertices.Add(i);
            }
            sortedVertices.Sort((v1, v2) => adjacencyList[v2].Count.CompareTo(adjacencyList[v1].Count));

            // Percorre os vértices ordenados e atribui as cores
            foreach (int vertex in sortedVertices)
            {
                if (colors[vertex] == -1)
                {
                    // Atribui uma nova cor
                    int color = 1;
                    colors[vertex] = color;

                    // Percorre os vértices não coloridos adjacentes e os marca com a cor atribuída
                    foreach (int adjVertex in adjacencyList[vertex])
                    {
                        if (colors[adjVertex] == -1)
                        {
                            colors[adjVertex] = color;
                        }
                    }

                    // Incrementa a cor para o próximo vértice
                    color++;
                }
            }

            // Imprime a cor atribuída a cada vértice
            for (int i = 0; i < numVertices; i++)
            {
                Console.WriteLine("Vertex {0}: Color {1}", i, colors[i]);
            }
        }

        public void TestaWelshPowell()
        {
            WelshPowell graph = new WelshPowell(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            graph.WelshPowellColoring();
        }


    }
}
