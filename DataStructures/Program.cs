using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 5, 3, 10, 1, 4, 2 };
            var heap = new HeapSort();
            heap.SortDesc(items);
            foreach (var i in items)
                Console.WriteLine(i);

            Console.WriteLine("==========");

            heap.SortAsc(items);
            foreach (var i in items)
                Console.WriteLine(i);
        }
    }
}
