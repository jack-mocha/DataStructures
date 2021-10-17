using DataStructures.Graphs;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddEdge("A", "B", 0);
            graph.AddEdge("B", "C", 0);
            graph.AddEdge("A", "C", 0);
            graph.Print();
            Console.WriteLine(graph.HasCycle());
        }
    }
}
