using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long size = b.Length;
            long[] answers = new long[size];
            for (int i = 0; i < size; i++)
            {
                answers[i] = BS(a, b[i], 0, a.Length - 1);

            }
            return answers;

        }

        public static long BS(long[] numbers, long n, long l, long r)
        {
            if (l >= r)
            {
                if (numbers[l] == n) return l;
                else return -1;
            }
            long MidIndex = (l + r) / 2;
            if (numbers[MidIndex] == n)
            {
                return MidIndex;
            }
            else if (numbers[MidIndex] > n)
            {
                return (BS(numbers, n, l, MidIndex));
            }
            else
            {
                return (BS(numbers, n, MidIndex + 1, r));
            }


        }
    }
}
