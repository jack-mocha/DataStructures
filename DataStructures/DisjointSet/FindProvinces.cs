using System;
using System.Collections.Generic;

namespace DataStructures.DisjointSet
{
    public class FindProvinces
    {
        public int Execute(int[][] isConnected)
        {
            var uf = new UnionFind(isConnected.Length);
            for (int i = 0; i < isConnected.Length; i++)
            {
                for (int j = 0; j < isConnected[0].Length; j++)
                {
                    if (isConnected[i][j] == 1)
                        uf.Union(i, j);
                }
            }

            return uf.CountGroups();
        }

        private class UnionFind
        {
            private int[] _roots;
            private int[] _ranks;
            public UnionFind(int size)
            {
                _roots = new int[size];
                _ranks = new int[size];

                for (int i = 0; i < size; i++)
                    _roots[i] = i;
            }

            //Path compression
            public int Find(int x)
            {
                if (x == _roots[x])
                    return x;

                _roots[x] = Find(_roots[x]);
                return _roots[x];
            }

            //Union by rank
            public void Union(int x, int y)
            {
                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX != rootY)
                {
                    if (_ranks[rootX] > _ranks[rootY])
                        _roots[rootY] = rootX;
                    else if (_ranks[rootX] < _ranks[rootY])
                        _roots[rootX] = rootY;
                    else
                    {
                        _roots[rootY] = rootX;
                        _ranks[rootX]++;
                    }
                }
            }

            public int CountGroups()
            {
                var set = new HashSet<int>();
                for (int i = 0; i < _roots.Length; i++)
                {
                    var root = Find(i); //To update all parents to their roots
                    set.Add(root);
                }

                return set.Count;
            }
        }
    }
}
