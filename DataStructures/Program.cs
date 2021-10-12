using DataStructures.Graphs;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("B", "D");
            graph.AddEdge("D", "C");
            graph.Print();
            graph.TraverseDepthFirstIterative("A");
        }
    }
}
