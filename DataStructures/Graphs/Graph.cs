using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class Graph
    {
        private class Node
        {
            public string Label { get; private set; }

            public Node(string label)
            {
                Label = label;
            }

            public override string ToString()
            {
                return this.Label;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            if (!_nodes.ContainsKey(label))
                _nodes.Add(label, node);

            if (!_adjacencyList.ContainsKey(node))
                _adjacencyList.Add(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            Node fromNode;
            Node toNode;
            if (!_nodes.TryGetValue(from, out fromNode))
                throw new InvalidOperationException();
            if (!_nodes.TryGetValue(to, out toNode))
                throw new InvalidOperationException();

            _adjacencyList[fromNode].Add(toNode);
        }

        public void Print()
        {
            foreach(var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if(targets.Count > 0)
                    Console.WriteLine(source + " is connected to " + targets);
            }
        }
    }
}
