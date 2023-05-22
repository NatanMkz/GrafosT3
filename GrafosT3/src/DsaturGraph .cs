using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Graph
{

    class maxSat : IComparer<nodeInfo>
    {
        public int Compare(nodeInfo lhs, nodeInfo rhs)
        {
            if (lhs.sat != rhs.sat)
                return rhs.sat.CompareTo(lhs.sat);
            else if (lhs.deg != rhs.deg)
                return rhs.deg.CompareTo(lhs.deg);
            else
                return rhs.vertex.CompareTo(lhs.vertex);
        }
    }

    public class DsaturGraph : GraphList
    {
        public List<int> colorsUsed = new();
        
        public void DSatur()
        {
            int u, i;
            List<bool> used = new List<bool>(new bool[this.Nodes]);
            List<int> nodeColor = new List<int>(new int[this.Nodes]);
            List<int> d = new List<int>(new int[this.Nodes]);
            List<HashSet<int>> adjCols = new List<HashSet<int>>();
            SortedSet<nodeInfo> Q = new SortedSet<nodeInfo>(new maxSat());

            for (u = 0; u < this.Nodes; u++)
            {
                nodeColor[u] = -1;
                d[u] = this.List[u].Count;
                adjCols.Add(new HashSet<int>());
                Q.Add(new nodeInfo
                {
                    sat = 0,
                    deg = d[u],
                    vertex = u
                });
            }

            while (Q.Count > 0)
            {
                nodeInfo maxNode = Q.Min;
                u = maxNode.vertex;
                Q.Remove(maxNode);
                foreach (Edge v in this.List[u])
                {
                    if (nodeColor[v.ToNode] != -1)
                        used[v.ToNode] = true;
                }
                for (i = 0; i < used.Count; i++)
                {
                    if (used[i] == false)
                        break;
                }
                foreach (Edge v in this.List[u])
                {
                    if (nodeColor[v.ToNode] != -1)
                        used[v.ToNode] = false;
                }
                nodeColor[u] = i;

                if (!colorsUsed.Contains(i))
                {
                    colorsUsed.Add(i);
                }
                foreach (Edge v in this.List[u])
                {
                    if (nodeColor[v.ToNode] == -1)
                    {
                        Q.Remove(new nodeInfo
                        {
                            sat = adjCols[v.ToNode].Count,
                            deg = d[v.ToNode],
                            vertex = v.ToNode
                        });
                        adjCols[v.ToNode].Add(i);
                        d[v.ToNode]--;
                        Q.Add(new nodeInfo
                        {
                            sat = adjCols[v.ToNode].Count,
                            deg = d[v.ToNode],
                            vertex = v.ToNode
                        });
                    }
                }
            }

            for (u = 0; u < Nodes; u++)
            {
                Console.WriteLine($"Vertex {u} ---> Color {nodeColor[u]}");
            }
        }


    }

}
