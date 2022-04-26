using System;
namespace DataStructures.DisjointSet
{
    public class FastFind
    {
        //The index of _roots represents the vertex
        //The value of _roots represents the root of the veretex
        private int[] _roots;
        public FastFind(int size)
        {
            _roots = new int[size];
            for (int i = 0; i < _roots.Length; i++)
                _roots[i] = i;
        }

        //Time: O(1)
        public int Find(int x)
        {
            return _roots[x];
        }

        //Every time rootX and rootY are different roots, we pick one and update all vertices that have the other one as root.
        //Here we always pick rootX.
        //Time: O(N)
        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if (rootX != rootY)
            {
                for (int i = 0; i < _roots.Length; i++)
                    if (_roots[i] == rootY)
                        _roots[i] = rootX;
            }
        }

        //Time: O(1)
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
