using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new BinarySearchTree();
            tree1.Insert(7);
            tree1.Insert(4);
            tree1.Insert(9);
            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(8);
            tree1.Insert(10);
            tree1.Insert(11);
            var tree2 = new BinarySearchTree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(1);
            tree2.Insert(6);
            tree2.Insert(8);
            tree2.Insert(10);
            tree2.Insert(11);
            Console.WriteLine(tree1.Equals(tree2));

        }
    }
}
