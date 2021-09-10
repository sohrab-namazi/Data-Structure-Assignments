using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            return MergeSort(n, a);
        }

        public static long[] MergeSort(long n, long[] numbers)
        {
            if (n == 1) return numbers;

            int OneSize = (int)Math.Ceiling((double)n / 2);
            int TwoSize = (int)Math.Floor((double)n / 2);

            long[] numbers1 = new long[OneSize];
            long[] numbers2 = new long[TwoSize];

            for (int i = 0; i < OneSize; i++)
            {
                numbers1[i] = numbers[i];
            }
            for (int i = OneSize; i < n; i++)
            {
                numbers2[i - OneSize] = numbers[i];
            }

            numbers1 = MergeSort(OneSize, numbers1);
            numbers2 = MergeSort(TwoSize, numbers2);

            return Merge(numbers1, numbers2);
        }

        private static long[] Merge(long[] numbers1, long[] numbers2)
        {
            int size = numbers2.Length + numbers1.Length;
            long[] numbers = new long[size];

            int i = 0;
            int j = 0;
            int l = 0;

            while (i != numbers1.Length || j != numbers2.Length)
            {
                if (i == numbers1.Length)
                {
                    for (int k = j; k < numbers2.Length; k++)
                    {
                        numbers[l] = numbers2[k];
                        l++;
                    }
                    break;
                }

                if (j == numbers2.Length)
                {
                    for (int k = i; k < numbers1.Length; k++)
                    {
                        numbers[l] = numbers1[k];
                        l++;
                    }
                    break;
                }

                if (numbers1[i] < numbers2[j])
                {
                    numbers[l] = numbers1[i];
                    i++;
                }
                else
                {
                    numbers[l] = numbers2[j];
                    j++;
                }
                l++;
            }
            return numbers;
        }


    }
}
