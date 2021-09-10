using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            Graph graph = new Graph(nodeCount);
            foreach (long[] Edge in edges)
            {
                graph.Nodes[(int)Edge[0] - 1].Add((Edge[1]) - 1);
                graph.Nodes[(int)Edge[1] - 1].Add((Edge[0]) - 1);
            }
            graph.DFS(StartNode - 1);
            if (graph.marked[(int)EndNode - 1] == true) return 1;
            return 0;
        }
        public class Graph
        {
            public List<List<long>> Nodes;
            public List<bool> marked;
            public long size;

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
        }
    }
}
