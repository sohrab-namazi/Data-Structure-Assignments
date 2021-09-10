using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long seq1Size = seq1.Length;
            long seq2Size = seq2.Length;
            long seq3Size = seq3.Length;
            long[,,] Table = new long[seq1Size + 1, seq2Size + 1, seq3Size + 1];

            for (int i = 1; i <= seq1Size; i++)
            {
                for (int j = 1; j <= seq2Size; j++)
                {
                    for (int k = 1; k <= seq3Size; k++)
                    {
                        if ((seq1[i-1] == seq2[j-1]) && (seq2[j-1] == seq3[k-1]))
                        {
                            long d = 1 + Table[i, j, k - 1];
                            long l = 1 + Table[i, j - 1, k];
                           
                            long f = 1 + Table[i - 1, j, k];
                           
                            long z = 1 + Table[i - 1, j - 1, k - 1];


                          
                            Table[i, j, k] = Math.Max(d, Math.Max(l, Math.Max(f, z)));
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


            return Table[seq1Size , seq2Size , seq3Size ];
        }
    }
}
