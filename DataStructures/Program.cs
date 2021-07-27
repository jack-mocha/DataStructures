using DataStructures.Lists;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new LinkedList();
            lst.AddLast(1);
            //lst.AddLast(2);
            //lst.AddLast(3);
            //lst.AddLast(2);
            //lst.AddLast(2);
            var res = lst.IsPalindrome();
            Console.WriteLine(res);
            lst.Print();
        }
    }
}
