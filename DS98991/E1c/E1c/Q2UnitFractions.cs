using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;

namespace E1c
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {

            if (nr % dr == 0) return 1;

            if (nr > dr)
            {
                nr = nr % dr;
                long gcd2 = GCD(nr, dr);
                nr /= gcd2;
                dr /= gcd2;

            }



            long gcd = GCD(nr, dr);
            Fraction fraction = new Fraction(nr / gcd, dr / gcd);

            int i = 1;

            while (true)
            {

                if (fraction.b % fraction.a == 0) return (fraction.b / fraction.a);
                Fraction subtracted = Fraction.subtract(fraction, new Fraction(1, i));
                if (subtracted.a > 0)
                {
                    fraction = subtracted;
                    i++;
                    continue;
                }

                if (subtracted.a == 0)
                {
                    return i;
                }


                i++;

            }



        }

        public class Fraction
        {
            public long a;
            public long b;

            public Fraction(long a, long b)
            {
                this.a = a;
                this.b = b;
            }

            public static Fraction subtract(Fraction F1, Fraction F2)
            {
                long a = F2.b * F1.a - F1.b * F2.a;
                long b = F1.b * F2.b;

                if (a < 0) return new Fraction(-1, 1);
                

                return new Fraction(a, b);



            }


        }



        public static long GCD(long a, long b)
        {

            if (a < b) return GCD(b, a);
            if (b == 0) return a;

            return GCD(b, a % b);
        }




    }

   






}

