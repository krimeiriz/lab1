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
            Console.WriteLine("Point 2:");
            Console.WriteLine("Enter the size of the generating square matrix:");
            int N_MATRIX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The source generated matrix:");
            var matrix = GenerateMatrix(N_MATRIX);
            var matrixElements = new MatrixElement[matrix.Length * matrix.Length];
            var lineWithoutPositive = -1;

            for (var i = 0; i < matrix.Length; i++)
            {
                var lineHasPositive = false;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    ref var element = ref matrixElements[i * matrix.Length + j];
                    element = new MatrixElement();
                    element.row = i;
                    element.col = j;
                    element.value = matrix[i][j];

                    if (matrix[i][j] > 0) lineHasPositive = true;
                    Console.Write("{0,4}", matrix[i][j]);
                }
                if (!lineHasPositive & lineWithoutPositive == -1)
                    lineWithoutPositive = i + 1;
                Console.WriteLine();
            }
            if(lineWithoutPositive == -1)
            {
                Console.WriteLine("There are not lines without positive numbers.");
            }
            else
            {
                Console.WriteLine("The first line without positive number is — " + lineWithoutPositive);
            }
            Console.WriteLine();
            Console.WriteLine("The changed matrix where max elements were moved to the main diagonal in descending:");
            Array.Sort(matrixElements, (a, b) => b.value - a.value);
            
            for(var i = 0; i < matrix.Length; i++)
            { 
                swapCell(ref matrix, ref matrixElements, i);
            }

            for(var i = 0; i < matrix.Length; i++)
            {
                for(var j = 0; j < matrix.Length; j++)
                {
                    Console.Write("{0, 4}", matrix[i][j]);
                }
                Console.WriteLine();
            }

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

        private static int[][] GenerateMatrix(int n)
        {
            var array = new int[n][];

            var randomGen = new Random();


            for (var i = 0; i < array.Length; i++)
            {
                array[i] = new int[n];
                for (var j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = randomGen.Next(100)  - 50;
                }

            }
            return array;
        }

        private static void swapCell(ref int[][] matrix, ref MatrixElement[] matrixElements, int index)
        {
            int temp = matrix[matrixElements[index].row][matrixElements[index].col];
            matrix[matrixElements[index].row][matrixElements[index].col] = matrix[index][index];
            matrix[index][index] = temp;

            int i;
            for(i = 0; i< matrixElements.Length; i++)
            {
                if (matrixElements[i].col == index & matrixElements[i].row == index)
                {
                    break;
                }
                    
            }

            matrixElements[i].row = matrixElements[index].row;
            matrixElements[i].col = matrixElements[index].col;

            matrixElements[index].col = index;
            matrixElements[index].row = index;
        }

        struct MatrixElement
        {
            public int row;
            public int col;
            public int value;
        }
    }
}
