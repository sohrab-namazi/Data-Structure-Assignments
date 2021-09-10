using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            long Size = nodes.Length;
            Node[] Tree = new Node[Size];
            long i = 0;
            foreach (long[] node in nodes)
            {
                long Key = node[0];
                long L = node[1];
                long R = node[2];
                Node Node = new Node(Key, L, R);
                Tree[i] = Node;
                i++;

            }

            foreach (Node Node in Tree)
            {
                if (Node.LeftChildIndex != -1)
                {
                    Node.LeftChild = Tree[Node.LeftChildIndex];
                }
                else
                {
                    Node.LeftChild = null;
                }
                if (Node.RightChildIndex != -1)
                {
                    Node.RightChild = Tree[Node.RightChildIndex];
                }
                else
                {
                    Node.RightChild = null;
                }
            }
            Node Root = Tree[0];

            return IsBST(Root, long.MinValue, long.MaxValue);
        }

        public static bool IsBST(Node node, long Min, long Max)
        {
            if (node.Key < Min || node.Key >= Max) return false;

            if (node.LeftChild == null && node.RightChild == null) return true;
            else if (node.LeftChild == null)
            {
                return IsBST(node.RightChild, node.Key, Max);
            }
            else if (node.RightChild == null)
            {
                return IsBST(node.LeftChild, Min, node.Key);
            }
            else
            {
                return ((IsBST(node.RightChild, node.Key, Max))) && (IsBST(node.LeftChild, Min, node.Key));
            }

        }
    }
}
