using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class LinkedListQueue
    {
        private class Node
        {
            public int value { get; private set; }
            public Node next { get; set; }

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node _head;
        private Node _tail;
        private int count;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Enqueue(int item)
        {
            var node = new Node(item);
            if (IsEmpty())
                _head = _tail = node;
            else
            {
                _tail.next = node;
                _tail = node;
            }

            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            int value;
            if(_head == _tail)
            {
                value = _head.value;
                _head = _tail = null;
            }
            else
            {
                value = _head.value;
                var second = _head.next;
                _head.next = null;
                _head = second;
            }

            count--;

            return value;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _head.value;
        }

        public int Size()
        {
            return count;
        }
    }
}
