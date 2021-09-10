using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }

        public long Solve(long n, long node, long[] BST)
        {
            Node Root = new Node(0, BST[0]);
            BST Tree = new BST(Root);
            for (long i = 1; i < n; i++)
            {
                if (BST[i] != -1)
                {
                    Tree.Insert(i, BST[i], Root);
                }
            }
            long Key = BST[node];
            Node next = Tree.Next(Key);
            if (next == null) return -1;
            return next.Index;
        }

        public class BST
        {
            public Node Root;

            public BST(Node Root)
            {
                this.Root = Root;
            }
            public Node Find(long k, Node Root)
            {
                if (k == Root.Key) return Root;
                else if (k < Root.Key)
                {
                    if (Root.LeftChild == null) return Root;
                    return Find(k, Root.LeftChild);
                }
                else
                {
                    if (Root.RightChild == null) return Root;
                    return Find(k, Root.RightChild);
                }
            }

            public void Insert(long Index, long k, Node R)
            {
                Node node = new Node(Index, k);
                Node P = Find(k, R);
                if (P.Key > k)
                {
                    P.LeftChild = node;
                }
                else
                {
                    P.RightChild = node;
                }
                node.Parent = P;
            }

            public Node LeftDescendant(Node node)
            {
                if (node.LeftChild == null) return node;
                else
                {
                    return (LeftDescendant(node.LeftChild));
                }
            }

            public Node Next(long i)
            {
                Node node = Find(i, this.Root);
                if (node.RightChild != null)
                {
                    return LeftDescendant(node.RightChild);
                }
                else
                {
                    Node n = RightAncestor(node);
                    if (n != null) return n;
                    else return null;
                }
            }

            public Node RightAncestor(Node node)
            {
                if (node.Parent == null) return null;
                if (node.Key < node.Parent.Key)
                {
                    return node.Parent;
                }
                else
                {
                    return RightAncestor(node.Parent);
                }
            }
        }

        public class Node
        {
            public long Key;
            public long Index;
            public Node LeftChild;
            public Node RightChild;
            public Node Parent;

            public Node(long Index, long Key)
            {
                this.Index = Index;
                this.Key = Key;
            }



        }
    }
}
