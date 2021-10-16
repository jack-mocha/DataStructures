using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        private class NodeEntry
        {
            public Node Node { get; private set; }
            public int Priority { get; private set; }

            public NodeEntry(Node node, int priority)
            {
                this.Node = node;
                this.Priority = priority;
            }
        }

        private class ByNodePriority : IComparer<NodeEntry>
        {
            public int Compare(NodeEntry x, NodeEntry y)
            {
                return x.Priority.CompareTo(y.Priority);
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

        public int GetShortestDistance(string from, string to)
        {
            Node fromNode;
            Node toNode;
            if (!_nodes.TryGetValue(from, out fromNode))
                throw new InvalidOperationException();
            if (!_nodes.TryGetValue(to, out toNode))
                throw new InvalidOperationException();

            var distances = new Dictionary<Node, int>();
            foreach(var node in _nodes.Values)
                distances.Add(node, Int32.MaxValue);
            distances[fromNode] = 0;

            var visited = new HashSet<Node>();
            //Originally meant to be using priority queue, but pq is introduced in .NET 6.0 RC1.
            //Sort of low to high. The lower the value the higher the priority.
            var pq = new SortedSet<NodeEntry>(new ByNodePriority()); 
            pq.Add(new NodeEntry(fromNode, 0));
            while (pq.Count > 0)
            {
                var current = pq.Min.Node;
                pq.Remove(pq.Min); 
                visited.Add(current);

                foreach(var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.To)) //because there are (1)undirected path (2)priority queue
                        continue;

                    var newDistance = distances[current] + edge.Weight;
                    if(newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        pq.Add(new NodeEntry(edge.To, newDistance));
                    }
                }
            }

            return distances[toNode];
        }

        public Path GetShortestPath(string from, string to)
        {
            Node fromNode;
            Node toNode;
            if (!_nodes.TryGetValue(from, out fromNode))
                throw new InvalidOperationException();
            if (!_nodes.TryGetValue(to, out toNode))
                throw new InvalidOperationException();

            var distances = new Dictionary<Node, int>();
            foreach (var node in _nodes.Values)
                distances.Add(node, Int32.MaxValue);
            distances[fromNode] = 0;

            var previousNodes = new Dictionary<Node, Node>();
            foreach (var node in _nodes.Values)
                previousNodes.Add(node, null);

            var visited = new HashSet<Node>();
            var pq = new SortedSet<NodeEntry>(new ByNodePriority());
            pq.Add(new NodeEntry(fromNode, 0));
            while (pq.Count > 0)
            {
                var current = pq.Min.Node;
                pq.Remove(pq.Min);
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.To))
                        continue;

                    var newDistance = distances[current] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        pq.Add(new NodeEntry(edge.To, newDistance));
                        previousNodes[edge.To] = current;
                    }
                }
            }

            return BuildPath(previousNodes, toNode);
        }

        private Path BuildPath(Dictionary<Node,Node> previousNodes, Node toNode)
        {
            var stk = new Stack<Node>();
            stk.Push(toNode);
            var previous = previousNodes[toNode];
            while (previous != null)
            {
                stk.Push(previous);
                previous = previousNodes[previous];
            }
            var path = new Path();
            while (stk.Count > 0)
                path.Nodes.Add(stk.Pop().Label);

            return path;
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
