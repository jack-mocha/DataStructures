using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var pq = new PriorityQueueWithHeap();
            pq.Enqueue(10);
            pq.Enqueue(30);
            pq.Enqueue(20);
            pq.Enqueue(15);
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
            Console.WriteLine(pq.Dequeue());
        }
    }
}
