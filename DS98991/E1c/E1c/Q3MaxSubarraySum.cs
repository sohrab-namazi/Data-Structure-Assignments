using System;
using TestCommon;

namespace E1c
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long CurentMax = 0;
            long FinalMax = 0;

            for (int i = 0; i < n; i++)
            {
                CurentMax += numbers[i];
                if (CurentMax < 0)
                {
                    CurentMax = 0;
                }
               

                else if (FinalMax <= CurentMax)
                {
                    FinalMax = CurentMax;
                }

                   
            }

            return FinalMax;
        }
    }
}

