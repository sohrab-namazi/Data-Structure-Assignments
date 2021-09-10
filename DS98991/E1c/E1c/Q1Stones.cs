using System;
using TestCommon;

namespace E1c
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            long i = 0;
            long sum = 0;

            foreach (long num in stones) sum += num;

            if (n > sum) return 0;

            while (n > 0)
            {
                n -= stones[i];
                i++;
            }
            return i;
        }
    }
}
