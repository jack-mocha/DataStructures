using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class QueueReverser
    {
        public void Reverse(Queue<int> queue, int k)
        {
            if (k < 0 || k > queue.Count)
                throw new InvalidOperationException();

            var stk = new Stack<int>();
            for(int i = 0; i < k; i++)
                stk.Push(queue.Dequeue());

            while(stk.Count != 0)
                queue.Enqueue(stk.Pop());

            for(int i = 0; i < queue.Count - k; i++)
                queue.Enqueue(queue.Dequeue());
        }
    }
}
