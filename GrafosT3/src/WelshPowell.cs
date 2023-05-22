using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class WelshPowell: GraphList
    {
        public List<int> used = new();
        public int total = 0;


        public void WelshPowellColoring()
        {
            int[] colors = new int[Nodes];
            Array.Fill(colors, -1);

            // Ordena os vértices em ordem decrescente de grau
            List<int> sortedVertices = new List<int>();
            for (int i = 0; i < Nodes; i++)
            {
                sortedVertices.Add(i);
            }
            sortedVertices.Sort((v1, v2) => this.List[v2].Count.CompareTo(this.List[v1].Count));

            int color = 1; // A tribui a cor 1 inicialmente

            // Percorre os vértices ordenados e atribui as cores
            foreach (int vertex in sortedVertices)
            {
                if (colors[vertex] == -1)
                {
                    // Atribui uma nova cor



                    colors[vertex] = FindAvailableColor(colors, vertex);

                    if(!this.used.Contains(colors[vertex]))
                    {
                        this.used.Add(colors[vertex]);
                        this.total++;
                    }


                    // Percorre os vértices não coloridos adjacentes e os marca com a cor atribuída
                    foreach (Edge adjVertex in this.List[vertex])
                    {
                        if (colors[adjVertex.ToNode] == -1)
                        {
                            colors[adjVertex.ToNode] = colors[vertex];
                        }
                    }

                    // Incrementa a cor para o próximo vértice
                    color++;
                }
            }

            // Imprime a cor atribuída a cada vértice
            for (int i = 0; i < Nodes; i++)
            {
                Console.WriteLine("Vertex {0}: Color {1}", i, colors[i]);
            }
        }

        private int FindAvailableColor(int[] colors, int vertex)
        {
            int availableColor = 1;

            // Verifica as cores atribuídas aos vértices adjacentes
            foreach (Edge adjVertex in this.List[vertex])
            {
                if (colors[adjVertex.ToNode] == availableColor)
                {
                    // Incrementa a cor disponível caso já esteja sendo usada por um vértice adjacente
                    availableColor++;
                }
            }

            return availableColor;
        }

    }
}