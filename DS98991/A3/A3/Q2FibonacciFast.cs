using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long[] Fibs = new long[n + 1];

            if (n == 0) return 0;
            if (n == 1) return 1;

            Fibs[0] = 0;
            Fibs[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                Fibs[i] = Fibs[i - 1] + Fibs[i - 2];
            }

            return Fibs[n];
            
        }
    }
}
