using System;
using System.Collections.Generic;

namespace DataStructures.DisjointSet
{
    public class ValidTree
    {
        public bool Execute(int n, int[][] edges)
        {
            if (edges.Length != n - 1)
                return false;

            var adjacencyList = ConstructAdjacencyList(n, edges);

            //DFS iterative
            var stk = new Stack<int>();
            var seen = new HashSet<int>();
            stk.Push(0); //It does not matter where we start, but here we chose to start from 0.
            while(stk.Count > 0)
            {
                var current = stk.Pop();
                seen.Add(current);

                foreach(var neighbor in adjacencyList[current])
                {
                    if (seen.Contains(neighbor)) //to avoid both trivial cycles and cycles
                        continue;

                    stk.Push(neighbor);
                }
            }

            return seen.Count == n;
        }

        private List<List<int>> ConstructAdjacencyList(int n, int[][] edges)
        {
            var adjacencyList = new List<List<int>>();
            for (int i = 0; i < n; i++)
                adjacencyList.Add(new List<int>());
            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            return adjacencyList;
        }

        //Time: O(N⋅O(α(N)))
        //Space: O(N)
        //Tree: (1)There should be n - 1 edges (fully connected)
        //(2) There is no cycle.
        //(3) Only has 1 root.
        public bool Execute1(int n, int[][] edges)
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
