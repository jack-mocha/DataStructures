using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    public class LinkedList
    {
        private Node _first;
        private Node _last;
        private int _count;

        private bool IsEmpty()
        {
            return this._first == null;
        }

        public void AddLast(int value)
        {
            var node = new Node(value);

            //when there is no node in the list.
            if (IsEmpty())
                _first = _last = node;
            else
            {
                //when there is at least one node in the list.
                _last._next = node;
                _last = node;
            }

            //Increment _count
            this._count++;
        }

        public void AddFirst(int value)
        {
            var node = new Node(value);

            //when there is no node in the list.
            if (IsEmpty())
                _first = _last = node;
            else
            {
                //when there is at least one node in the list.
                node._next = _first;
                _first = node;
            }

            //Increment _count
            this._count++;
        }

        public bool Contains(int value)
        {
            var current = _first;
            while(current != null)
            {
                if (current._value == value)
                    return true;

                current = current._next;
            }

            return false;

            //or simply call IndexOf
            //return IndexOf(value) != -1;
        }

        public int IndexOf(int value)
        {
            var current = _first;
            var idx = 0;

            while(current != null)
            {
                if (current._value == value)
                    return idx;

                idx++;
                current = current._next;
            }

            return -1;
        }

        public int Size()
        {
            return this._count;
        }

        public void DeleteFirst()
        {
            //Empty list.
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            //Only has 1 element.
            if (this._first == this._last)
                this._first = this._last = null;
            else
            {
                //More than 1 elements.
                var second = _first._next;
                _first._next = null;
                _first = second;
            }

            this._count--;
        }

        public void DeleteLast()
        {
            //Empty list.
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            //Only has 1 node.
            if (this._first == this._last)
                this._first = this._last = null;
            else
            {
                //Has more than 1 nodes.
                var previous = GetPrevious(this._last);
                _last = previous;
                previous._next = null;
            }

            this._count--;
        }

        public int[] ToArray()
        {
            int[] array = new int[this._count];
            var current = this._first;
            var idx = 0;

            while(current != null)
            {
                array[idx++] = current._value;
                current = current._next;
            }

            return array;

        }

        public void Reverse()
        {
            //Empty list.
            if (IsEmpty())
                return;

            var previous = this._first;
            var current = this._first._next;
            while(current != null)
            {
                var next = current._next;
                current._next = previous;
                previous = current;
                current = next;
            }

            this._last = this._first;
            this._last._next = null;
            _first = previous;
        }

        public int GetKthNodeFromEnd (int k)
        {
            if (k <= 0 || k > this._count)
                throw new ArgumentOutOfRangeException();

            var p2 = this._first;
            for (int i = 1; i <= k - 1; i++)
                p2 = p2._next;

            var p1 = this._first;
            while(p2 != this._last)
            {
                p1 = p1._next;
                p2 = p2._next;
            }

            return p1._value;

        }

        public void PrintMiddle()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            var p1 = this._first;
            var p2 = this._first;

            while(p2 != null)
            {
                if(p2._next != null)
                {
                    if(p2._next._next == null)
                        Console.WriteLine(p1._value);
                    p2 = p2._next._next;
                    p1 = p1._next;
                }
                else
                    p2 = p2._next;
            }
         
            Console.WriteLine(p1._value);
        }

        /// <summary>
        /// This approach stores the second half of the list into a stack.
        /// You can also store the whole list into a stack: Easier implementation, but waste more space.
        /// 2nd approach is to reverse the second half of the list > check with the first half > reverse it back.
        /// 3ed approach is to use recursion.
        /// </summary>
        /// <returns></returns>
        public bool IsPalindrome()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            if (_first._next == null)
                return true;

            var slow = _first;
            var fast = _first;

            while(fast._next != null && fast._next._next != null)
            {
                slow = slow._next;
                fast = fast._next._next;
            }

            var stk = new Stack<Node>();
            if(fast._next == null)
            {
                var current = slow._next._next;
                while(current != null)
                {
                    stk.Push(current);
                    current = current._next;
                }
            }
            else
            {
                var current = slow._next;
                while (current != null)
                {
                    stk.Push(current);
                    current = current._next;
                }
            }

            var node = _first;
            while(stk.Count != 0)
            {
                if (stk.Pop()._value != node._value)
                    return false;
                node = node._next;
            }

            return true;
        }

        public void PrintMiddleCleaner()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            var p1 = this._first;
            var p2 = this._first;

            while(p2 != _last && p2._next != _last)
            {
                p1 = p1._next;
                p2 = p2._next._next;
            }

            if (p2 == _last)
                Console.WriteLine(p1._value);
            else
                Console.WriteLine(p1._value + ", " + p1._next._value);
        }

        /// <summary>
        /// x and y may or may not be adjacent.
        /// Either x or y may be a head node.
        /// Either x or y may be the last node.
        /// x and/or y may not be present in the linked list.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SwapNodes(int x, int y)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (x == y)
                return;

            // Search for x (keep track of prevX and CurrX)
            Node p1 = null, c1 = _first;
            while (c1 != null && c1._value != x)
            {
                p1 = c1;
                c1 = c1._next;
            }

            // Search for y (keep track of prevY and currY)
            Node p2 = null, c2 = _first;
            while (c2 != null && c2._value != y)
            {
                p2 = c2;
                c2 = c2._next;
            }

            // If either x or y is not present, nothing to do
            if (c1 == null || c2 == null)
                return;

            // If x is not head of linked list
            if (p1 != null)
                p1._next = c2;
            else // make y the new head
                _first = c2;

            // If y is not head of linked list
            if (p2 != null)
                p2._next = c1;
            else // make x the new head
                _first = c1;

            // Swap next pointers
            Node temp = c1._next;
            c1._next = c2._next;
            c2._next = temp;
        }

        public void PairwiseSwapNode()
        {
            var current = _first;
            Node previous = null;
            while (current != null && current._next != null)
            {
                SwapNode(previous, current, current, current._next);

                previous = current;
                current = current._next;
            }
        }

        private void SwapNode(Node p1, Node c1, Node p2, Node c2)
        {
            if (p1 == null)
                _first = c2;
            else
                p1._next = c2;

            if (p2 == null)
                _first = c1;
            else
                p2._next = p2;

            var temp = c1._next;
            c1._next = c2._next;
            c2._next = temp;
        }

        public bool HasLoop()
        {
            var slow = this._first;
            var fast = this._first;

            while(fast != null && fast._next != null)
            {
                slow = slow._next;
                fast = fast._next._next;

                if (slow == fast)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// If there is a loop, start counting until the pointer reaches the same node.
        /// </summary>
        /// <returns></returns>
        public int GetLengthOfLoop()
        {
            var slow = _first;
            var fast = _first;

            while(fast != null && fast._next != null)
            {
                slow = slow._next;
                fast = fast._next._next;
                return GetLoopeLength(slow);
            }

            return 0;
        }

        private int GetLoopeLength(Node node)
        {
            var current = node;
            var count = 1;
            while(current._next != node)
            {
                count++;
                current = current._next;
            }

            return count;
        }

        public void Print()
        {
            var current = this._first;
            while (current != null)
            {
                Console.WriteLine(current._value);
                current = current._next;
            }
        }

        private Node GetPrevious(Node node)
        {
            var current = this._first;
            while(current != null)
            {
                if (current._next == node) return current;
                current = current._next;
            }

            return null;
        }

        public void TraverseOdd()
        {
            var p1 = _first;
            while(p1 != null && p1._next != null)
            {
                Console.WriteLine(p1._value);
                p1 = p1._next._next;
            }
        }

        public void TraverseEven()
        {
            if (_first == null)
                return;

            var p1 = _first._next;
            while (p1 != null && p1._next != null)
            {
                Console.WriteLine(p1._value);
                p1 = p1._next._next;
            }
        }

        /// <summary>
        /// Split one list into 2 lists:
        /// headOfEven and headOfOdd
        /// </summary>
        public void SeparteByAlternate()
        {
            var previous = _first;
            var current = _first._next;
            var headOfEven = _first._next;
            var headOfOdd = _first;
            while(current != null)
            {
                var next = current._next;
                previous._next = next;
                previous = current;
                current = next;
            }
        }

        /// <summary>
        /// Merge 2 lists by alternating nodes.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public LinkedList AlternateMerge(LinkedList l1, LinkedList l2)
        {
            var n1 = l1._first;
            var n2 = l2._first;
            var dummy = new Node(0);
            var tail = dummy;

            while(true)
            {
                if(n1 == null)
                {
                    tail._next = n2;
                    tail = n2 == null ? tail : l2._last;
                    break;
                }

                if(n2 == null)
                {
                    tail._next = n1;
                    tail = n1 == null ? tail : l1._last;
                    break;
                }

                tail._next = n1;
                tail = tail._next;
                n1 = n1._next;

                tail._next = n2;
                tail = tail._next;
                n2 = n2._next;
            }

            var head = dummy._next;
            dummy._next = null;

            var merged = new LinkedList();
            merged._first = head;
            merged._last = tail;
            merged._count = l1._count + l2._count;

            return merged;
        }

        public void RemoveDuplicatesSorted()
        {
            if (IsEmpty())
                return;

            var slow = _first;
            var fast = _first._next;
            while(fast != null)
            {
                if(fast._value == slow._value)
                {
                    while (fast != null && fast._value == slow._value) //Advance until not duplicate
                        fast = fast._next;

                    slow._next = fast;
                    if (fast == null)
                        return;
                }

                slow = slow._next;
                fast = fast._next;
            }
        }

        /// <summary>
        /// Traverse the list. If the next is the same as current, delete next.
        /// </summary>
        public void RemoveDuplicatesSortedCleaner()
        {
            if (IsEmpty())
                return;

            var current = _first;
            while(current != null)
            {
                var next = current._next;
                if(next != null && next._value == current._value)
                {
                    current._next = next._next;
                    next._next = null;
                }
                else
                    current = current._next;
            }
        }

        public void RemoveAt(int index)
        {
            if (IsEmpty() || index < 0 || index >= _count)
                throw new InvalidOperationException();

            if(index == 0)
            {
                var second = _first._next;
                _first._next = null;
                _first = second;
                _count--;
                return;
            }

            var current = _first;
            Node prev = null;
            for(int i = 0; i < index; i++)
            {
                prev = current;
                current = current._next;
            }

            prev._next = current._next;
            _count--;
        }

        public void Remove(int value)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            //when head is the target value
            if (_first._value == value)
            {
                var temp = _first;
                _first = _first._next;
                temp._next = null;
                _count--;
                return;
            }

            var current = _first._next;
            Node prev = _first;
            while(current != null && current._value != value)
            {
                prev = prev._next;
                current = current._next;
            }

            //Target Not Found
            if (current == null)
                return;

            prev._next = current._next;
            current._next = null;
            _count--;
        }

        public void Insert(int index, int value)
        {
            if (index < 0 || index > _count)
                throw new InvalidOperationException();

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var node = new Node(value);
            var current = _first;
            for(int i = 0; i < index - 1; i ++)
                current = current._next;
            node._next = current._next;
            current._next = node;
        }

        private class Node
        {
            public int _value { get; private set; }
            public Node _next { get; set; }

            public Node(int value)
            {
                this._value = value;
            }
        }
    }
}
