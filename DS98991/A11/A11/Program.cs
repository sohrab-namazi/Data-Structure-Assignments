using System;
using System.Collections;
using System.Collections.Generic;






namespace A11
{
    class Program
    {
        public const long M = 1_000_000_001;
        public static long X;
        public static SplayTree Tree;
        static void Main(string[] args)
        {
            Tree = new SplayTree();
            List<string> result = new List<string>();
//            ? 1
//+ 1
//? 1
//+ 2
//s 1 2
//+ 1000000000
//? 1000000000
//- 1000000000
//? 1000000000
//s 999999999 1000000000
//- 2
//? 2
//- 0
//+ 9
//s 0 9
//            result.Add(Sum("2 23"));
            result.Add(Find("1"));
            Add("1");
            result.Add(Find("1"));
            Add("2");
            result.Add(Sum("1 2"));




            foreach (string s in result) Console.WriteLine(s);
        }
        public static long Convert(long i)
            => i = (i + X) % M;

        public static string Add(string arg)
        {
            long i = Convert(long.Parse(arg));
            Tree.STAdd(i);
            return null;
        }

        public static string Del(string arg)
        {
            long i = Convert(long.Parse(arg));
            Tree.STDelete(i);
            return null;
        }

        public static string Find(string arg)
        {
            long i = Convert(int.Parse(arg));
            string result = Tree.IsExisting(i);
            return result;
        }

