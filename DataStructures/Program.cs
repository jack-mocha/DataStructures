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
            var q = new Queue<int>(new int[] { 11, 5, 4, 21 });
            o.SortWithoutExtraSpace(q);
            o.Print(q);
        }
    }
}
