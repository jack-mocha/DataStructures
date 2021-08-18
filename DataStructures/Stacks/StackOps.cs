using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackOps
    {
        public bool IsStackSortable(int[] input)
        {
            var stk = new Stack<int>();
            var expected = 1;

            for(int i = 0; i < input.Length; i++)
            {
                var front = input[i];
                if(front == expected)
                    expected++;
                else
                {
                    if (stk.Count != 0 && stk.Peek() < front)
                        return false;
                    stk.Push(front);
                }

                while(stk.Count != 0 && stk.Peek() == expected)
                {
                    stk.Pop();
                    expected++;
                }
            }

            if (expected - 1 == input.Length && stk.Count == 0)
                return true;

            return false;
        }

        public void DeleteMid(Stack<int> st, int n, int curr)
        {
            if (st.Count == 0)
                return;

            var x = st.Pop();
            DeleteMid(st, n, curr + 1);
            
            if (curr != n / 2)
                st.Push(x);
        }

        public Stack<int> SortAscUseTempStack(Stack<int> stk)
        {
            var tempStk = new Stack<int>();

            while(stk.Count > 0)
            {
                var temp = stk.Pop();
                while(tempStk.Count > 0 && tempStk.Peek() > temp)
                    stk.Push(tempStk.Pop());
                tempStk.Push(temp);
            }

            return tempStk;
        }

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
