using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackList
    {
        private LinkedList<int> _lst = new LinkedList<int>();

        public void Push(int item)
        {
            _lst.AddFirst(item);
        }

        public int Pop()
        {
            if (_lst.Count == 0)
                throw new InvalidOperationException();

            var item = _lst.First;
            _lst.RemoveFirst();

            return item.Value;
        }

        public int Peek()
        {
            if (_lst.Count == 0)
                throw new InvalidOperationException();

            return _lst.First.Value;
        }

        public bool IsEmpty()
        {
            return _lst.Count == 0;
        }
    }
}
