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

            //This is equivalent to a conceptual adjacencyList like the one in the Graph class.
            private List<Edge> _edges = new List<Edge>();

            public Node(string label)
            {
                this.Label = label;
            }

            public override string ToString()
            {
                return this.Label;
            }

            public void AddEdge(Node to, int weight)
            {
                _edges.Add(new Edge(this, to, weight));
            }

            public List<Edge> GetEdges()
            {
                return _edges;
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

        public void AddNode(string label)
        {
            _nodes.TryAdd(label, new Node(label));
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

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var node in _nodes.Values)
            {
                var edges = node.GetEdges();
                if (edges.Count > 0)
                    Console.WriteLine(node + " is connected to " + EdgesToString(edges));
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
