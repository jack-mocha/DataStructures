using System;
using DataStructures.DisjointSet;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var uf = new FastFind(10);
            uf.Union(0, 1);
            uf.Union(0, 2);
            uf.Union(1, 3);

            uf.Union(4, 8);
            uf.Union(5, 6);
            uf.Union(5, 7);

            Console.WriteLine(uf.IsConnected(0, 3));
            Console.WriteLine(uf.IsConnected(0, 4));
            Console.WriteLine(uf.IsConnected(0, 9));
            uf.Union(1, 8);
            Console.WriteLine(uf.IsConnected(3, 8));
        }
    }
}
