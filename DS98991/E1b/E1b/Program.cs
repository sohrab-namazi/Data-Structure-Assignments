using System;

namespace E1b
{
    class Program
    {
        static void Main(string[] args)
        {
            long[][] numbers = new long[2][];
            numbers[0] = new long[] { 31, 47, 14, 9, 47, 0 };
            numbers[1] = new long[] { 14, 49, 11, 23, 10, 20 };
            Solve(6, 8, numbers);
        }
        public static long Solve(long n, long p, long[][] numbers)
        {
            long a = max(n, p, numbers, 0);
            long b = max(n, p, numbers, 1);
            return Math.Max(a, b);
        }

        public static long max(long n, long p, long[][] numbers, int k)
        {
            long[] answers = new long[n];
            int location = -1;

            answers[0] = numbers[k][0];

            if (answers[0] == numbers[0][0])
            {
                location = 0;
            }

            else
            {
                location = 1;
            }

            for (int i = 1; i < n; i++)
            {
                long Situation1 = 0;
                long Situation2 = 0;

                if (location == 1)
                {
                    Situation1 += numbers[1][i];
                    Situation2 += numbers[0][i] - p;
                }

                if (location == 0)
                {
                    Situation1 += numbers[0][i];
                    Situation2 += numbers[1][i] - p;
                }

                long min = Math.Max(Situation1, Situation2);
                answers[i] = answers[i - 1] + min;
                if (location == 0 && answers[i] - answers[i - 1] == numbers[0][i])
                {
                    location = 0;
                }
                else if (location == 1 && answers[i] - answers[i - 1] == numbers[0][i] - p)
                {
                    location = 0;
                }
                else
                {
                    location = 1;
                }


            }

            return answers[n - 1];

        }
    }

    
}
