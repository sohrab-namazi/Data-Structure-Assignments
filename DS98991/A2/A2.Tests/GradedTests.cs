using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Q1NaiveMaxPairWise q1 = new Q1NaiveMaxPairWise("");
            Q2FastMaxPairWise q2 = new Q2FastMaxPairWise("");
            int size = new Random().Next(2, 100);
            long[] nums = new long[size];
            for (int i = 0; i < size; i++)
            {
                int n = new Random().Next(1000);
                nums[i] = n;
            }
            

            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.Elapsed.TotalSeconds < 5)
            {
                Assert.AreEqual(q1.Solve(nums), q2.Solve(nums));

            }


            
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}