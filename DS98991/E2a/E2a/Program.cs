using System;
using System.Collections.Generic;

namespace E2a
{
    class Program
    {

        static void Main(string[] args)
        {
            long[] a = Solve(5, 0, 10, new long[] {3, 4, 8, 9, 10});
            
        
        }

        public static long[] Solve(
           long n,
           long changeIndex,
           long changeValue,
           long[] heap)
        {
            long FormerValue = heap[changeIndex];
            heap[changeIndex] += changeValue;

            if (FormerValue > heap[changeIndex])
            {
                SiftUp(ref heap, changeIndex);
            }
            else if (FormerValue < heap[changeIndex])
            {
                SiftDown(ref heap, changeIndex);
            }
            return heap;
        }

        public static void SiftDown(ref long[] heap, long i)
        {
            long Index = i;
            if (LeftChild(ref heap, i) != -1 && heap[LeftChild(ref heap, i)] < heap[Index])
            {
                Index = LeftChild(ref heap, i);
            }
            if (MiddleChild(ref heap, i) != -1 && heap[MiddleChild(ref heap, i)] < heap[Index])
            {
                Index = MiddleChild(ref heap, i);
            }
            if (RightChild(ref heap, i) != -1 && heap[RightChild(ref heap, i)] < heap[Index])
            {
                Index = RightChild(ref heap, i);
            }
            if (Index != i)
            {
                Swap(ref heap, i, Index);
                SiftDown(ref heap, Index);
            }
            else
            {
                return;
            }

        }

        public static void SiftUp(ref long[] heap, long i)
        {
            while (heap[i] < heap[Parent(ref heap, i)])
            {
                Swap(ref heap, i, Parent(ref heap, i));
                i = Parent(ref heap, i);
            }
        }

        public static void Swap(ref long[] heap, long i, long v)
        {
            long a = heap[i];
            long b = heap[v];
            heap[i] = b;
            heap[v] = a;
        }

        public static long LeftChild(ref long[] heap, long i)
        {
            if (3 * i + 1 < heap.Length)
            {
                return (3 * i) + 1;
            }
            return -1;
        }
        public static long MiddleChild(ref long[] heap, long i)
        {
            if (3 * i + 2 < heap.Length)
            {
                return (3 * i) + 2;
            }
            return -1;
        }
        public static long RightChild(ref long[] heap, long i)
        {
            if (3 * i + 3 < heap.Length)
            {
                return (3 * i) + 3;
            }
            return -1;
        }
        public static long Parent(ref long[] heap, long i)
        {
            
                return i / 3;
            
          
        }

        public class Node
        {
            public long Value;
            public Node LeftChild;
            public Node RightChild;

            public Node(long Value)
            {
                this.Value = Value;
            }

        }
    }
}
