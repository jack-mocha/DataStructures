using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class CircularArrayQueue
    {
        private int[] _arr;
        private int _first;
        private int _last;
        private int _count;

        public CircularArrayQueue(int size)
        {
            _arr = new int[size];
        }

        public void Enqueue(int item)
        {
            if (IsFull()) //Because we have a check here, the index will not overwrite _first.
                throw new InvalidOperationException();

            _arr[_last] = item;
            _last = (_last + 1) % _arr.Length; //Ensures the index goes back to the beginning of the array when it hits the end of the array to create a circle.
            _count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var item = _arr[_first];
            _first = (_first + 1) % _arr.Length;
            _count--;

            return item;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _arr.Length;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _arr[_first];
        }
    }
}
