using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("bell");

            trie.PostOrderTraversal();
        }
    }
}
