using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class MinStack
    {
        private Stack<int> stk = new Stack<int>();
        private Stack<int> minStk = new Stack<int>();

        public void Push(int item)
        {
            stk.Push(item);

            if (minStk.Count == 0)
                minStk.Push(item);
            else if (item < minStk.Peek())
                minStk.Push(item);
        }

        public int Pop()
        {
            if (stk.Count == 0)
                throw new InvalidOperationException();

            var item = stk.Pop();
            if (item == minStk.Peek())
                minStk.Pop();

            return item;
        }

        public int Min()
        {
            return minStk.Peek();
        }
    }
}
