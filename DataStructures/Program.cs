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
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            stk.Push(4);
            s.ReverseRecursive(stk);
        }
    }
}
