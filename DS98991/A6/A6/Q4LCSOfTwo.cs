using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long seq1Size = seq1.Length;
            long seq2Size = seq2.Length;
            long[,] Table = new long[seq1Size, seq2Size];
            for (int i = 0; i < seq1Size; i++)
            {
                if (seq2[0] == seq1[i])
                {
                    for (int j = i; j < seq1Size; j++)
                    {
                        Table[j, 0] = 1;
                    }
                    break;
                }
            }
            for (int i = 0; i < seq2Size; i++)
            {
                if (seq1[0] == seq2[i])
                {
                    for (int j = i; j < seq2Size; j++)
                    {
                        Table[0, j] = 1;
                    }
                    break;
                }
            }
            for (int i = 1; i < seq1Size; i++)
            {
                for (int j = 1; j < seq2Size; j++)
                {
                    if (seq1[i] == seq2[j])
                    {
                        long d = 1 + Table[i - 1, j - 1];
                        long l = 1 + Table[i, j - 1];
                        long u = 1 + Table[i - 1, j];

                        Table[i, j] = Math.Max(d, Math.Max(l, u));

                    }
                    else
                    {
                        long Up = Table[i - 1, j];
                        long Left = Table[i, j - 1];
                        Table[i, j] = Math.Max(Up, Left);
                    }
                }
            }
            return Table[seq1Size - 1, seq2Size - 1];
        }
    }
}
