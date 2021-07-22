using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class ListQueue
    {
        private List<int> _lst;

        public ListQueue()
        {
            _lst = new List<int>();
        }

        public bool IsEmpty()
        {
            return _lst.Count == 0;
        }

        public int Size()
        {
            return _lst.Count;
        }

        public int Peek()
        {
            if (_lst.Count == 0)
                throw new InvalidOperationException();

            return _lst[0];
        }

        public void Enqueue(int item)
        {
            _lst.Add(item);
        }

        public int Dequeue()
        {
            if (_lst.Count == 0)
                throw new InvalidOperationException();

            var item = _lst[0];
            _lst.RemoveAt(0);

            return item;
        }
    }
}
