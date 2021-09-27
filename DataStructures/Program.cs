using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 50,30,40,20,10,80,70,9,8,7,6,35,37,100 };
            //var items = new int[] { 5, 3, 8, 4, 1, 9 };
            //var items = new int[] { 5, 3, 4, 2, 1, 8 };
            var heap = new MaxHeap();
            heap.Heapify(items);
            foreach (var i in items)
                Console.WriteLine(i);
        }
    }
}
