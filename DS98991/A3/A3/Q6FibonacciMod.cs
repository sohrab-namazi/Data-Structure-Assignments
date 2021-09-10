using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            List<long> Fibs = new List<long>();

            Fibs.Add(0);
            Fibs.Add(1);
            int i = 2;
            while (true)
            {
                Fibs.Add((Fibs[i - 1] + Fibs[i - 2]) % b);
                if (Fibs[i] == 1 && Fibs[i - 1] == 0)
                {
                    break;
                }
                i++;
            }

            long TLength = Fibs.Count - 2;

            

            long RemainderIndex = a % TLength;



            return Fibs[(int) RemainderIndex];
            


           
            




        }

        public static List<long> T(long[] numbers)
        {
            List<long> t = new List<long>();
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == 0 && numbers[i + 1] == 1)
                {
                    for (int j = 0; j < i; j++) t.Add(numbers[j]);
                }
            }
            return t;
        }
    }
}
