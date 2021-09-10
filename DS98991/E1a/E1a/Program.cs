using System;
using System.Collections.Generic;

namespace E1a
{
    class Program
    {
        static void Main(string[] args)
        {

           





           long a = Solve(23, 27);

            Console.WriteLine(a);
           



        }

        public static long Solve(long nr, long dr)
        {

            if (nr % dr == 0) return 1;
            List<long> answers = new List<long>();
            Fraction fraction = new Fraction(nr, dr);

            int i = 1;



            while (true)
            {
                Fraction secondFraction = new Fraction(1, i);

                if (Fraction.subtract(fraction, secondFraction).a > 0)
                {
                    answers.Add(i);
                    i++;
                    fraction = Fraction.subtract(fraction, secondFraction);

                }

                else if (Fraction.subtract(fraction, secondFraction).a == 0)
                {
                    answers.Add(i);
                    i++;
                    fraction = Fraction.subtract(fraction, secondFraction);
                    break;

                }

                else
                {
                    i++;
                    continue;
                }


            }

            Console.WriteLine(answers[answers.Count - 1]);
            return answers[answers.Count - 1];
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
                long gcd = GCD(a, b);

                return new Fraction(a / gcd, b / gcd);



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
