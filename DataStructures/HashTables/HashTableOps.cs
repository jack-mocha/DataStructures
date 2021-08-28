using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class HashTableOps
    {
        /// <summary>
        /// Find out the sequence of the itinerary.
        /// </summary>
        /// <param name="tickets"></param>
        public void PrintItinerary(Dictionary<string, string> tickets)
        {
            var reverseMap = new Dictionary<string, string>();
            foreach (var t in tickets)
                reverseMap.Add(t.Value, t.Key);

            var start = String.Empty;
            foreach(var t in tickets)
            {
                if(!reverseMap.ContainsKey(t.Key))
                {
                    start = t.Key;
                    break;
                }
            }

            if(start == null)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            var to = tickets[start];
            while(to != null)
            {
                Console.WriteLine(start + "->" + to + ",");
                start = to;
                to = tickets.ContainsKey(to) ? tickets[to] : null;
            }
        }

        public void PrintUnionIntersection(List<int> l1, List<int> l2)
        {
            var map = new Dictionary<int, int>();
            foreach (var l in l1)
                map.Add(l, 1);
            foreach(var l in l2)
            {
                if (map.ContainsKey(l))
                    map[l]++;
                else
                    map.Add(l, 1);
            }

            var intersection = GetIntersection(map);
            var union = GetUnion(map);

            Console.WriteLine("Intersection: ");
            foreach(var item in intersection)
                Console.WriteLine(item);

            Console.WriteLine("Union: ");
            foreach(var item in union)
                Console.WriteLine(item);
        }

        private List<int> GetIntersection(Dictionary<int, int> map)
        {
            var result = new List<int>();

            foreach(var item in map)
            {
                if (item.Value > 1)
                    result.Add(item.Key);        
            }

            return result;
        }

        private List<int> GetUnion(Dictionary<int, int> map)
        {
            var result = new List<int>();

            foreach (var item in map)
                result.Add(item.Key);

            return result;
        }
    }
}
