using DataStructures.Trees;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new AVLTree();
            tree1.Insert(10);
            tree1.Insert(30);
            tree1.Insert(5);
            tree1.Insert(20);
            tree1.Insert(7);
            tree1.Insert(25);
            tree1.Insert(23);
            tree1.Insert(24);
            tree1.Insert(22);
            //tree1.Insert(1);
            //tree1.Insert(6);
            //tree1.Insert(8);
            //tree1.Insert(10);
            //tree1.Insert(11);
        }
    }
}
