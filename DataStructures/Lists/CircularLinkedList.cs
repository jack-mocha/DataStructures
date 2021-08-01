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
        Node _last;
        
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
                _last = node;
                return;
            }

            var current = _first;
            while (current.Next != _first)
                current = current.Next;
            current.Next = node;
            _last = node;
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
            {
                node.Next = node;
                _last = node;
            }

            _first = node;
        }

        public void SplitInHalf()
        {
            var slow = _first;
            var fast = _first;

            while(fast.Next != _first && fast.Next.Next != _first)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Node head1 = _first;
            Node head2 = null;
            //Even counts
            if(fast.Next.Next == _first)
            {
                head2 = slow.Next;
                fast.Next.Next = head2;
                slow.Next = head1;
            }
            else //Odd counts
            {
                head2 = slow.Next;
                fast.Next = head2;
                slow.Next = head1;
            }
        }

        public void Insert(int value, int item)
        {
            var node = new Node(value);
            var current = _last.Next;
            do
            {
                if (current.Value == item)
                {
                    node.Next = current.Next;
                    current.Next = node;

                    if (current == _last)
                        _last = node;

                    return;
                }
                else
                    current = current.Next;
            } while (current != _last.Next);
        }

        public void Delete(int value)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if(_first.Value == value)
            {
                if(_first == _last) //only when we need to maintain the _last pointer
                {
                    _first = null;
                    _last = null;
                }
                else
                {
                    _last.Next = _first.Next;
                    _first.Next = null;
                    _first = _last.Next;
                }

                return;
            }

            var current = _first;
            Node previous = null;

            do
            {
                if(current.Value != value)
                {
                    previous = current;
                    current = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                    current.Next = null;
                    
                    if(current == _last) //When the target it the last node
                        _last = previous;

                    return;
                }
            } while (current != _first);
        }
    }
}
