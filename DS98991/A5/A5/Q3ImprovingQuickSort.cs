using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            return QuickSort3(a, 0, n - 1);
        }
        public static long[] QuickSort3(long[] numbers, long l, long r)
        {
            if (l >= r) return numbers;
            long[] partitions = Partition(ref numbers, l, r);
            QuickSort3(numbers, l, partitions[0] - 1);
            QuickSort3(numbers, partitions[1] + 1, r);
            return numbers;
        }
        public static long[] Partition(ref long[] numbers, long l, long r)
        {
            long a = l;
            long b = l;
            long[] partitions = new long[2];
            long PivotIndex = l;
            long Pivot = numbers[l];
            for (long i = l + 1; i <= r; i++)
            {
                if (numbers[i] < Pivot)
                {
                    Swap(ref numbers, a, i);
                    a++;
                    Swap(ref numbers, b + 1, i);
                    b++;
                }
                else if (numbers[i] == Pivot)
                {
                    Swap(ref numbers, b + 1, i);
                    b++;
                }
            }
            partitions[0] = a;
            partitions[1] = b;
            return partitions;
        }
        public static void Swap(ref long[] numbers, long a, long b)
        {
            long AValue = numbers[a];
            long BValue = numbers[b];
            numbers[b] = AValue;
            numbers[a] = BValue;
        }
    }
}
