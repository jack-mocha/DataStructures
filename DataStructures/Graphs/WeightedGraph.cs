using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class WeightedGraph
    {
        private class Node
        {
            public string Label { get; private set; }

            public Node(string label)
            {
                this.Label = label;
            }

            public override string ToString()
            {
                return this.Label;
            }
        }

        private class Edge
        {
            public Node From { get; private set; }
            public Node To { get; private set; }
            public int Weight { get; private set; }

            public Edge(Node from, Node to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }

            public override string ToString()
            {
                return From.Label + " -> " + To.Label;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Edge>> _adjacencyList = new Dictionary<Node, List<Edge>>();

        //Same as directed graph.
        public void AddNode(string label)
        {
            var node = new Node(label);
            if (!_nodes.ContainsKey(label))
                _nodes.Add(label, node);
            
            if(!_adjacencyList.ContainsKey(node))
                _adjacencyList.Add(node, new List<Edge>());
        }

        //Because this is an undirected graph, you need to add the edge to both fromNode and toNode in the adjacencyList.
        public void AddEdge(string from, string to, int weight)
        {
            Node fromNode;
            Node toNode;
            if (!_nodes.TryGetValue(from, out fromNode))
                throw new InvalidOperationException();
            if (!_nodes.TryGetValue(to, out toNode))
                throw new InvalidOperationException();

            _adjacencyList[fromNode].Add(new Edge(fromNode, toNode, weight));
            _adjacencyList[toNode].Add(new Edge(toNode, fromNode, weight));
        }

        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if (targets.Count > 0)
                    Console.WriteLine(source + " is connected to " + EdgesToString(targets));
            }
        }

        private string EdgesToString(List<Edge> edges)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < edges.Count; i++)
            {
                sb.Append(edges[i].ToString());
                if (i != edges.Count - 1)
                    sb.Append(", ");
                else
                    sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
