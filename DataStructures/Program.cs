using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Stacks;
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new StackOps();
            var stk = new Stack<int>();
            stk.Push(30);
            stk.Push(-5);
            stk.Push(18);
            stk.Push(14);
            stk.Push(-3);
            s.SortAscRecursive(stk);
        }
    }
}
