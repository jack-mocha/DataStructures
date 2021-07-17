using DataStructures.Queues;
using System;
using System.Collections.Generic;

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

            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            var rq = new QueueReverser();
            rq.Reverse(q, 0);
        }
    }
}
