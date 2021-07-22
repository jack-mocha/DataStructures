using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class ArrayQueue
    {
        private int[] _arr;
        private int _first;
        private int _last;
        private int _count;

        public ArrayQueue(int size)
        {
            _arr = new int[size];
            _first = 0;
            _last = 0;
            _count = 0;
        }

        private bool IsFull()
        {
            return _last == _arr.Length;
        }

        private bool IsEmpty()
        {
            return _first == _last;
        }

        private void Expand()
        {
            var newArr = new int[_count * 2];

            _arr = RepositionFirstEx(newArr);
        }

        private int[] RepositionFirstEx(int[] target)
        {
            var idx = 0;

            for (int i = _first; i < _arr.Length; i++)
            {
                target[idx++] = _arr[i];
                _arr[i] = 0;
            }

            _first = 0;
            _last = _count;

            return target;
        }

        //If the array is not full, rearrange the items so that _first starts from index 0.
        //If the array is full, expand the array to double the original size, and assign items to the new array starting at index 0. 
        private void RepositionFirst()
        {
            if(_count < _arr.Length)
                _arr = RepositionFirstEx(this._arr);
            else
                Expand();
        }

        public void Enqueue(int item)
        {
            if (IsFull())
                RepositionFirst();

            _arr[_last++] = item;
            _count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var item = _arr[_first];
            _arr[_first++] = 0;
            _count--;

            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _arr[_first];
        }

        public override string ToString()
        {
            var builder = new StringBuilder(_last - _first);
            builder.Append("[");
            for(int i = _first; i < _last; i++)
            {
                builder.Append(_arr[i]);
                if (i != _last - 1)
                    builder.Append(", ");
            }
            builder.Append("]");

            return builder.ToString();
        }
    }
}
