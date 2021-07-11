using DataStructures.Queues;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var que = new PriorityQueue(5);
            que.Enqueue(1);
            que.Enqueue(5);
            que.Enqueue(2);
            que.Enqueue(0);
            que.Enqueue(10);
            Console.WriteLine(que.ToString());
            que.Dequeue();
            que.Dequeue();
            que.Dequeue();
            Console.WriteLine(que.ToString());

        }
    }
}
