using System;
namespace DataStructures.DisjointSet
{
    //This is an optimization over FastUnion.
    //The idea is to balance the height of the tree by rank.
    //Whichever subtree has bigger height wins, because including the shorter subtree won't change the height of the taller tree.
    public class FastUnionByRank
    {
        private int[] _roots;
        private int[] _ranks;
        public FastUnionByRank(int size)
        {
            _roots = new int[size];
            _ranks = new int[size];
            for (int i = 0; i < size; i++)
                _roots[i] = i;
        }

        //Time: O(Log(N)) => the height of the tree. 
        public int Find(int x)
        {
            while (x != _roots[x])
                x = _roots[x];

            return x;
        }

        //Time: O(Log(N)) => the height of the tree. 
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
                    _roots[rootY] = rootX; //You can choose either to update rootY or rootX.
                    _ranks[rootX]++;
                }
            }
        }

        //Time: O(Log(N)) => the height of the tree. 
        public bool IsConnected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
