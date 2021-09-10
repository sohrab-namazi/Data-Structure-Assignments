using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long n = goldBars.Length;
            long[,] Results = new long[n + 1, W + 1];
            for (long i = 1; i <= n; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    long First = Results[i - 1, j];
                    long Second = 0;
                    if (j >= goldBars[i - 1])
                    {
                        Second = goldBars[i - 1] + Results[i - 1, j - goldBars[i - 1]];
                    }
                    Results[i, j] = Math.Max(First, Second);
                }
            }

            return Results[n, W];
        }
    }
}
