using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {

            long TotalSum = 0;

            Array.Sort(adRevenue);
            Array.Sort(averageDailyClick);

            for (int i = 0; i < Math.Min(adRevenue.Length, slotCount); i++)
            {
                TotalSum += adRevenue[i] * averageDailyClick[i];
            }

           

            return TotalSum;
        }
    }
}
