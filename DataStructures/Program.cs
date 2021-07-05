using DataStructures.Arrays;
using DataStructures.Arrays.Example1;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ArrayBasic();
            a.Note();

            int[][] arr = new int[3][]
            {
                new int[] {1, 2},
                new int[] {3, 4},
                new int[] {5, 6}
            };
            var ja = new JaggedArray();
            System.Console.WriteLine(ja.ToString(arr));
            var n = ja.MatrixReshape(arr, 2, 3);
            System.Console.WriteLine(ja.ToString(n));
            var n2 = ja.MatrixReshapeBetter(arr, 2, 3);
            System.Console.WriteLine(ja.ToString(n2));
            ja.Note();
        }


    }
}
