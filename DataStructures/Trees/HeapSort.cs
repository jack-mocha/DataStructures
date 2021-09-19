using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class HeapSort
    {
        public void SortDesc(int[] items)
        {
            var heap = new Heap();
            foreach (var i in items)
                heap.Insert(i);

            for (int i = 0; i < items.Length; i++)
                items[i] = heap.Remove();
        }

        public void SortAsc(int[] items)
        {
            var heap = new Heap();
            foreach (var i in items)
                heap.Insert(i);

            for (int i = items.Length - 1; i >= 0; i--)
                items[i] = heap.Remove();
        }

    }
}
