using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class IntFinder
    {
        public IEnumerable<int> MostFrequent(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentException();

            var dic = new Dictionary<int, int>();
            var max = Int32.MinValue;
            foreach(var n in numbers)
            {
                if (dic.ContainsKey(n))
                {
                    dic[n] = dic[n] + 1;
                    max = dic[n] > max ? dic[n] : max;
                }
                else
                    dic.Add(n, 1);
            }

            var res = new List<int>();
            foreach(var d in dic)
            {
                if (d.Value == max)
                    res.Add(d.Key);
            }

            return res;
        }

        public int CountPairsWithDiff(int[] numbers, int difference)
        {
            var set = new HashSet<int>();
            foreach (var n in numbers)
                set.Add(n);

            var count = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (set.Contains(numbers[i] + difference))
                    count++;
                if (set.Contains(numbers[i] - difference))
                    count++;
                set.Remove(numbers[i]);
            }

            return count;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map.Add(numbers[i], i);
            }

            return null;
        }
    }
}
