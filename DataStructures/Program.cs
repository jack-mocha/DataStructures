using DataStructures.Queues;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new ArrayQueue(3);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Dequeue();
            Console.WriteLine(queue.ToString());
            queue.Dequeue();
            Console.WriteLine(queue.ToString());
            queue.Dequeue();
            Console.WriteLine(queue.ToString());
            queue.Dequeue();
            Console.WriteLine(queue.ToString());
            queue.Enqueue(2);
            Console.WriteLine(queue.ToString());
            queue.Enqueue(2);
            Console.WriteLine(queue.ToString());
            queue.Enqueue(2);
            Console.WriteLine(queue.ToString());
        }
    }
}
