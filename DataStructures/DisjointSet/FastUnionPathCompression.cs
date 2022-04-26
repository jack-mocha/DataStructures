using System;
namespace DataStructures.DisjointSet
{
    public class FastUnionPathCompression
    {
        //When finding the root, recursively updates the parent of the visited vertices.
        private int[] _roots;
        public FastUnionPathCompression(int size)
        {
            _roots = new int[size];
            for (int i = 0; i < size; i++)
                _roots[i] = i;
        }

        //Time: Best - O(1)
        //Worst - O(N)
        //Averge - O(log(N))
        public int Find(int x)
        {
            if (x == _roots[x])
                return x;

            _roots[x] = Find(_roots[x]);

            return _roots[x];
        }

        //Time: Depends on Find()
        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX != rootY)
                _roots[rootY] = rootX;
        }

        //Time: Depends on Find()
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
