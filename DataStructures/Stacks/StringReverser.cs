using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            if (input == null)
                throw new ArgumentException();

            var stk = new Stack<char>();
            foreach (var i in input)
                stk.Push(i);

            var builder = new StringBuilder(input.Length);
            while (stk.Count != 0)
                builder.Append(stk.Pop());

            return builder.ToString();
        }
    }
}
