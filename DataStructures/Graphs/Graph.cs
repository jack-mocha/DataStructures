using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    //In Graph, it is possible to visit the same node.
    //Depending on where you start the traversal, you may not visit every node in the graph.
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

        public void RemoveNode(string label)
        {
            Node node;
            if (!_nodes.TryGetValue(label, out node))
                return;
            foreach (var key in _adjacencyList.Keys)
                _adjacencyList[key].Remove(node);

            _adjacencyList.Remove(node);
            _nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            Node fromNode;
            Node toNode;
            if (!_nodes.TryGetValue(from, out fromNode))
                return;
            if (!_nodes.TryGetValue(to, out toNode))
                return;

            _adjacencyList[fromNode].Remove(toNode);
        }

        public void Print()
        {
            foreach(var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if(targets.Count > 0)
                    Console.WriteLine(source + " is connected to " + NodesToString(targets));
            }
        }

        public void TraverseDepthFirstRecursive(string label)
        {
            Node node;
            if (!_nodes.TryGetValue(label, out node))
                return;

            var visited = new HashSet<Node>();
            TraverseDepthFirstRecursive(node, visited);
        }

        private void TraverseDepthFirstRecursive(Node node, HashSet<Node> visited)
        {
            Console.WriteLine(node.Label);
            visited.Add(node);

            foreach (var n in _adjacencyList[node])
            {
                if (!visited.Contains(n))
                    TraverseDepthFirstRecursive(n, visited);
            }
        }

        //Note that the sequence of which node is visited is different from the recursive method, because of the stack.
        public void TraverseDepthFirstIterative(string label)
        {
            Node root;
            if (!_nodes.TryGetValue(label, out root))
                return;

            var visited = new HashSet<Node>();
            var stk = new Stack<Node>();
            stk.Push(root);
            while(stk.Count > 0)
            {
                var current = stk.Pop();
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current.Label);
                visited.Add(current);

                foreach(var neighbor in _adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                        stk.Push(neighbor);
                }
            }
        }

        private string NodesToString(List<Node> nodes)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for(int i = 0; i < nodes.Count; i++)
            {
                sb.Append(nodes[i].Label);
                if (i != nodes.Count - 1)
                    sb.Append(", ");
                else
                    sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
