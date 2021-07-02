using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class Expression
    {
        public bool IsBalanced(string input)
        {
            var dictionary = new Dictionary<char, char>()
            {
                { '{', '}'},
                { '[', ']'},
                { '(', ')'},
                { '<', '>'}
            };

            var stk = new Stack<char>();

            foreach(var i in input)
            {
                if (dictionary.ContainsKey(i))
                    stk.Push(i);
                
                if(dictionary.ContainsValue(i))
                {
                    if (stk.Count == 0)
                        return false;

                    var top = stk.Pop();
                    if (dictionary[top] != i)
                        return false;
                }
            }

            return stk.Count == 0;
        }
    }
}
