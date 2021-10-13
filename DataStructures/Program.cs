using DataStructures.Graphs;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddNode("X");
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("P");
            graph.AddEdge("X", "A");
            graph.AddEdge("X", "B");
            graph.AddEdge("A", "P");
            graph.AddEdge("B", "P");
            graph.Print();
            var result = graph.TopologicalSort();
            foreach(var r in result)
                Console.WriteLine(r);
        }
    }
}
