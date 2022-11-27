using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Generator
{
    public class Map
    {
        static void Main(string[] args)
        {
            // declaring and initializing 2D Array

            int[,] map = new int[,]
            {

                {1,2,3}, // row 0
                {4,5,6}, // row 1
                {7,8,9}  // row 2

            };

            // exercise: trying to get 7 to print
            Console.WriteLine("value is {0}", map[2,0]);
            Console.ReadKey();
        }
    }
}

