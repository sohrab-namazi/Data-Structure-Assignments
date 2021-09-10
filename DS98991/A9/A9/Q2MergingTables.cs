using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] tableSizes;
        long[] rank;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long RankMax = 0;
            //long Size = targetTables.Length;
            long[] Rank = new long[tableSizes.Length];
            long[] Parents = new long[tableSizes.Length];
            long[] Maxs = new long[targetTables.Length];

            for (long i = 0; i < tableSizes.Length; i++)
            {
                Rank[i] = tableSizes[i];
                Parents[i] = i;
            }

            RankMax = Rank.Max();

            for (long i = 0; i < targetTables.Length; i++)
            {
                Union(targetTables[i] - 1, sourceTables[i] - 1, ref Parents, ref Rank, ref RankMax);
                Maxs[i] = RankMax;
            }

            return Maxs;
        }

        public static long Find(long i, long[] Parents)
        {
            while (i != Parents[i])
            {
                i = Parents[i];
            }

            return i;
        }

        public static void Union(long i, long j, ref long[] Parents, ref long[] Rank, ref long MaxRank)
        {
            long First = Find(i, Parents);
            long Second = Find(j, Parents);
            if (First == Second) return;

            long ID = Math.Min(First, Second);
            Rank[ID] = Rank[First] + Rank[Second];

            if (Rank[ID] > MaxRank)
            {
                MaxRank = Rank[ID];
            }

            if (ID == First)
            {
                Parents[Second] = First;
                //Rank[Second]= Rank[First] + Rank[Second];

            }
            else
            {
                Parents[First] = Second;
                //Rank[First] = Rank[First] + Rank[Second];
            }




        }

    }
}
