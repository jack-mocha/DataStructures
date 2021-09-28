using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class Heap
    {
        private int[] _items = new int[10];
        private int _size;

        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _items[0];
        }

        //O(log n)
        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var root = _items[0];
            _items[0] = _items[--_size];

            BubbleDown();

            return root;
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= _size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private bool IsValidParent(int index)
        {
            if (!HasLefChild(index))
                return true;

            var isValid = _items[index] >= LeftChild(index);

            if (HasRightChild(index))
                 isValid = isValid && _items[index] >= RightChild(index);

            return isValid;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLefChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return LeftChild(index) > RightChild(index) ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool HasLefChild(int index)
        {
            return LeftChildIndex(index) < _size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) < _size;
        }


        private int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return _items[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        //O(log n)
        public void Insert(int value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            _items[_size++] = value;

            BubbleUp();
        }

        public bool IsFull()
        {
            return _size == _items.Length;
        }

        private void BubbleUp()
        {
            var index = _size - 1;
            while (index > 0 && _items[index] > _items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }


        public static bool IsMaxHeap(int[] items)
        {
            return IsMaxHeap(items, 0);
        }

        private static bool IsMaxHeap(int[] items, int index)
        {
            //All leaf nodes are valid
            var lastParentIndex = items.Length / 2 - 1;
            if (index > lastParentIndex)
                return true;

            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;

            var isValidParent = items[index] >= items[leftIndex] &&
                items[index] >= items[rightIndex];

            return isValidParent && IsMaxHeap(items, leftIndex) && IsMaxHeap(items, rightIndex);
        }
    }
}
