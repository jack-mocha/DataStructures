using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    public class CircularLinkedList
    {
        private class Node
        {
            public int Value { get; private set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        Node _first;
        
        public bool IsEmpty()
        {
            return _first == null;
        }

        public void Push(int value)
        {
            var node = new Node(value);
            node.Next = _first;

            if (IsEmpty())
            {
                _first = node;
                node.Next = node;
                return;
            }

            var current = _first;
            while (current.Next != _first)
                current = current.Next;
            current.Next = node;
        }

        public void PushHead(int value)
        {
            Node node = new Node(value);
            node.Next = _first;
            Node current = _first;

            if (!IsEmpty())
            {
                while (current.Next != _first)
                    current = current.Next;
                current.Next = node;
            }
            else
                node.Next = node;

            _first = node;
        }

    }
}
