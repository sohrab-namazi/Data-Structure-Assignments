using System;
using System.Collections.Generic;
using Priority_Queue;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            Tuple<long, long>[] Result = new Tuple<long, long>[jobDuration.Length];
            SimplePriorityQueue<Task> PQ = new SimplePriorityQueue<Task>();

            for (long i = 0; i < jobDuration.Length; i++)
            {
                if (i < threadCount)
                {
                    PQ.Enqueue(new Task(0, jobDuration[i], i), jobDuration[i]);
                    Result[i] = new Tuple<long, long>(i, 0);
                }
                else
                {
                    Task Job = PQ.Dequeue();
                    Result[i] = new Tuple<long, long>(Job.ThreadNumber, Job.StartTime);
                    PQ.Enqueue(new Task(Job.FinishTime, Job.FinishTime + jobDuration[i], Job.ThreadNumber), Job.FinishTime + jobDuration[i]);
                }
            }

            return Result;
            
            
        }

        public class Task
        {
            public long StartTime;
            public long FinishTime;
            public long ThreadNumber;

            public Task(long StartTime, long FinishTime, long ThreadNumber)
            {
                this.StartTime = StartTime;
                this.FinishTime = FinishTime;
                this.ThreadNumber = ThreadNumber;
            }

        }
    }
}
