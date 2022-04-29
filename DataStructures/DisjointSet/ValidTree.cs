using System;
namespace DataStructures.DisjointSet
{
    public class ValidTree
    {
        //Time: O(N⋅O(α(N)))
        //Space: O(N)
        //Tree: (1)There should be n - 1 edges (fully connected)
        //(2) There is no cycle.
        //(3) Only has 1 root.
        public bool Execute(int n, int[][] edges)
        {
            var uf = new UnionFind(n);
            foreach (var edge in edges)
            {
                if (!uf.Union(edge[0], edge[1]))
                    return false; //Has a cycle.
            }


            return uf.GetNumberOfRoots() == 1 ? true : false; //Tree can only have 1 root.
        }

        private class UnionFind
        {
            private int[] _roots;
            private int[] _ranks;
            private int _count; //Number of roots
            public UnionFind(int size)
            {
                _roots = new int[size];
                _ranks = new int[size];
                _count = size;
                for (int i = 0; i < size; i++)
                    _roots[i] = i;
            }

            public int GetNumberOfRoots()
            {
                return _count;
            }

            public int Find(int x)
            {
                if (x == _roots[x])
                    return x;

                _roots[x] = Find(_roots[x]);
                return _roots[x];
            }

            public bool Union(int x, int y)
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

                    _count--; //Whenever 2 nodes union, we have one less root
                    return true;
                }
                else
                    return false; //Has Cycle.
            }
        }
    }
}
