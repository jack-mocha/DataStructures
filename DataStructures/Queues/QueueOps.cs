using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class QueueOps
    {
        public void ReverseFirstKElements(Queue<int> queue, int k)
        {
            var stk = new Stack<int>();
            for (int i = 0; i < k; i++)
                stk.Push(queue.Dequeue());

            while (stk.Count > 0)
                queue.Enqueue(stk.Pop());

            for (int i = 0; i < queue.Count - k; i++)
                queue.Enqueue(queue.Dequeue());
        }

        public void Reverse(Queue<int> queue)
        {
            if(queue.Count > 0)
            {
                var temp = queue.Dequeue();
                Reverse(queue);
                queue.Enqueue(temp);
            }
        }

        public void Print(Queue<int> queue)
        {
            var builder = new StringBuilder();
            builder.Append("[");
            foreach (var q in queue)
                builder.Append(q + " ");

            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
    }
}
