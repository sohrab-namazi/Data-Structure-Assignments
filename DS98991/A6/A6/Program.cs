using System;
using System.Collections.Generic;

namespace A6
{
    class Program
    {
        


        static void Main(string[] args)
        {
            long[] seq1 = new long[] { 5, 4, 11, 8, 16, 2 };
            long[] seq2 = new long[] { 10, 2, 17, 6, 1, 8, 14, 4, 15, 3, 13, 16, 0};
            long[] seq3 = new long[] { 5, 2, 6, 17, 3, 14, 1, 15, 9, 0, 11 };
            long a = Solve(seq1, seq2, seq3);

            Console.WriteLine(a);
        }

        public static long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long seq1Size = seq1.Length;
            long seq2Size = seq2.Length;
            long seq3Size = seq3.Length;
            long[,,] Table = new long[seq1Size, seq2Size, seq3Size];
            
            for (int i = 0; i < seq1Size; i++)
            {
                if ((seq1[i] == seq2[0]) && (seq1[i] == seq3[0]))
                {
                    for (int j = i; j < seq1Size; j++)
                    {
                        Table[j, 0, 0] = 1;
                    }
                }
            }
            for (int i = 0; i < seq2Size; i++)
            {
                if ((seq2[i] == seq1[0]) && (seq2[i] == seq3[0]))
                {
                    for (int j = i; j < seq2Size; j++)
                    {
                        Table[0, j, 0] = 1;
                    }
                }
            }
            for (int i = 0; i < seq3Size; i++)
            {
                if ((seq3[i] == seq2[0]) && (seq1[i] == seq3[0]))
                {
                    for (int j = i; j < seq3Size; j++)
                    {
                        Table[0, 0, j] = 1;
                    }
                }
            }

            for (int i = 1; i < seq1Size; i++)
            {
                for (int j = 1; j < seq2Size; j++)
                {
                    for (int k = 1; k < seq3Size; k++)
                    {
                        if ((seq1[i] == seq2[j]) && (seq1[i] == seq3[k]))
                        {
                            Table[i, j, k] = 1 + Table[i - 1, j - 1, k - 1];
                        }
                        else
                        {
                            long left = Table[i, j, k - 1];
                            long right = Table[i, j - 1, k];
                            long up = Table[i - 1, j, k];
                            Table[i, j, k] = Math.Max(Math.Max(left, right), up);
                        }
                    }
                }
            }


            return Table[seq1Size - 1, seq2Size - 1, seq3Size - 1];
        }
    }
}
