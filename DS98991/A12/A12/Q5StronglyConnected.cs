using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected : Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Graph graph = new Graph(nodeCount);
            Graph RGraph = new Graph(nodeCount);


            for (long i = 0; i < edges.Length; i++)
            {
                RGraph.addEdge(edges[i][1] - 1, edges[i][0] - 1);
                graph.addEdge(edges[i][0] - 1, edges[i][1] - 1);
            }

            RGraph.DFS();
            var revPost = RGraph.TopologicalSort();

            graph.SCCExplorer(revPost);
            return graph.SCCs;
        }

        public class Tuple
        {
            public long PO;
            public long number;
        }

        public class Graph
        {
            public long NodesCount;
            public List<bool> marked = new List<bool>();
            public long[] PreVisit;
            public long[] PostVisit;
            public long clock = 1;
            public long CCs;
            public List<long> Nodes = new List<long>();
            public List<List<long>> Edges = new List<List<long>>();
            public Tuple[] nodes;
            public long SCCs;

            public Graph(long nodeCount)
            {
                NodesCount = nodeCount;
                PostVisit = new long[NodesCount];
                PreVisit = new long[NodesCount];
                nodes = new Tuple[NodesCount];

                for (long i = 0; i < nodeCount; i++)
                {
                    Nodes.Add(i);
                    Edges.Add(new List<long>());
                    marked.Add(false);
                    nodes[i] = new Tuple();
                }
            }

            public void addEdge(long u, long v)
            {
                Edges[(int)u].Add(v);
            }

            public void Postvisit(long v)
            {
                PostVisit[v] = clock;
                clock++;
                nodes[v].number = v;
                nodes[v].PO = PostVisit[v];
            }

            public void Previsit(long v)
            {
                PreVisit[v] = clock;
                clock++;
            }

            public void Explore(long v)
            {
                marked[(int)v] = true;
                Previsit(v);
                for (long i = 0; i < Edges[(int)v].Count; i++)
                {
                    long node = Edges[(int)v][(int)i];
                    if (!marked[(int)node])
                    {
                        Explore(node);
                    }
                }
                Postvisit(v);
            }

            public void DFS()
            {
                CCs = 0;

                for (long i = 0; i < NodesCount; i++)
                {
                    if (!marked[(int)i])
                    {
                        CCs++;
                        Explore(i);
                    }
                }
            }

            public void SCCExplorer(long[] reversPostOrder)
            {
                SCCs = 0;

                foreach (long v in reversPostOrder)
                {
                    if (marked[(int)v] == false)
                    {
                        SCCs++;
                        Explore(v);
                    }
                }
            }
            public long[] TopologicalSort()
            {
                var res = nodes.OrderByDescending(x => x.PO).Select(x => x.number);
                return res.ToArray();
            }

        }
    }
}
