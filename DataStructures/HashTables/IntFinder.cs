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
    }
}
