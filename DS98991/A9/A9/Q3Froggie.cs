using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            SimplePriorityQueue<Node> PQ = new SimplePriorityQueue<Node>();
            long Energy = initialEnergy;
            long[] Energies = new long[initialDistance];
            long Counter = 0;

            for (long i = 0; i < distance.Length; i++)
            {
                Energies[distance[i]] = food[i];
            }

            //     Energies[20] = initialEnergy;

            for (long i = initialDistance - 1; i > 0; i--)
            {
                Energy--;

                if (Energies[i] > 0 && Energy >= 0)
                {
                    PQ.Enqueue(new Node(i, Energies[i]), -Energies[i]);
                }

                if (Energy == 0 && PQ.Count > 0)
                {
                    long E = PQ.Dequeue().Energy;
                    Energy += E;
                    Counter++;
                }

                

                if (Energy == 0 && PQ.Count == 0)
                {
                    return -1;
                }


            }
            return Counter;
        }




        //for (long i = 0; i < distance.Length; i++)
        //{
        //    Energies[distance[i]] = food[i];
        //}

        //for (long i = 0; i < distance.Length; i++)
        //{
        //    Energy--;

        //    if (Energy > 0 && Energies[i] > 0)
        //    {
        //        PQ.Enqueue(new Node(food[i], Energies[i]), -Energies[i]);
        //    }


        //    if (Energy == 0 && PQ.Count > 0)
        //    {
        //        Energy += PQ.Dequeue().Energy;
        //        Counter++;
        //    }

        //    if (Energy == 0 && PQ.Count == 0)
        //    {

        //        return -1;
        //    }


        //}




    }

    public class Node
    {
        public bool Marked;
        public long Distance;
        public long Energy;
        public List<Node> Childs;



        public Node(long Distance, long Energy)
        {
            this.Distance = Distance;
            this.Energy = Energy;
        }
    }
}