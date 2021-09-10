using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = new Point(xPoints[i], yPoints[i]);
            }

            Array.Sort(points, delegate (Point a, Point b) { return a.X.CompareTo(b.X); });

            double min = MinDistance(n, points, 0, n - 1);



            return Math.Round(min, 4);
        }

        public static double MinDistance(long n, Point[] points, long l, long r)
        {

            //if (n == 1) return 0;
            if (r - l == 1 || r - l == 0)
            {
                return Point.Distance(points[l], points[r]);
            }

            if (r - l == 2)
            {
                double min1 = (Point.Distance(points[l], points[l + 1]));
                double min2 = (Point.Distance(points[l + 1], points[r]));
                double min3 = (Point.Distance(points[l], points[r]));

                return Math.Min(min1, Math.Min(min2, min3));
            }


            long mid = (l + r) / 2;

            double LeftMinDis = MinDistance(mid - l + 1, points, l, mid);
            double RightMinDis = MinDistance(r - mid, points, mid + 1, r);
            double LeftRightMinDis = long.MaxValue;
            double d = Math.Min(LeftMinDis, RightMinDis);


            long MiddleX = points[mid].X;
            List<Point> CriticalPoints = new List<Point>();
            long i = 0;

            for (i = l; i <= r; i++)
            {
                if (Math.Abs(points[i].X - MiddleX) < d)
                {
                    CriticalPoints.Add(points[i]);
                    long j = 1;
                    i++;
                    while ((i <= r) && (points[i].X - MiddleX) < d)
                    {
                        CriticalPoints.Add(points[i]);
                        j++;
                        i++;
                    }

                    break;

                }
            }

            Array.Sort(CriticalPoints.ToArray(), delegate (Point a, Point b) { return a.Y.CompareTo(b.Y); });

            for (int k = 0; k < CriticalPoints.Count; k++)
            {
                for (int o = k - 7; o < k + 7; o++)
                {
                    if (o >= 0 && o < CriticalPoints.Count && o != k)
                    {
                        if (Point.Distance(CriticalPoints[k], CriticalPoints[o]) < LeftRightMinDis)
                        {
                            LeftRightMinDis = Point.Distance(CriticalPoints[k], CriticalPoints[o]);
                        }
                    }
                }
            }


            foreach (Point point in CriticalPoints) Console.WriteLine(point.X + ", " + point.Y);


            return Math.Min(d, LeftRightMinDis);
        }









        public class Point
        {
            public long X;
            public long Y;

            public Point(long X, long Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public static double Distance(Point a, Point b)
            {
                return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            }
        }
    }
}