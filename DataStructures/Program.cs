using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "can", "canada"/*, "care", "cab" */};
            Console.WriteLine(Trie.LongestCommonPrefix(words));
        }
    }
}
