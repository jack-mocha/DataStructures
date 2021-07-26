using DataStructures.Lists;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new SinglyLinkedList();
            lst.AddLast(1);
            lst.AddLast(2);
            lst.AddLast(3);
            lst.AddLast(4);
            lst.AddLast(5);
            lst.Print();
            lst.ShiftLinkedList(-1);
            lst.Print();
        }
    }
}
