using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".NET Lab.work #1. Option #16");
            Console.WriteLine("Point 1:");
            Console.WriteLine("Enter the size of the generating array:");
            int N_VECTOR = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Source generated array:");
            var numbers = GenerateVector(N_VECTOR);
            var posCount = 0;
            var lastZeroPos = -1;
            var sumAfterLastZero = 0.0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0) posCount++;

                if (numbers[i] == 0)
                {
                    lastZeroPos = i;
                    sumAfterLastZero = 0.0;
                }

                if (lastZeroPos != -1 & i > lastZeroPos)
                {
                    sumAfterLastZero += numbers[i];
                }
                Console.Write(string.Format("{0:f2}", numbers[i]) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Count of positive numbers is - " + posCount);
            Console.WriteLine("Sum of numbers ater last zero - " + string.Format("{0:f2}", sumAfterLastZero));
            Console.WriteLine();

            Console.WriteLine("The sorted array where elements with whole part less or equal than 1 are situated firstly:");
            Array.Sort(numbers, (a, b) =>
            {
                if (a == b) return 0;
                a = Math.Abs(a); b = Math.Abs(b);
                

                if (a <= 1 & b > 1)
                    return -1;
                else if (b <= 1 & a > 1)
                    return 1;

                return 0;

            });

            for(var i = 0; i < numbers.Length; i++)
            {
                Console.Write(string.Format("{0:f2}", numbers[i]) + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
          

        }

        private static double[] GenerateVector(int n)
        {
            var array = new double[n];
            var randomGen = new Random();


            for (var i = 0; i < array.Length; i++)
            {
                array[i] = randomGen.NextDouble() * (randomGen.Next(6) - 3);

            }
            return array;
        }

    }
}
