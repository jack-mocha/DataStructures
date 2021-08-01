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
            c.Push(1);
            c.Push(2);
            c.Push(3);
            c.Delete(2);


            var lst = new LinkedList();
            lst.AddLast(2);
            lst.AddLast(2);
            lst.AddLast(2);
            lst.SegregateEvenAndOdd();
            lst.Print();
        }
    }
}
