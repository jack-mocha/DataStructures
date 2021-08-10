using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class Expression
    {
        public string PrefixToPostfix(string input)
        {
            var stk = new Stack<string>();
            for(int i = input.Length - 1; i >= 0; i --)
            {
                var c = input[i];
                if (Char.IsLetter(c))
                    stk.Push(c.ToString());
                else if(IsOperator(c))
                {
                    var first = stk.Pop();
                    var second = stk.Pop();
                    var temp = first + second + c;
                    stk.Push(temp);
                }
            }

            return stk.Pop();
        }

        public string PrefixToInfix(string input)
        {
            var stk = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var c = input[i];
                if (Char.IsLetterOrDigit(c))
                    stk.Push(c.ToString());
                else if (IsOperator(c))
                {
                    var first = stk.Pop();
                    var second = stk.Pop();
                    var temp = "(" + first + c + second + ")";
                    stk.Push(temp);
                }
            }

            return stk.Pop();
        }

        public bool IsOperator(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                    return true;
            }
            return false;
        }

        public string InfixToPostfix(string input)
        {
            var stk = new Stack<char>();
            var builder = new StringBuilder();
            foreach (var c in input)
            {
                if (Char.IsLetterOrDigit(c))
                    builder.Append(c);
                else if (c == '(')
                    stk.Push(c);
                else if (c == ')')
                {
                    while (stk.Count > 0 && stk.Peek() != '(')
                        builder.Append(stk.Pop());
                    stk.Pop();
                }
                else
                {
                    while (stk.Count > 0 && Prec(stk.Peek()) >= Prec(c)) //needs >=. Also '(' returns -1 from GetWeight() when it is hit 
                        builder.Append(stk.Pop());
                    stk.Push(c);
                }
            }

            while (stk.Count > 0)
                builder.Append(stk.Pop());

            return builder.ToString();
        }

        public int Prec(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }

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
