using System;
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
