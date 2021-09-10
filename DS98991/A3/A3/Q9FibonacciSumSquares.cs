using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<long> Fibs = new List<long>();

            Fibs.Add(0);
            Fibs.Add(1);
            int i = 2;
            while (true)
            {
                Fibs.Add((Fibs[i - 1] + Fibs[i - 2]) % 10);
                if (Fibs[i] == 1 && Fibs[i - 1] == 0)
                {
                    break;
                }
                i++;
            }

            long TLength = Fibs.Count - 2;

            long RemainderIndex = n % TLength;

            return (Fibs[(int)RemainderIndex] * (Fibs[(int)RemainderIndex] + Fibs[(int)RemainderIndex - 1])) % 10;
            
        }
    }
}
