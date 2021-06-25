using System;
using System.Text;

namespace DataStructures.Lists
{
    public class LinkedList
    {
        private Node _first;
        private Node _last;

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

            //when there is at least one node in the list.
            _last._next = node;
            _last = node;
        }

        public void AddFirst(int value)
        {
            var node = new Node(value);

            //when there is no node in the list.
            if (IsEmpty())
                _first = _last = node;
           
            //when there is at least one node in the list.
            node._next = _first;
            _first = node;
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

        public void DeleteFirst()
        {
            if (this._first == this._last)
                this._first = this._last = null;

            var temp = this._first;
            _first = _first._next;
            temp._next = null;
        }

        public void DeleteLast()
        {
            if (this._first == this._last)
                this._first = this._last = null;

            var current = this._first;
            while(current._next != _last)
                current = current._next;

            current._next = null;
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
