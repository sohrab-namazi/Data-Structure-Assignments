using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {

            if (a > b)
            {
                long c = a;
                a = b;
                b = c;
            }
                //Solve(b, a);

            Q7FibonacciSum q7 = new Q7FibonacciSum("");
            
            long p = q7.Solve(b);
            long q = q7.Solve(a - 1);

            if ((p - q) < 0)
                return (10 + (p - q) % 10);
            return (p - q) % 10;



        }
    }
}
