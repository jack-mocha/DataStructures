using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class PriorityQueueWithHeap
    {
        private Heap _heap = new Heap();

        //O(log n) because the worst case is to traverse as much as the height of the tree.
        public void Enqueue(int item)
        {
            _heap.Insert(item);
        }
        
        //Same as Enqueue. O(log n) because the worst case is to traverse as much as the height of the tree.
        public int Dequeue()
        {
            return _heap.Remove();
        }

        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }
    }
}
