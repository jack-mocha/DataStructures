using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class DoubleStackArray
    {
        private int[] _arr;
        private int _size;
        private int _s1First;
        private int _s1Last;
        private int _s1Count;
        private int _s2First;
        private int _s2Last;
        private int _s2Count;

        public DoubleStackArray(int size)
        {
            _size = size;
            _arr = new int[_size];

            _s1Last = -1;

            _s2First = _size - 1;
            _s2Last = _size;
        }

        public bool IsFull()
        {
            return _s1Last + 1 == _s2Last;
        }

        public void Push1(int item)
        {
            if (IsFull())
                throw new StackOverflowException();

            _arr[_s1Count++] = item;
            _s1Last++;
        }

        public void Push2(int item)
        {
            if (IsFull())
                throw new StackOverflowException();

            _arr[--_s2Last] = item;
            _s2Count++;
        }

        public int Pop1()
        {
            if (IsEmpty1())
                throw new InvalidOperationException();

            var item = _arr[--_s1Count];
            _arr[_s1Count] = 0;
            _s1Last--;

            return item;
        }

        public int Pop2()
        {
            if (IsEmpty2())
                throw new InvalidOperationException();

            var item = _arr[_s2Last];
            _arr[_s2Last] = 0;
            _s2Last++;
            _s2Count--;

            return item;
        }

        public bool IsEmpty1()
        {
            return _s1Count == 0;
        }

        public bool IsEmpty2()
        {
            return _s2Count == 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder(_size);
            builder.Append("[");
            for (int i = 0; i < _s1Count; i++)
            {
                builder.Append(_arr[i]);
                if(i != _s1Last)
                    builder.Append(", ");
            }
            builder.Append("]");
            builder.Append(", ");
            
            builder.Append("[");
            for (int i = _s2First; i >= _s2Last; i--)
            {
                builder.Append(_arr[i]);
                if(i != _s2Last)
                    builder.Append(", ");
            }
            builder.Append("]");

            return builder.ToString();

        }
    }
}
