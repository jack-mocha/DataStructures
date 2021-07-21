using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    public class SinglyLinkedList
    {
        private class Node
        {
            public Node Next { get; set; }
            public int Data { get; set; }

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node _head;

        public void AddLast(int data)
        {
            var node = new Node(data);

            if (IsEmpty())
            {
                _head = node;
                return;
            }

            var current = _head;
            while (current.Next != null)
                current = current.Next;
            current.Next = node;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void SortedMerge(SinglyLinkedList lst)
        {
            if (lst == null)
                throw new ArgumentException();

            var dummy = new Node(0);
            var tail = dummy;
            var n1 = _head;
            var n2 = lst._head;

            while(true)
            {
                if( n1 == null)
                {
                    tail.Next = n2;
                    break;
                }

                if(n2 == null)
                {
                    tail.Next = n1;
                    break;
                }

                if(n1.Data <= n2.Data)
                {
                    tail.Next = n1;
                    tail = tail.Next;
                    n1 = n1.Next;
                }
                else
                {
                    tail.Next = n2;
                    tail = tail.Next;
                    n2 = n2.Next;
                }
            }

            _head = dummy.Next;
            dummy = null;
        }

        public void Print()
        {
            var current = _head;
            var builder = new StringBuilder();
            builder.Append("[");

            while(current != null)
            {
                builder.Append(current.Data);
                if (current.Next != null)
                    builder.Append(", ");
                current = current.Next;
            }

            builder.Append("]");

            Console.WriteLine(builder.ToString());
        }
    }
}
