using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2b
{
    public class Q2HashTableAttack : Processor
    {
        public Q2HashTableAttack (string testDataName) : base(testDataName) 
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public static string[] Produce(long n, long Capacity)
        {
            long p = 1;
            string[] result = new string[n];
            string ss = "";
            for (long i = 0; i < n; i++)
            {
                int uu = new Random().Next(50);
                char rr = AllChars[uu];
                ss += rr;
            }
            long o = GetBucketNumber(ss, Capacity);
            while (p < n)
            {
                string s = "";
                for (long i = 0; i < n; i++)
                {
                    int uu = new Random().Next(50);
                    char rr = AllChars[uu];
                    s += rr;
                }
                if (GetBucketNumber(s, Capacity) == GetBucketNumber(ss, Capacity))
                {
                    result[p] = s;
                    p++;
                }
            }
            

            return result;
            


        }

        public string[] Solve(long bucketCount)
        {
             char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

             char[] CapChars = Enumerable
                .Range(0, 26)
                .Select(n => (char)('A' + n))
                .ToArray();

             char[] Numbers = Enumerable
                .Range(0, 10)
                .Select(n => (char)('0' + n))
                .ToArray();
            long Capacity = Convert.ToInt64(0.9 * bucketCount);
            string[] words = new string[Capacity];
            char[] AllChars =
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
            long a = CapChars[0] + AllChars[0] + LowChars[0] + AllChars[0];
            //words[0] = new string(new char[] { CapChars[0] , AllChars[0] , LowChars[0] , AllChars[0] });
            //long i = 1;

            return Produce(3, Capacity);
            

            
        }
        //public static List<string> strings(long i)
        //{
        //    List<string> strings = new List<string>();
            
        //}

        
        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars = 
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
