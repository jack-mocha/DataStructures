using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();
        private int top;

        public void Push(int item)
        {
            queue1.Enqueue(item);
            top = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            while(queue1.Count > 1)
            {
                top = queue1.Dequeue();
                queue2.Enqueue(top);
            }

            var item = queue1.Dequeue();
            SwapQueues();

            return item;
        }

        private void SwapQueues()
        {
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        public bool IsEmpty()
        {
            return queue1.Count == 0;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return top;
        }
    }
}