        public static string Sum(string arg)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));
            long sum = Tree.sum(l, r);
            X = sum;
            return sum.ToString();
        }

        public class SplayTree
        {
            public Node Root;

            public Node Find(Node Root, long i)
            {
                if (Root == null) return null;
                Node curr = Root;
                while (curr.Key != i)
                {
                    if (curr.Key > i)
                    {
                        if (curr.LeftChild == null) break;
                        curr = curr.LeftChild;
                    }
                    else if (curr.Key < i)
                    {
                        if (curr.RightChild == null) break;
                        curr = curr.RightChild;
                    }
                }
                return curr;
                //if (i == Root.Key)
                //{
                //    return Root;
                //}
                //if (i > Root.Key)
                //{
                //    if (Root.RightChild == null) return Root;
                //    return Find(Root.RightChild, i);
                //}
                //else
                //{
                //    if (Root.LeftChild == null) return Root;
                //    return Find(Root.LeftChild, i);
                //}
            }

            public void Add(long Key)
            {
                if (this.Root == null)
                {
                    Node root = new Node(Key);
                    this.Root = root;
                    return;
                }
                if (this.Find(this.Root, Key).Key == Key) return;
                Node node = new Node(Key);
                Node Parent = Find(this.Root, Key);
                if (Parent.Key > Key) Parent.LeftChild = node;
                else
                {
                    Parent.RightChild = node;
                }
                node.Parent = Parent;
            }

            public Node STFind(Node Root, long i)
            {
                Node Found = Find(Root, i);
                // Splay(i);
                return Found;
            }

            public void STAdd(long Key)
            {
                Add(Key);
                Splay(Key);
            }

            public void Splay(long Key)
            {
                Node node = Find(this.Root, Key);

                while (node.Parent != null)
                {
                    if (Key == Root.Key) return;
                    if (node == null) return;

                    if (node.Parent.Parent == null)
                    {
                        Zig(node);
                    }
                    else if ((node.Parent.LeftChild == node && node.Parent.Parent.LeftChild == node.Parent) || (node.Parent.RightChild == node && node.Parent.Parent.RightChild == node.Parent))
                    {
                        ZigZig(node);
                    }
                    else
                    {
                        ZigZag(node);
                    }
                }

                Root = node;

            }

            public void Zig(Node node)
            {
                Node parent = node.Parent;
                //LeftZig
                if (parent.RightChild == node)
                {
                    parent.RightChild = node.LeftChild;
                    if (node.LeftChild != null) node.LeftChild.Parent = parent;
                    node.LeftChild = parent;
                    parent.Parent = node;
                    node.Parent = null;
                    this.Root = node;
                }
                //RightZig
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = node.RightChild;
                    if (node.RightChild != null) node.RightChild.Parent = parent;
                    node.RightChild = parent;
                    parent.Parent = node;
                    node.Parent = null;
                    this.Root = node;
                }
            }

            public void ZigZig(Node node)
            {
                Node parent = node.Parent;
                Node ancestor = parent.Parent;
                Node godFather = ancestor.Parent;
                int lr = 0;
                if (godFather != null)
                {
                    if (godFather.LeftChild == ancestor)
                    {
                        lr = -1;
                    }
                    else
                    {
                        lr = 1;
                    }
                }


                //RightZigZig
                if (parent.LeftChild == node)
                {
                    ancestor.LeftChild = parent.RightChild;
                    if (parent.RightChild != null) parent.RightChild.Parent = ancestor;
                    ancestor.Parent = parent;

                    parent.RightChild = ancestor;
                    parent.LeftChild = node.RightChild;
                    if (node.RightChild != null) node.RightChild.Parent = parent;

                    parent.Parent = node;

                    node.RightChild = parent;
                    node.Parent = godFather;
                    if (lr == -1) godFather.LeftChild = node;
                    if (lr == 1) godFather.RightChild = node;
                }

                //LeftZigZig
                else
                {
                    ancestor.RightChild = parent.LeftChild;
                    if (parent.LeftChild != null) parent.LeftChild.Parent = ancestor;
                    ancestor.Parent = parent;

                    parent.LeftChild = ancestor;
                    parent.RightChild = node.LeftChild;
                    if (node.LeftChild != null) node.LeftChild.Parent = parent;
                    parent.Parent = node;

                    node.LeftChild = parent;
                    node.Parent = godFather;
                    if (lr == -1) godFather.LeftChild = node;
                    if (lr == 1) godFather.RightChild = node;
                }
            }

            public void ZigZag(Node node)
            {
                Node parent = node.Parent;
                Node ancestor = parent.Parent;
                Node godFather = ancestor.Parent;
                int lr = 0;
                if (godFather != null)
                {
                    if (godFather.LeftChild == ancestor)
                    {
                        lr = -1;
                    }
                    else
                    {
                        lr = 1;
                    }
                }

                //left to right
                if (parent.RightChild == node)
                {
                    ancestor.LeftChild = node.RightChild;
                    if (node.RightChild != null) node.RightChild.Parent = ancestor;
                    ancestor.Parent = node;

                    parent.RightChild = node.LeftChild;
                    if (node.LeftChild != null) node.LeftChild.Parent = parent;
                    parent.Parent = node;

                    node.LeftChild = parent;
                    node.RightChild = ancestor;
                    node.Parent = godFather;
                    if (lr == -1) godFather.LeftChild = node;
                    if (lr == 1) godFather.RightChild = node;
                }

                //right to left
                else
                {
                    ancestor.RightChild = node.LeftChild;
                    if (node.LeftChild != null) node.LeftChild.Parent = ancestor;
                    ancestor.Parent = node;

                    parent.LeftChild = node.RightChild;
                    if (node.RightChild != null) node.RightChild.Parent = parent;
                    parent.Parent = node;

                    node.RightChild = parent;
                    node.LeftChild = ancestor;
                    node.Parent = godFather;
                    if (lr == -1) godFather.LeftChild = node;
                    if (lr == 1) godFather.RightChild = node;
                }
            }

            public void STDelete(long i)
            {
                Node node = Find(Root, i);
                if (node == null) return;
                if (node.Key != i) return;
                Node next = Next(node.Key);
                if (next != null)
                {
                    Splay(next.Key);
                    Splay(node.Key);
                    Node l = node.LeftChild;
                    Node r = node.RightChild;
                    if (r != null) r.LeftChild = l;
                    if (l != null) l.Parent = r;
                    this.Root = r;
                    r.Parent = null;
                    return;
                }
                else
                {
                    Splay(node.Key);
                    Node l = node.LeftChild;
                    if (l != null)
                    {
                        l.Parent = null;
                        Root = l;
                    }
                    else
                    {
                        Root = null;
                    }
                }
                
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
                Node node = Find(Root, i);
                if (Find(this.Root, node.Key).Key != node.Key) return null;

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

            public long sum(long l, long r)
            {
                long result = 0;
                Node node = Find(Root, l);
                if (node == null) return 0;
                if (node.Key < l)
                {
                    Node nodeNext = Next(node.Key);
                    if (nodeNext == null) return 0;
                    node = nodeNext;
                }
                while (node != null && node.Key <= r)
                {
                    result += node.Key;
                    node = Next(node.Key);
                }
                return result;
            }

            public string IsExisting(long Key)
            {
                Node node2 = Find(this.Root, Key);
                if (node2 == null) return "Not found";
                if (node2.Key != Key) return "Not found";
                else return "Found";
            }
        }

        public class Node
        {
            public long Key;
            public Node LeftChild;
            public Node RightChild;
            public Node Parent;
            public Node(long Key)
            {
                this.Key = Key;
            }
        }









    }
}
