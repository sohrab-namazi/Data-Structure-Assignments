using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);

        public long[] Solve(long nodeCount, long[][] edges)
        {
            Graph graph = new Graph(nodeCount);
            foreach (long[] Edge in edges)
            {
                graph.Nodes[(int)Edge[0] - 1].Add((Edge[1]) - 1);
                //graph.Nodes[(int)Edge[1] - 1].Add((Edge[0]) - 1);
            }
            graph.DFS();
            List<long> res = graph.Posts;

            long[] result = new long[nodeCount];
            long[] res1 = res.ToArray();
            for (long i = 0; i < nodeCount; i++)
            {
                long j = max(res);
                result[i] = j + 1;
                res[(int)j] = -1;
            }
            return result;
        }
        public static long max(List<long> a)
        {
            long max = long.MinValue;
            foreach (long b in a) if (b > max) max = b;

            return a.IndexOf(max);
        }

        public class Graph
        {
            public List<List<long>> Nodes;
            public List<bool> marked;
            public List<bool> InStack;
            public List<long> Pres;
            public List<long> Posts;
            public long size;
            public long clock = 1;

            public Graph(long size)
            {
                this.size = size;
                Nodes = new List<List<long>>();
                marked = new List<bool>();
                InStack = new List<bool>();
                Posts = new List<long>();
                Pres = new List<long>();
                for (long i = 0; i < size; i++)
                {
                    Nodes.Add(new List<long>());
                    marked.Add(false);
                    InStack.Add(false);
                    Pres.Add(-1);
                    Posts.Add(-1);
                }
            }


            public bool IsCyclic()
            {
                for (long i = 0; i < size; i++)
                {
                    if (IsCyclicSpec(i)) return true;
                }
                return false;
            }

            private bool IsCyclicSpec(long i)
            {
                marked[(int)i] = true;
                InStack[(int)i] = true;
                foreach (long node in Nodes[(int)i])
                {
                    if (marked[(int)node] == false && IsCyclicSpec(node))
                    {
                        return true;
                    }
                    else if (InStack[(int)node]) return true;
                }
                InStack[(int)i] = false;
                return false;

            }

            public void DFS()
            {
                for (long i = 0; i < size; i++)
                {
                    if (!marked[(int)i])
                    {
                        Explore(i);
                    }
                }
            }

            public void Explore(long i)
            {
                marked[(int)i] = true;
                previsit(i);
                foreach (long node in Nodes[(int)i])
                {
                    if (!marked[(int)node])
                    {
                        Explore(node);
                    }
                }
                postvisit(i);
            }

            private void previsit(long i)
            {
                Pres[(int)i] = clock;
                clock++;
            }

            private void postvisit(long i)
            {
                Posts[(int)i] = clock;
                clock++;
            }

            //public void DFS(long startNode)
            //{
            //    marked[(int)startNode] = true;
            //    foreach (long node in Nodes[(int)startNode])
            //    {
            //        if (!marked[(int)node])
            //        {
            //            DFS(node);
            //        }
            //    }
            //}

            //public long CCNumbers()
            //{
            //    for (long i = 0; i < size; i++)
            //    {
            //        if (!marked[(int) i])
            //        {
            //            cc++;
            //            DFS(i);
            //        }
            //    }
            //    return cc;
            //}
        }

        public class Node
        {
            public long Value;

            public Node(long Value)
            {
                this.Value = Value;
            }
        }

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}
