using DataStructures.Queues;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var que = new StackQueue();

            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Dequeue();
            Console.WriteLine(que.Peek());
        }
    }
}
