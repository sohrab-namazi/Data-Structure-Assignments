//using System;
//using System.Collections.Generic;
//using System.Linq;

using System;

namespace A5
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = new long[] {10, 10, 5, 7, 5, 5};

            long result = Merge(3, ref numbers, 0, 1, 2, 0);

           

            Console.WriteLine(result);
        }

        public static long MergeSort(long n, ref long[] numbers, long l, long r)
        {
            if (n == 1) return 0;
            long Mid = (r + l) / 2;
            long LeftInv = MergeSort(Mid - l + 1, ref numbers, l, Mid);
            long RightInv = MergeSort(r - Mid, ref numbers, Mid + 1, r);
            return Merge(n, ref numbers, l, Mid, r, LeftInv + RightInv);
        }

        private static long Merge(long n, ref long[] numbers, long l, long Mid, long r, long SideInvNumbers)
        {
            long InvNumber = SideInvNumbers;
            long[] result = new long[n];
            long i = l;
            long j = Mid + 1;
            long k = 0;
            while (i < Mid + 1 && j < r + 1)
            {
                if (numbers[i] <= numbers[j])
                {
                    result[k] = numbers[i];
                    i++;
                    k++;
                }
                else
                {
                    InvNumber += r - j + 1;
                    result[k] = numbers[j];
                    j++;
                    k++;
                }
            }
            if (i == Mid + 1)
            {
                while (j != r + 1)
                {
                    result[k] = numbers[j];
                    k++;
                    j++;
                }
            }
            else
            {
                while (i != Mid + 1)
                {
                    result[k] = numbers[i];
                    k++;
                    i++;
                }
            }
            for (long o = l; o < r + 1; o++)
            {
                numbers[o] = result[o - l];
            }
            return InvNumber;
        }
    }
}
