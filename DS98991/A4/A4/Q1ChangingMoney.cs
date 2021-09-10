using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            int[] coins = new int[3] { 10, 5, 1 };
            long CoinCounts = 0;
            CoinCounts += money / 10;
            money = money % 10;
            if (money < 10 && money >= 5)
            {
                CoinCounts++;
                money -= 5;
            }
            CoinCounts += money;
            return CoinCounts;
        }
    }
}
