using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace A3
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = new long[10] { 3, 6, 7, 3, 1, 11, 20, 20, 0, 1 };
            long[] Answer =  Q1MergeSort.MergeSort(10, numbers);
            foreach (int num in Answer) Console.WriteLine(num);

        }
       

       
    }
}
