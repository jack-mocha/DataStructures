using DataStructures.Lists;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new SinglyLinkedList();
            //lst.AddLast(1);
            //lst.AddLast(3);
            //lst.AddLast(4);
            var l2 = new SinglyLinkedList();
            //l2.AddLast(2);
            //l2.AddLast(5);
            //l2.AddLast(10);
            lst.SortedMerge(null);
            lst.Print();
        }
    }
}
