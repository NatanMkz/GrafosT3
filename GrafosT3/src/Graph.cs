using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public abstract class Graph
    {
        public List<string> NodeNames;

        public Graph(
            bool directed = false,
            bool weighted = false,
            int nodes = 0,
            int edges = 0
        )
        {
            Directed = directed;
            Weighted = weighted;
            Nodes = nodes;
            Edges = edges;
        }

        public bool Directed { get; protected set; }

        public bool Weighted { get; protected set; }

        public int Nodes { get; protected set; }

        public int Edges { get; protected set; }

        public abstract bool NodeInsert(string name);

        public abstract bool NodeDelete(string name);

        public abstract int NodeIndex(string name);

        public abstract string NodeLabel(int node);

        public abstract List<int> GetNeighbors(int node);

        public abstract bool EdgeInsert(int from, int to, double weight = 1);

        public abstract bool EdgeDelete(int from, int to);

        public abstract bool EdgeExists(int from, int to);

        public abstract double EdgeWeight(int from, int to);

        public abstract void GraphPrint();

        public bool LoadFile(string path)
        {
            if (!File.Exists(path)) throw new Exception("Arquivo não encontrado.");

            bool setted = false;
            int nodes = 0;
            int edges = 0;

            foreach (string line in File.ReadLines(path))
            {
                string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!setted)
                {
                    setted = true;
                    nodes = Convert.ToInt32(items[0]);
                    edges = Convert.ToInt32(items[1]);
                    Directed = Convert.ToBoolean(Convert.ToInt32(items[2]));
                    Weighted = Convert.ToBoolean(Convert.ToInt32(items[3]));

                    continue;
                }

                string nodeFrom = Convert.ToString(items[0]);
                string nodeTo = Convert.ToString(items[1]);
                double weight = Weighted ? Convert.ToDouble("0" + items[2].Replace(".", ",")) : 0;

                if (this.NodeIndex(nodeFrom) == -1) this.NodeInsert(nodeFrom);
                if (this.NodeIndex(nodeTo) == -1) this.NodeInsert(nodeTo);

                this.EdgeInsert(this.NodeIndex(nodeFrom), this.NodeIndex(nodeTo), weight);
            }
            Nodes = NodeNames.Count;
            Edges = edges;

            //if (Nodes != nodes) throw new Exception("O número de vértices informado no cabeçalho do arquivo difere da quantidade inserida.");
            if (Edges != edges) throw new Exception("O número de arestas informado no cabeçalho do arquivo difere da quantidade inserida.");

            return true;
        }

    }
}
