using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays.Example1
{
    public class Array
    {
        private int[] _items;
        private int _count;

        public Array(int length)
        {
            if (length <= 0)
                throw new ArgumentException();

            _items = new int[length];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _count; i++)
                if (_items[i] == item) return i;

            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentException();

            for (int i = index; i < _count - 1; i++)
                _items[i] = _items[i + 1];

            _items[_count - 1] = 0;
            _count--;
        }

        private void ResizeIfRequired()
        {
            if(_count == _items.Length)
            {
                var newItems = new int[_items.Length * 2];
                for (int i = 0; i < _count; i++)
                    newItems[i] = _items[i];

                _items = newItems;
            }
        }

        public void Insert(int value)
        {
            ResizeIfRequired();

            _items[_count++] = value;
        }

        public int Max()
        {
            if (_count <= 0)
                return -1;

            int max = _items[0];
            for (int i = 0; i < _count; i++)
                if (_items[i] > max) max = _items[i];

            return max;
        }

        /// <summary>
        /// 2 index. One goes from the beginning and the oter goes from the end. Swap elements while traversing to the middle of the array.
        /// </summary>
        public void Reverses()
        {
            var middle = _count / 2;
            var last = _count - 1;
            for(int i=0; i<middle; i++)
            {
                var temp = _items[i];
                _items[i] = _items[last];
                _items[last] = temp;

                last--;
            }
        }

        public Array Intersect(Array other)
        {
            var intersection = new Array(_count);

            foreach (var item in _items)
                if (other.IndexOf(item) >= 0)
                    intersection.Insert(item);

            return intersection;
        }

        public void InsertAt(int item, int idx)
        {
            if (idx < 0 || idx > _count)
                throw new ArgumentException();

            ResizeIfRequired();

            for (int i=_count -1; i >= idx; i--)
                _items[i + 1] = _items[i];

            _items[idx] = item;
            _count++;
        }

        public void Print()
        {
            for (int i=0; i<_count ;i++)
                Console.WriteLine(_items[i]);
        }
    }
}
