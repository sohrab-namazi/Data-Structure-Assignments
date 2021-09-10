using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] BST)
        {
            List<long> Result = new List<long>();
            long Counter = 0;
            InOrder(ref Counter, ref Result, BST, 0);

            return Result.ToArray();





        }

        public static List<long> InOrder(ref long Counter, ref List<long> Result, long[] nodes, long i)
        {
            if (nodes[LeftChild(i)] != -1)
            {
                InOrder(ref Counter, ref Result, nodes, 2 * i + 1);
            }

            Result.Add(nodes[i]);
            Counter++;
            Console.WriteLine(nodes[i]);


            if (nodes[RightChild(i)] != -1)
            {
                InOrder(ref Counter, ref Result, nodes, 2 * i + 2);
            }
            return Result;
        }

        public static long LeftChild(long i)
        {
            return (2 * i) + 1;
        }
        public static long RightChild(long i)
        {
            return (2 * i) + 2;
        }
        public static long Parent(long i)
        {
            return i / 2;
        }
    }
}