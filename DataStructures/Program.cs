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
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.RemoveNode("A");
            graph.AddEdge("B", "C");
            graph.Print();
        }
    }
}
