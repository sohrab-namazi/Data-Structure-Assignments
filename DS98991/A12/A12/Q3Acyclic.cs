using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Graph graph = new Graph(nodeCount);
            foreach (long[] Edge in edges)
            {
                graph.Nodes[(int)Edge[0] - 1].Add((Edge[1]) - 1);
                //graph.Nodes[(int)Edge[1] - 1].Add((Edge[0]) - 1);
            }
            if (graph.IsCyclic()) return 1;
            return 0;
        }

        public class Graph
        {
            public List<List<long>> Nodes;
            public List<bool> marked;
            public List<bool> InStack;
            public long size;
            public long cc;

            public Graph(long size)
            {
                this.size = size;
                Nodes = new List<List<long>>();
                marked = new List<bool>();
                InStack = new List<bool>();
                for (long i = 0; i < size; i++)
                {
                    Nodes.Add(new List<long>());
                    marked.Add(false);
                    InStack.Add(false);
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

            public void DFS(long startNode)
            {
                marked[(int)startNode] = true;
                foreach (long node in Nodes[(int)startNode])
                {
                    if (!marked[(int)node])
                    {
                        DFS(node);
                    }
                }
            }

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
    }
}