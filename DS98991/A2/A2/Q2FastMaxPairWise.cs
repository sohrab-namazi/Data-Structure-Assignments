using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            long first = 0;
            long second = 0;
            int size = numbers.Length;
            List<long> nums = numbers.ToList();
            for (int i = 0; i < size; i++)
            {
                if (numbers[i] > first)
                {
                    first = numbers[i];

                }
            }

            nums.Remove(first);
            
            for (int j = 0; j < size - 1; j++)
            {
                if (nums[j] > second)
                {
                    second = nums[j];
                }
            }


            return first * second;
        }
    }
}
