using System;
using System.Collections.Generic;
using Priority_Queue;

namespace A9
{
    class Program
    {




        static void Main(string[] args)
        {
            Console.WriteLine(Solve(25, 10, new long[] {20, 10, 22, 23 }, new long[] {5, 10, 2, 4}));

        }

        public static long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            SimplePriorityQueue<Node> PQ = new SimplePriorityQueue<Node>();
            long Energy = initialEnergy;
            long[] Energies = new long[initialDistance + 1];
            long Counter = 0;

            for (long i = 0; i < distance.Length; i++)
            {
                Energies[distance[i]] = food[i];
            }

            //     Energies[20] = initialEnergy;

            for (long i = initialDistance - 1; i > 0; i--)
            {
                Energy--;

                if (Energy == 0 && PQ.Count > 0)
                {
                    long E = PQ.Dequeue().Energy;
                    Energy += E;
                    Counter++;
                }

                if (Energies[i] > 0 && Energy > 0)
                {
                    PQ.Enqueue(new Node(i, Energies[i]), -Energies[i]);
                }

                if (Energy == 0 && PQ.Count == 0)
                {
                    return -1;
                }


            }
            return Counter;

        }
        //    for (long i = 0; i<distance.Length; i++)
        //    {
        //        Energies[distance[i]] = food[i];
        //    }

        //    for (long i = 0; i<distance.Length; i++)
        //    {
        //        Energy--;

        //        if (Energy > 0 && Energies[i] > 0)
        //        {
        //            PQ.Enqueue(new Node(food[i], Energies[i]), -Energies[i]);
        //        }


        //        if (Energy == 0 && PQ.Count > 0)
        //        {
        //            Energy += PQ.Dequeue().Energy;
        //            Counter++;
        //        }

        //        if (Energy == 0 && PQ.Count == 0)
        //        {

        //            return -1;
        //        }


        //    }


        //    return Counter;

        //}

        //public class Node
        //{
        //    public long Distance;
        //    public long Energy;

        //    public Node(long Distance, long Energy)
        //    {
        //        this.Distance = Distance;
        //        this.Energy = Energy;
        //    }
        //}

    }
}