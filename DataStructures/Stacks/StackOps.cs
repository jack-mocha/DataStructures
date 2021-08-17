using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackOps
    {
        public void SortAscRecursive(Stack<int> stk)
        {
            if (stk.Count > 0)
            {
                var temp = stk.Pop();
                SortAscRecursive(stk);
                InsertAsc(stk, temp);
            }
        }

        private void InsertAsc(Stack<int> stk, int x)
        {
            if (stk.Count == 0)
                stk.Push(x);
            else
            {
                var temp = stk.Pop();
                if (x >= temp)
                {
                    stk.Push(temp);
                    stk.Push(x);
                }
                else
                {
                    InsertAsc(stk, x);
                    stk.Push(temp);
                }
            }
        }

        public void ReverseRecursive(Stack<int> stk)
        {
            if(stk.Count > 0)
            {
                var temp = stk.Pop();
                ReverseRecursive(stk);
                InsertAtBottom(stk, temp);
            }

        }

        private void InsertAtBottom(Stack<int> stk, int x)
        {

            if (stk.Count == 0)
                stk.Push(x);
            else
            {
                var temp = stk.Pop();
                InsertAtBottom(stk, x);
                stk.Push(temp);
            }
        }
    }
}
