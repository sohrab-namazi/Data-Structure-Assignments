using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery : Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            Couple[] couples = new Couple[points.Length + startSegments.Length + endSegment.Length];
            for (long i = 0; i < points.Length; i++)
            {
                couples[i] = new Couple(points[i], 0, i);
            }
            for (long j = 0; j < startSegments.Length; j++)
            {
                couples[points.Length + j] = new Couple(startSegments[j] - 0.1, -1);
            }
            for (long k = 0; k < endSegment.Length; k++)
            {
                couples[points.Length + startSegments.Length + k] = new Couple(endSegment[k] + 0.1, 1);
            }
            Array.Sort(couples, delegate (Couple a, Couple b) { return a.X.CompareTo(b.X); });
            long[] Answers = new long[points.Length];
            long left = 0;
            long right = 0;
            for (long i = 0; i < points.Length + startSegments.Length + endSegment.Length; i++)
            {
                if (couples[i].Y == -1)
                {
                    left++;
                }
                else if (couples[i].Y == 1)
                {
                    right++;
                }
                else
                {
                    Answers[couples[i].XIndex] = left - right;
                }
            }
            return Answers;
        }


        public class Couple
        {
            public Couple(double Start, double End)
            {
                this.X = Start;
                this.Y = End;
            }

            public Couple(double Start, double End, long XIndex)
            {
                this.X = Start;
                this.Y = End;
                this.XIndex = XIndex;
            }
            public double X { get; set; }
            public double Y { get; set; }
            public long XIndex { get; set; }
        }

    }
}
