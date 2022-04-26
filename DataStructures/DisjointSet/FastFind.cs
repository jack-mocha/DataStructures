using System;
namespace DataStructures.DisjointSet
{
    public class FastFind
    {
        private int[] _vertices;
        public FastFind(int size)
        {
            _vertices = new int[size];
            for (int i = 0; i < _vertices.Length; i++)
                _vertices[i] = i;
        }

        //Time: O(1)
        public int Find(int x)
        {
            return _vertices[x];
        }

        //Time: O(N)
        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if (rootX != rootY)
            {
                for (int i = 0; i < _vertices.Length; i++)
                    if (_vertices[i] == rootY)
                        _vertices[i] = rootX;
            }
        }

        //Time: O(1)
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
