using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {

            long size = weights.Length;
            long[] weightss = new long[size];
            long[] valuess = new long[size];


            Item[] Items = new Item[size];
            for (int i = 0; i < size; i++)
            {
                Items[i] = new Item(weights[i], values[i]);
            }
            Array.Sort(Items,
            delegate (Item x, Item y) { return y.rate.CompareTo(x.rate); });

            Double TotalValue = 0;

            for (int i = 0; i < size; i++)
            {
                long weight = Items[i].weight;
                if (!(capacity - weight < 0))
                {
                    capacity -= weight;
                    TotalValue += Items[i].value;
                }
                else
                {
                    TotalValue += capacity * Items[i].rate;
                    return (long)(TotalValue);
                }
            }

            return (long)TotalValue;
        }



    }

    public class Item
    {
        public long weight;
        public long value;
        public float rate;

        public Item(long weight, long value)
        {
            this.weight = weight;
            this.value = value;
            this.rate = (float)value / weight;
        }
    }


}
