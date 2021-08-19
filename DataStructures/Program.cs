using DataStructures.Queues;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new QueueOps();
            var q = new Queue<int>(new int[] { 1, 2, 3, 4, 5 });
            o.ReverseFirstKElements(q, 3);
            o.Print(q);
        }
    }
}
