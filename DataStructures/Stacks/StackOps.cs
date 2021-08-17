using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackOps
    {
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
