using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            string P = pattern;
            string T = text;
            const long p = 1000000007;
            const long x = 263;
            List<long> positions = new List<long>();
            long PHash = Q2HashingWithChain.PolyHash(P, 0, P.Length);
            long[] H = PreComputeHashes(T, P.Length, p, x);
            for (long i = 0; i < T.Length - P.Length+1; i++)
            {
                if (PHash != H[i])
                {
                    continue;
                }
                if (P.Equals(T.Substring((int) i, P.Length)))
                {
                    positions.Add(i);
                }
            }

            return positions.ToArray();
            
        }


        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {

            long[] H = new long[T.Length - P + 1];
            string S = T.Substring(T.Length - (int) P, P);
            H[T.Length - P] = Q2HashingWithChain.PolyHash(S, 0, P, (int) p, (int) x);
            long y = 1;
            for (long i = 0; i < P; i++)
            {
                y = (y * x) % p;
            }

            for (long i = T.Length - P - 1; i >= 0; i--)
            {
                
                H[i] = ((x * H[i + 1]) + T[(int) i] - y * T[(int) i + P]) % p;
                while (H[i] < 0)
                {
                    H[i] += p;
                }
            }

            return H;
        }
    }
}
