using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class QueueOps
    {
        public int MinIndex(Queue<int> q, int sortedIndex)
        {
            int min_index = -1;
            int min_val = int.MaxValue;
            int n = q.Count;
            for (int i = 0; i < n; i++) //When this for loop is done, every item goes back to the origial order
            {
                int curr = q.Dequeue();
                if (curr <= min_val && i <= sortedIndex)
                {
                    min_index = i;
                    min_val = curr;
                }
                q.Enqueue(curr); 
            }
            return min_index;
        }

        public void InsertMinToRear(Queue<int> q, int min_index)
        {
            int min_val = 0;
            int n = q.Count;
            for (int i = 0; i < n; i++) //will put the queue back to original order.
            {
                int curr = q.Dequeue();
                if (i != min_index)
                    q.Enqueue(curr);
                else
                    min_val = curr; //Don't enqueue until the loop is done.
            }
            q.Enqueue(min_val);
        }

        public void SortWithoutExtraSpace(Queue<int> q)
        {
            for (int i = 1; i <= q.Count; i++)
            {
                int min_index = MinIndex(q, q.Count - i); //- i sets sortedIndex
                InsertMinToRear(q, min_index);
            }
        }

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
