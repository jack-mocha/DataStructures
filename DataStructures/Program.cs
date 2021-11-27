using DataStructures.Lists;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(2);
            list.AddLast(1);
            var res = list.IsPalindrome();
            Console.WriteLine(res);
        }
    }
}
