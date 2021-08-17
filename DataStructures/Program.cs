using System;
using System.Collections;
using DataStructures.Stacks;
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 1, 1, 2, 2, 2, 2, 11, 3, 3 };
            var s = new StockSpan();
            var res = s.NextGreaterFrequency(arr);
        }
    }
}
