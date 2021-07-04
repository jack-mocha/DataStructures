using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackArray
    {
        private int[] _arr;
        private int _count;
        private int _size;

        public StackArray(int size)
        {
            _size = size;
            this._arr = new int[_size];
        }

        private bool IsFull()
        {
            return _count == _arr.Length;    
        }

        private void Expand()
        {
            var arr = new int[_count + _size];
            for (int i = 0; i < _arr.Length; i++)
                arr[i] = _arr[i];

            _arr = arr;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Push(int item)
        {
            if (IsFull())
                Expand();

            _arr[_count++] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var item = _arr[--_count];
            _arr[_count] = 0;

            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _arr[_count - 1];
        }


        private bool IsLastItem(int idx)
        {
            return idx == _count - 1;
        }

        public override string ToString()
        {
            var builder = new StringBuilder(_count);
            builder.Append("[");
            for(int i = 0; i < _count; i++)
            {
                builder.Append(_arr[i]);
                if (!IsLastItem(i))
                    builder.Append(", ");
            }

            builder.Append("]");
            
            return builder.ToString();
        }
    }
}
