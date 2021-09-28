using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 50,30,40,20,10,80,70,9,8,7,6,35,37,100 };
            var heap = new MinHeap();
            heap.Insert(50, 50);
            heap.Insert(20, 20);
            heap.Insert(40, 40);
            heap.Insert(10, 10);
            heap.Remove();
            heap.Remove();
            heap.Print();
        }
    }
}
