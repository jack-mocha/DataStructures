using System;
using DataStructures.DisjointSet;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new FindProvinces();
            var arr = new int[15][] {
                new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1 },
                new int[] { 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 } };

            var res = alg.Execute(arr);
            Console.WriteLine(res);
        }
    }
}
