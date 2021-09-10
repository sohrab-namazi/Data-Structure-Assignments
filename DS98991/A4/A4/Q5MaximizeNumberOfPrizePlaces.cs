using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            int pointer = 1;
            List<long> answer = new List<long>();
            bool flag = true;

            while (flag)
            {
                if (n - pointer == 0)
                {
                    answer.Add(pointer);
                    flag = false;
                }

                else if (n - pointer > 0)
                {
                    answer.Add(pointer);
                    n -= pointer;
                    pointer++;
                }

                else
                {
                    n += answer[answer.Count - 1];
                    answer.RemoveAt(answer.Count - 1);
                }
            }
            return answer.ToArray();
        }
    }
}

