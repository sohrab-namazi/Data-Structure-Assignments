using System;
using System.Collections.Generic;
using System.Linq;

namespace A4
{
    class Program
    {
        static void Main(string[] args)
        {

            //Solve(3, new long[3] {1, 2, 4 }, new long[3] {2, 3, 5 });
            long[] nums = new long[4] {1, 2, 3, 5 };
            long[] nums2 = new long[4] { 1, 2, 3, 6 };

            Console.WriteLine(Math.Max(nums.Max() , nums2.Max()));




        }

        public static long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<Interval> intervals = new List<Interval>();
            long[] Shared = new long[10];

            for (int i = 0; i < tenantCount; i++)
            {
                intervals.Add(new Interval(startTimes[i], endTimes[i]));
            }

            for (int i = 0; i < 1000; i++)
            {
                foreach (Interval interval in intervals)
                {
                    if (interval.start <= i && interval.end >= i)
                    {
                        Shared[i]++;
                    }
                }
            }

            foreach (long a in Shared) Console.WriteLine(a);

            return 0;
        }





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

    public static bool HaveShared(Interval a, Interval b)
    {
        if (a.start <= b.end && a.end >= b.start) return true;
        return false;
    }
}

   





   

    



