using DataStructures.Lists;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new CircularLinkedList();
            c.PushHead(1);
            c.PushHead(2);
            c.PushHead(3);

            var lst = new LinkedList();
            lst.AddLast(2);
            lst.AddLast(2);
            lst.AddLast(2);
            lst.SegregateEvenAndOdd();
            lst.Print();
        }
    }
}
