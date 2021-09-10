using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            long[][] Result = new long[3][];
            long Size = nodes.Length;
            Node[] Tree = new Node[Size];
            long[] PreOrder = new long[Size];
            long[] InOrder = new long[Size];
            long[] PostOrder = new long[Size];
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


            Stack<Node> stack = new Stack<Node>();
            Node Current = Tree[0];
            long j = 0;

            while (Current != null || stack.Count > 0)
            {
                while (Current != null)
                {
                    stack.Push(Current);
                    Current = Current.LeftChild;
                }

                Node Popped = stack.Pop();
                Current = Popped;
                Console.WriteLine(Popped.Key);
                InOrder[j] = Popped.Key;
                j++;

                Current = Current.RightChild;


            }

            j = 0;
            Current = Tree[0];
            stack.Clear();

            while (Current != null || stack.Count > 0)
            {
                while (Current != null)
                {
                    PreOrder[j] = Current.Key;
                    Console.WriteLine(Current.Key);
                    stack.Push(Current);
                    j++;
                    Current = Current.LeftChild;
                }

                Current = stack.Pop();
                Current = Current.RightChild;
            }

            j = 0;
            Current = Tree[0];
            stack.Clear();

            while (Current != null || stack.Count > 0)
            {
                while (Current != null)
                {
                    PostOrder[j] = Current.Key;
                    Console.WriteLine(Current.Key);
                    stack.Push(Current);
                    j++;
                    Current = Current.RightChild;
                }

                Current = stack.Pop();
                Current = Current.LeftChild;
            }

            Array.Reverse(PostOrder);

            Result[0] = InOrder;
            Result[1] = PreOrder;
            Result[2] = PostOrder;
            return Result;
        }
    }
    public class Node
    {
        public bool Marked;
        public Node Parent;
        public long LeftChildIndex;
        public long RightChildIndex;
        public long Key;
        public Node LeftChild;
        public Node RightChild;
        public Node(long Key, long LeftChild, long RightChild)
        {
            this.Key = Key;
            this.LeftChildIndex = LeftChild;
            this.RightChildIndex = RightChild;
        }

    }
}