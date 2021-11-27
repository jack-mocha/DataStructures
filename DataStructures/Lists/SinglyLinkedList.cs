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

        /// <summary>
        /// Merged 2 already sorted lists. The result is still sorted.
        /// </summary>
        /// <param name="lst"></param>
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

        public void ShiftLinkedList(int k)
        {
            var current = _head;
            var count = 1;
            while (current.Next != null) // Get the last node and calculate the count of nodes in the list.
            {
                current = current.Next;
                count++;
            }

            //Another way of doing it
            //var offset = Math.Abs(k) % count;
            //if (offset == 0) return;
            //var newTailPosition = k > 0 ? count - offset : offset;
            //var newTail = _head;
            //for (int i = 0; i < newTailPosition - 1; i++)
            //    newTail = newTail.Next;

            //var newHead = newTail.Next;
            //newTail.Next = null;
            //var last = current;
            //last.Next = _head;
            //_head = newHead;

            k = k % count; // Offset K
            if (k == 0) return;
            var newTail = k >= 0 ? GetKthNodeFromEnd(_head, k + 1) : GetKthNodeFromEnd(_head, count + k + 1);
            var newHead = newTail.Next;
            newTail.Next = null;

            var last = current;
            current.Next = _head;

            _head = newHead;
        }

        private Node GetKthNodeFromEnd(Node head, int k)
        {
            if (k == 0)
                return head;

            var p2 = head;
            for (int i = 0; i < k - 1; i++)
                p2 = p2.Next;
            var p1 = head;
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }


        public void Reverse()
        {
            _head = Reverse(_head.Next.Next);
        }

        public bool IsPalindrome()
        {
            if (_head == null)
                return true;

            var firstHalfEnd = EndOfFirstHalf();
            var secondHalfStart = Reverse(firstHalfEnd.Next);

            var p1 = _head;
            var p2 = secondHalfStart;
            var result = true;
            while (result && p2 != null)
            {
                if (p1.Data != p2.Data)
                    result = false;

                p1 = p1.Next;
                p2 = p2.Next;
            }

            Reverse(secondHalfStart); //Either this or the below is fine, because firstHalfEnd.Next is always attached.
            //firstHalfEnd.Next = Reverse(secondHalfStart);

            return result;
        }

        private Node Reverse(Node head)
        {
            Node prev = null;
            var current = head;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        private Node EndOfFirstHalf()
        {
            var fast = _head;
            var slow = _head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }
    }
}
