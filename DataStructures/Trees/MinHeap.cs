using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class MinHeap
    {
        private class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private Node[] _nodes = new Node[10];
        private int _size;

        public void Print()
        {
            for(int i = 0; i < _size; i++)
            {
                Console.WriteLine(_nodes[i].Value);
            }
        }

        public void Insert(int key, int value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            var node = new Node(key, value);
            _nodes[_size++] = node;

            BubbleUp();
        }

        private void BubbleUp()
        {
            var index = _size - 1;
            while(index > 0 && _nodes[index].Key < _nodes[Parent(index)].Key)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void Swap(int first, int second)
        {
            var temp = _nodes[first];
            _nodes[first] = _nodes[second];
            _nodes[second] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private bool IsFull()
        {
            return _size == _nodes.Length;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var root = _nodes[0];
            _nodes[0] = _nodes[--_size];

            BubbleDown();

            return root.Value;
        }

        private void BubbleDown()
        {
            var index = 0;
            while(index < _size && !IsValidParent(index))
            {
                var smallerChildIndex = SmallerChildIndex(index);
                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        private int SmallerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return LeftChild(index).Key < RightChild(index).Key ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = _nodes[index].Key <= LeftChild(index).Key;

            if (HasRightChild(index))
                isValid = isValid && _nodes[index].Key <= RightChild(index).Key;

            return isValid;
        }

        private Node RightChild(int index)
        {
            return _nodes[RightChildIndex(index)];
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) < _size;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private Node LeftChild(int index)
        {
            return _nodes[LeftChildIndex(index)];
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) < _size;
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}
