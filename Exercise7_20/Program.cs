using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Generate an array of 10,000 random numbers from zero to four.Report the percentage
//of each of the numbers, zero, one, two, three, and four in the array.

namespace Exercise7_20
{
    class Program
    {
        static void Main(string[] args)
        {
            //create array to hold randoms
            int[] randomArray = new int[10000];

            //create Random number instance
            Random random = new Random();

            //track totals for each random number
            int zeroCount = 0;
            int oneCount = 0;
            int twoCount = 0;
            int threeCount = 0;
            int fourCount = 0;

            //loop to put random number into each array location
            for(int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(5);
            }

            //loop to count random numbers in each location
            for(int i = 0; i < randomArray.Length; i++)
            {
                if (randomArray[i] == 0)
                {
                    zeroCount++;
                }else if (randomArray[i] == 1)
                {
                    oneCount++;
                }else if (randomArray[i] == 2)
                {
                    twoCount++;
                }else if (randomArray[i] == 3)
                {
                    threeCount++;
                }else if (randomArray[i] == 4)
                {
                    fourCount++;
                }
            }

            //calculate percentage of each number
            double zeroResult = ((double)zeroCount / 10000) * 100;
            double oneResult = ((double)oneCount / 10000) * 100;
            double twoResult = ((double)twoCount / 10000) * 100;
            double threeResult = ((double)threeCount / 10000) * 100;
            double fourResult = ((double)fourCount / 10000) * 100;

            //display result
            Console.WriteLine("Metrics of Random Number Array");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Zero: \t" + zeroResult + "%");
            Console.WriteLine("One: \t" + oneResult + "%");
            Console.WriteLine("Two: \t" + twoResult + "%");
            Console.WriteLine("Three: \t" + threeResult + "%");
            Console.WriteLine("Four: \t" + fourResult + "%");
            Console.WriteLine("--------------END--------------");


        }
    }
}
