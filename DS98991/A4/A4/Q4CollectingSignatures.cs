using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {

            Interval[] intervals = new Interval[tenantCount];
            for (int i = 0; i < tenantCount; i++)
            {
                intervals[i] = new Interval(startTimes[i], endTimes[i]);
            }
            Array.Sort(intervals,
            delegate (Interval x, Interval y) { return x.end.CompareTo(y.end); });

            List<Interval> intervalsList = intervals.ToList();

            long answer = 0;

            while (intervalsList.Count != 0)
            {
                int i = 1;
                while (i <= intervalsList.Count - 1)
                {
                    if (Interval.HaveShared(intervalsList[0], intervalsList[i]))
                    {
                        intervalsList.RemoveAt(i);
                        

                    }

                    else
                    {
                        i++;
                    }

                    

                }

                intervalsList.RemoveAt(0);
                answer++;



            }

            return answer;
        }


        

     
    }

    public class Interval
    {
        public long start;
        public long end;

        public Interval(long start, long end)
        {
            this.start = start;
            this.end = end;
        }

        public bool IsInInterval(int a)
        {
            if (this.end > a && this.start < a) return true;

            return false;

        }

        public static bool HaveShared(Interval a, Interval b)
        {
            if (a.start <= b.end && a.end >= b.start) return true;
            return false;
        }
    }
}
