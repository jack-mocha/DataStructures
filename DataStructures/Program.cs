using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("car");
            trie.Insert("card");
            trie.Insert("care");
            trie.Insert("careful");
            trie.Insert("egg");
            var results = trie.FindWords(null);
            foreach(var r in results)
                Console.WriteLine(r);
        }
    }
}
