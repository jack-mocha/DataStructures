using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class PriorityQueue
    {
        private int[] _arr;
        private int _count;

        public PriorityQueue(int size)
        {
            _arr = new int[size];
        }

        public void Enqueue(int item)
        {
            if (IsFull())
                throw new InvalidOperationException();

            var i = ShiftItemsToInsert(item);
            _arr[i] = item;
            _count++;
        }

        private int ShiftItemsToInsert(int item)
        {
            int i;
            for(i = _count - 1; i >=0; i--)
            {
                if (_arr[i] > item)
                    _arr[i + 1] = _arr[i];
                else
                    break;
            }

            return i + 1;
        }

        private bool IsEmpty()
        {
            return _count == 0;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var item = _arr[--_count];
            _arr[_count] = 0;

            return item;
        }

        private bool IsFull()
        {
            return _count == _arr.Length;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[");

            for(int i = 0; i < _count; i++)
            {
                builder.Append(_arr[i]);

                if (i < _count - 1)
                    builder.Append(", ");
            }

            builder.Append("]");

            return builder.ToString();
        }
    }
}
