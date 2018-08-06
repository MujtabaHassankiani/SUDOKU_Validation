using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] jaggedArray = new int[9, 9]
                 {
                {7,8,4,  1,5,9,  3,2,6},
                {5,3,9,  6,7,2,  8,4,1},
                {6,1,2,  4,3,8,  7,5,9},
                {9,2,8,  7,1,5,  4,6,3},
                {3,5,7,  8,4,6,  1,9,2},
                {4,6,1,  9,2,3,  5,8,7},
                {8,7,6,  3,9,4,  2,1,5},
                {2,4,3,  5,6,1,  9,7,8},
                {1,9,5,  2,8,7,  6,3,4}
            };


            if (ValidateRules(jaggedArray))
                ValidateSoduku(jaggedArray);
            else
                Console.WriteLine("Validation failed.");
            Console.Read();

        }
        static bool checkArrayStatus(int[] rSumArray, int[] cSumArray, int[] boxSumArray)
        {
            int i = 0;

            bool sudukoStatus = true;

            while (i < 9)
            {
                if (rSumArray[i] != 45 || cSumArray[i] != 45 || rSumArray[i] != 45)
                {
                    sudukoStatus = false;
                    break;
                }
                i++;
            }
            return sudukoStatus;
        }

        public static bool ValidateRules(int[,] sMatrix)
        {
            foreach (var v in sMatrix)
            {
                if (v <= 0)
                    return false;
            }
            return true;
        }

        public static void ValidateSoduku(int[,] sMatrix)
        {

            int rSum = 0;

            int cSum = 0;

            int[] rSumArray = new int[9];

            int[] cSumArray = new int[9];

            int[] boxSumArray = new int[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    rSum += sMatrix[i, j];
                    cSum += sMatrix[j, i];
                }
                rSumArray[i] = rSum;
                cSumArray[i] = cSum;
                rSum = 0;
                cSum = 0;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i <= 2 && j <= 2)
                    {
                        boxSumArray[0] += sMatrix[i, j];
                    }
                    if (i <= 2 && (j >= 3 && j <= 5))
                    {
                        boxSumArray[1] += sMatrix[i, j];
                    }
                    if (i <= 2 && (j >= 6 && j <= 8))
                    {
                        boxSumArray[2] += sMatrix[i, j];
                    }
                    if ((i >= 3 && i <= 5) && (j <= 2))
                    {
                        boxSumArray[3] += sMatrix[i, j];
                    }
                    if ((i >= 3 && i <= 5) && (j >= 3 && j <= 5))
                    {
                        boxSumArray[4] += sMatrix[i, j];
                    }
                    if ((i >= 3 && i <= 5) && (j >= 6 && j <= 8))
                    {
                        boxSumArray[5] += sMatrix[i, j];

                    }
                    if ((i >= 6) && (j <= 2))
                    {
                        boxSumArray[6] += sMatrix[i, j];
                    }
                    if ((i >= 6) && (j >= 3 && j <= 5))
                    {
                        boxSumArray[7] += sMatrix[i, j];
                    }
                    if ((i >= 6) && (j >= 6))
                    {
                        boxSumArray[8] += sMatrix[i, j];
                    }
                }
            }

            if (checkArrayStatus(rSumArray, cSumArray, boxSumArray))
            {
                Console.WriteLine("The matrix is sudoku compliant");
            }
            else
            {
                Console.WriteLine("The matrix is not sudoku compliant");
            }
        }
    }

}
