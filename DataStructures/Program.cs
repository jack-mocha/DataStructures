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
            var q = new Queue<int>(new int[] { 11,12,13,14,15,16,17,18,19,20 });
            o.InterleaveFirstAdnSecHalf(q);
            o.Print(q);
        }
    }
}
