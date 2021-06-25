using DataStructures.Lists;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new LinkedList();
            lst.AddLast(1);
            lst.AddLast(2);
            lst.AddLast(3);
            lst.AddFirst(0);
        }
    }
}
