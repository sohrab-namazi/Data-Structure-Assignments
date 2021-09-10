using System;

namespace A7
{
    class Program
    {
        static void Main(string[] args)
        {

            Solve(5, new long[] {1, 2, 3, 4, 8 });
            
        }
        public static long Solve(long souvenirsCount, long[] souvenirs)
        {
            long Sum = 0;

            long Size = souvenirsCount;

            foreach (long num in souvenirs) Sum += num;

            if (Sum % 3 != 0) return 0;

            long TwoSumThird = 2 * Sum / 3;

            bool[,] Table = new bool[TwoSumThird + 1, Size + 1];

            for (long i = 0; i <= Size; i++)
            {
                Table[0, i] = true;
            }

            for (int i = 1; i <= Size; i++)
            {
                for (long j = 1; j <= TwoSumThird; j++)
                {
                    Table[i, j] = Table[i, j - 1];

                    if (j >= souvenirs[i])
                    {
                        Table[i, j] = Table[i, j] || Table[i - 1, j - souvenirs[i]];
                    }

                    
                }
            }



           









            return 0; 
            
        }


    }
}
