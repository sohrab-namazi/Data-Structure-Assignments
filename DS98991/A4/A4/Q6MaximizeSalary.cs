using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public static string Solve(long n, long[] numbers)
        {
            List<long> NumbersList = numbers.ToList();
            string[] answers = new string[n];
            int i = 0;
            while (NumbersList.Count != 0)
            {
                string Max = "0";
                for (int j = 0; j < NumbersList.Count; j++)
                {
                    if (Comparing(Convert.ToString(NumbersList[j]), Max) > 0)
                    {
                        Max = Convert.ToString(NumbersList[j]);
                    }
                }
                NumbersList.Remove(Convert.ToInt64(Max));
                answers[i] = Max;
                i++;
            }
            string result = "";
            foreach (string answer in answers)
            {
                result += answer;
            }
            return result;
        }

        public static int Comparing(string a, string b)
        {
            string FirstCase = a + b;
            string SecondCase = b + a;

            int NumberA = Convert.ToInt32(FirstCase);
            int NumberB = Convert.ToInt32(SecondCase);



            if (NumberA > NumberB) return 1;

            return -1;


        }

      
    }
}

