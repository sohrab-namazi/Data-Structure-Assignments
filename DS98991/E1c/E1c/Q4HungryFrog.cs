using System;
using TestCommon;

namespace E1c
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            Tuple[] tuples = new Tuple[n];

            tuples[0] = new Tuple(numbers[0][0], numbers[1][0]);

            for (int i = 1; i < n ; i++)
            {
                long FormerA = tuples[i - 1].a;
                long FormerB = tuples[i - 1].b;
                tuples[i] = new Tuple(Math.Max(FormerA + numbers[0][i], FormerB + numbers[0][i] - p), Math.Max(FormerB + numbers[1][i], FormerA + numbers[1][i] - p));
            }

            long a = tuples[n - 1].a;
            long b = tuples[n - 1].b;

            return Math.Max(a, b);
        }
    }

    public class Tuple
    {
        public long a;
        public long b;
        public Tuple(long a, long b)
        {
            this.a = a;
            this.b = b;
        }
    }

}
