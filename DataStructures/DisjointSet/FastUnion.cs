using System;
namespace DataStructures.DisjointSet
{
    //In general, FastUnion is more efficient thant FastFind, because to union N nodes in FastUnion, it costs <= N*O(N).
    //to union N nodes in FastFind, it costs N*O(N).
    public class FastUnion
    {
        private int[] _roots;
        public FastUnion(int size)
        {
            _roots = new int[size];
            for (int i = 0; i < size; i++)
                _roots[i] = i;
        }

        //Time: O(N)
        //Finds the root of x.
        public int Find(int x)
        {
            while (x != _roots[x])
                x = _roots[x];

            return x;
        }

        //Time: O(N)
        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if(rootX != rootY)
                _roots[rootY] = rootX;
        }

        //Time: O(N)
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
