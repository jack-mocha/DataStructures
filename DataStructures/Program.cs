using System;
using DataStructures.Stacks;
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var stk = new StackList();
            stk.Push(1);
            stk.Push(2);
            var f = stk.Pop();
            f = stk.Pop();
            var r = stk.IsEmpty();
        }
    }
}
