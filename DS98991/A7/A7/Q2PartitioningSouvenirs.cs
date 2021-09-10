using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            if (souvenirsCount < 3) return 0;
            long sum = 0;
            foreach (long a in souvenirs) sum += a;
            if (sum % 3 != 0) return 0;
            if (subsetSum(souvenirs, souvenirs.Length - 1, sum / 3, sum / 3, sum / 3)) return 1;
            return 0;
        }
        public static bool subsetSum(long[] souvenirs, long size, long a, long b, long c)
        {
            if (a == 0 && b == 0 && c == 0) return true;
            
            bool One = false;
            if (a - souvenirs[size] >= 0)   
            {
                One = subsetSum(souvenirs, size - 1, a - souvenirs[size], b, c);
            }

            bool Two = false;
            if (!One && (b - souvenirs[size] >= 0))
            {
                Two = subsetSum(souvenirs, size - 1, a, b - souvenirs[size], c);
            }

            bool Three = false;
            if ((!One && !Two) && (c - souvenirs[size] >= 0))
            {
                Three = subsetSum(souvenirs, size - 1, a, b, c - souvenirs[size]);
            }

            return One || Two || Three;
        }
    }
}
