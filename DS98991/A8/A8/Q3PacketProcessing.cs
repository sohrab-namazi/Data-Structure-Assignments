using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            long Capacity = bufferSize;
            long k = 0;
            long Size = arrivalTimes.Length;
            Queue<Item> queue = new Queue<Item>();
            long[] FinishTimes = new long[Size];
            long[] ResultTimes = new long[Size];

            if (bufferSize == 0)
            {
                for (long i = 0; i < Size; i++)
                {
                    ResultTimes[i] = -1;
                }
                return ResultTimes;
            }

            if (Size == 0)
            {
                return new long[] { };
            }


            queue.Enqueue(new Item(arrivalTimes[0], arrivalTimes[0] + processingTimes[0]));

            ResultTimes[0] = arrivalTimes[0];
            Capacity--;

            for (long i = 1; i < Size; i++)
            {
                while (queue.Count != 0 && queue.Peek().FinishTime <= arrivalTimes[k])
                {
                    Item item = queue.Dequeue();
                    if (k != 0)
                    {
                        ResultTimes[k] = Math.Max(arrivalTimes[k], ResultTimes[k - 1] + processingTimes[k - 1]);
                        k++;
                        Capacity++;
                    }
                    else
                    {
                        ResultTimes[k] = arrivalTimes[k];
                        k++;
                        Capacity++;
                    }

                }
                if (Capacity > 0)
                {
                    queue.Enqueue(new Item(arrivalTimes[i], arrivalTimes[i] + processingTimes[i]));
                    Capacity--;
                }
                else
                {
                    ResultTimes[k] = -1;
                    continue;
                }
            }

            for (long j = k; j < Size; j++)
            {
                if (j != 0)
                {
                    ResultTimes[j] = Math.Max(ResultTimes[j - 1] + processingTimes[j - 1], arrivalTimes[j]);
                }
                else
                {
                    ResultTimes[j] = arrivalTimes[j];
                }
            }
            return ResultTimes;
        }
        public class Item
        {
            public long StartTime;
            public long FinishTime;

            public Item() { }
            public Item(long StartTime, long FinishTime)
            {
                this.StartTime = StartTime;
                this.FinishTime = FinishTime;
            }
        }
    }
}