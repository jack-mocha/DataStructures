using System;
namespace DataStructures.DisjointSet
{
    public class OptimizedFastUnion
    {
        private int[] _roots;
        private int[] _ranks;
        public OptimizedFastUnion(int size)
        {
            _roots = new int[size];
            _ranks = new int[size];

            for (int i = 0; i < size; i++)
                _roots[i] = i;
        }

        //Time: O(α(N)) is regarded as O(1)O(1) on average. α refers to the Inverse Ackermann function. In practice, we assume it's a constant. 
        //Path Compression
        public int Find(int x)
        {
            if (x == _roots[x])
                return x;

            _roots[x] = Find(_roots[x]);

            return _roots[x];
        }

        //Time: Depends on Find()
        //Union by rank
        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if(rootX != rootY)
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

        //Time: Depends on Find()
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
