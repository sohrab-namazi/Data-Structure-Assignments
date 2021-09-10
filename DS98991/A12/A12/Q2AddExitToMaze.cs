using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Graph graph = new Graph(nodeCount);
            foreach (long[] Edge in edges)
            {
                graph.Nodes[(int)Edge[0] - 1].Add((Edge[1]) - 1);
                graph.Nodes[(int)Edge[1] - 1].Add((Edge[0]) - 1);
            }

            return graph.CCNumbers();
        }

        public class Graph
        {
            public List<List<long>> Nodes;
            public List<bool> marked;
            public long size;
            public long cc;

            public Graph(long size)
            {
                this.size = size;
                Nodes = new List<List<long>>();
                marked = new List<bool>();
                for (long i = 0; i < size; i++)
                {
                    Nodes.Add(new List<long>());
                    marked.Add(false);
                }
            }

            //public long DFS()
            //{
            //    long cc = 0;
            //    for (long i = 0; i < size; i++)
            //    {
            //        if (!marked[(int)i])
            //        {
            //            Explore(i);
            //            cc++;
            //        }
            //    }
            //    return cc;
            //}

            //public void Explore(long i)
            //{
            //    marked[(int)i] = true;
            //    foreach (long node in Nodes[(int)i])
            //    {
            //        if (!marked[(int)node])
            //        {
            //            Explore(node);
            //        }
            //    }
            //}

            public void DFS(long startNode)
            {
                marked[(int)startNode] = true;
                Stack<long> stack = new Stack<long>();
                stack.Push(startNode);
                while(stack.Count > 0)
                {
                    long node = stack.Pop();
                    marked[(int) node] = true;

                    foreach (long adj in Nodes[(int) node])
                    {
                        if (!marked[(int)adj]) stack.Push(adj); 
                    }
                }
                //foreach (long node in Nodes[(int)startNode])
                //{
                //    if (!marked[(int)node])
                //    {
                //        DFS(node);
                //    }
                //}
            }

            public long CCNumbers()
            {
                for (long i = 0; i < size; i++)
                {
                    if (!marked[(int)i])
                    {
                        cc++;
                        DFS(i);
                    }
                }
                return cc;
            }
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
