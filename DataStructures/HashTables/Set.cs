using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class Set
    {
        public bool IsSubSet(int[] arr1, int[] arr2)
        {
            var set = new HashSet<int>();
            foreach (var a in arr2)
                set.Add(a);

            foreach (var a in arr1)
            {
                if (set.Contains(a))
                    set.Remove(a);
            }

            return set.Count == 0;
        }
    }
}
