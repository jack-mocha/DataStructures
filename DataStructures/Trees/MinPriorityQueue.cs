using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class MinPriorityQueue
    {
        private MinHeap _minHeap = new MinHeap();

        public void Add(int value, int priority)
        {
            _minHeap.Insert(priority, value);
        }

        public int Remove()
        {
            return _minHeap.Remove();
        }

        public bool IsEmpty()
        {
            return _minHeap.IsEmpty();
        }
    }
}
