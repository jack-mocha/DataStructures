using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class MaxHeap
    {
        private int counter;

        public void Heapify(int[] items)
        {
            ////Simple approach:
            //for (int i = items.Length - 1; i >= 0; i--)
            //{
            //    Heapify(items, i);
            //}

            //Optimized: Since we do not need to traverse the leaf nodes, and leaf nodes is almost half of a complelete tree, we starts from the last parent instead of last leaf.
            var lastParentIndex = items.Length / 2 - 1;
            for (var i = lastParentIndex; i >= 0; i--)
                Heapify(items, i);
        }

        private void Heapify(int[] items, int index)
        {
            counter++;
            var largerIndex = index;
            var leftIndex = index * 2 + 1;
            if (leftIndex < items.Length && items[leftIndex] > items[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < items.Length && items[rightIndex] > items[largerIndex])
                largerIndex = rightIndex;

            if (largerIndex == index)
                return;

            Swap(items, index, largerIndex);
            Heapify(items, largerIndex); //Bubble down
        }

        private void Swap(int[] items, int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        public int GetKthLargest(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new InvalidOperationException();

            var heap = new Heap();
            foreach (var i in array)
                heap.Insert(i);

            for (var i = 0; i < k - 1; i++)
                heap.Remove();

            return heap.Max();
        }
    }
}
