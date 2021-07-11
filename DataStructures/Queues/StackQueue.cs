using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    public class StackQueue
    {
        private Stack<int> _first;
        private Stack<int> _second;

        public StackQueue()
        {
            _first = new Stack<int>();
            _second = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            _first.Push(item);
        }

        public int Dequeue()
        {
            Flush();
            return _second.Count == 0 ? throw new InvalidOperationException() : _second.Pop();
        }

        public bool IsEmpty()
        {
            return _first.Count == 0 && _second.Count == 0;
        }

        public int Peek()
        {
            Flush();
            return _second.Count == 0 ? throw new InvalidOperationException() : _second.Peek();
        }

        private void Flush()
        {
            if (_second.Count == 0)
            {
                while (_first.Count != 0)
                    _second.Push(_first.Pop());
            }
        }

        public override string ToString()
        {
            Flush();
            var builder = new StringBuilder();
            builder.Append("[");

            while(_second.Count != 0)
            {
                builder.Append(_second.Pop());
                if (_second.Count != 0)
                    builder.Append(", ");
            }

            builder.Append("]");

            return builder.ToString();
        }
    }
}
