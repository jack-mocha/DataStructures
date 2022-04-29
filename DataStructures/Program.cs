using System;
using DataStructures.DisjointSet;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new ValidTree();
            //No cycle
            var arr = new int[4][] {
                new int[] {0,1},
                new int[] {0,2},
                new int[] {0,4},
                new int[] {4,3}
            };

            //Has cycle
            var arr2 = new int[5][] {
                new int[] {0,1},
                new int[] {0,2},
                new int[] {0,4},
                new int[] {4,3},
                new int[] {2,3}
            };

            var res = alg.Execute(5, arr);
            Console.WriteLine(res);
        }
    }
}
