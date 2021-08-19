using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    /// <summary>
    /// This class includes useful base opertaions that serves as the building blocks for more complext algorithms.
    /// </summary>
    public class SinglyLinkedListBase
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node _head;

        /// <summary>
        /// 1. Find the last node.
        /// 2. Append the new node to the last node.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
            {
                _head = node;
                return;
            }

            var current = _head;
            while(current.Next != null)
                current = current.Next;

            current.Next = node;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// 1. Find the first node 
        /// 2. Append the new node to the first node
        /// 3. Assign the first node to head.
        /// </summary>
        public void AddFirst(int value)
        {
            var node = new Node(value);

            if(IsEmpty())
            {
                _head = node;
                return;
            }

            node.Next = _head;
            _head = node;
        }

        public void Print()
        {
            Print(_head);
        }

        private void Print(Node head)
        {
            var builder = new StringBuilder();
            builder.Append("[");

            var current = head;
            while (current != null)
            {
                builder.Append(current.Value);
                if (current.Next != null)
                    builder.Append(", ");

                current = current.Next;
            }

            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }

        public void Reverse()
        {
            _head = Reverse(_head);
        }

        /// <summary>
        /// 3 pointers: p, c, n
        /// Traverse when c != null
        /// p will be the new head.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private Node Reverse(Node head)
        {
            Node prev = null;
            var current = head;
            while(current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        public void SplitInHalf()
        {
            var nodes = SplitInHalf(_head);

            Console.Write("First half: ");
            Print(nodes[0]);
            Console.Write("Second half: ");
            Print(nodes[1]);
        }

        /// <summary>
        /// 2 pointers: slow, fast
        /// slow goes 1 step, and fast goes 2 steps at a time
        /// when fast reaches the end, slow will be at the middle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private Node[] SplitInHalf(Node head)
        {
            var slow = head;
            var fast = head.Next;
            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            var n2 = slow.Next;
            slow.Next = null;
            var nodes = new Node[]
            {
                head, n2
            };

            return nodes;
        }

        /// <summary>
        /// Use a dummy as a temp head
        /// Add one node from each lists to the dummy
        /// If one list reaches the end, add the rest of the other node to dummy
        /// Vice versa.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        private Node AlternateMerge(Node n1, Node n2)
        {
            var dummy = new Node(0);
            var tail = dummy;

            while(true)
            {
                if (n1 == null)
                {
                    tail.Next = n2;
                    break;
                }

                if (n2 == null)
                {
                    tail.Next = n1;
                    break;
                }

                tail.Next = n1;
                tail = tail.Next;
                n1 = n1.Next;

                tail.Next = n2;
                tail = tail.Next;
                n2 = n2.Next;
            }

            var head = dummy.Next;
            dummy.Next = null;

            return head;
        }
    }
}
