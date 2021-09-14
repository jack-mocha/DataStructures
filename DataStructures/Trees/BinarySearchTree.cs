using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class BinarySearchTree
    {
        private Node _root;

        private class Node
        {
            public int Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Node=" + Value;
            }
        }

        public void Insert(int value)
        {
            var node = new Node(value);
            if (_root == null)
            {
                _root = node;
                return;
            }

            var current = _root;
            while(current != null)
            {
                if (value > current.Value)
                {
                    if (current.Right != null)
                        current = current.Right;
                    else
                    {
                        current.Right = node;
                        return;
                    }
                }
                else
                {
                    if (current.Left != null)
                        current = current.Left;
                    else
                    {
                        current.Left = node;
                        return;
                    }
                }
            }
        }

        public void InsertRecursive(int value)
        {
            _root = DoInsertRecursive(value, _root);
        }

        private Node DoInsertRecursive(int value, Node node)
        {
            if (node == null)
                return new Node(value);

            if (value > node.Value)
                node.Right = DoInsertRecursive(value, node.Right);
            else
                node.Left = DoInsertRecursive(value, node.Left);

            return node;
        }

        public bool Find(int value)
        {
            var current = _root;
            while(current != null)
            {
                if (value > current.Value)
                    current = current.Right;
                else if (value < current.Value)
                    current = current.Left;
                else
                    return true;
            }

            return false;
        }

        public bool FindRecursive(int value)
        {
            return DoFindRecursive(value, _root);
        }

        private bool DoFindRecursive(int value, Node node)
        {
            if (node == null)
                return false;

            if (value > node.Value)
                return DoFindRecursive(value, node.Right);
            if (value < node.Value)
                return DoFindRecursive(value, node.Left);
            else
                return true;
        }

        public int Height()
        {
            return Height(_root);
        }

        //This is using post order traversal
        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.Left), Height(root.Right)); //post-order
        }

        public int Min()
        {
            return Min(_root);
        }

        private int Min(Node root, int min)
        {
            if (root == null)
                return min;

            if (root.Value < min)
                min = root.Value;

            return Math.Min(Min(root.Left, min), Min(root.Right, min));
        }

        //Post-order traversal
        private int Min(Node root)
        {
            if (root == null)
                return Int32.MaxValue;

            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.Left);
            var right = Min(root.Right);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        private bool IsLeaf(Node root)
        {
            return root.Left == null && root.Right == null;
        }

        public bool Equals(BinarySearchTree other)
        {
            if (other == null)
                return false;

            return Equals(_root, other._root);
        }

        //Pre-order traversal because we first compare 2 values > left > right
        private bool Equals(Node root1, Node root2)
        {
            if (root1 == null && root2 == null)
                return true;

            if (root1 != null && root2 != null)
                return root1.Value == root2.Value && Equals(root1.Left, root2.Left) && Equals(root1.Right, root2.Right);

            return false;
        }

        public bool IsBST()
        {
            return IsBST(_root, Int32.MinValue, Int32.MaxValue);
        }

        //Pre-order
        private bool IsBST(Node root, int min, int max)
        {
            if (root == null)
                return true;

            return (root.Value > min && root.Value < max) && IsBST(root.Left, min, root.Value) && IsBST(root.Right, root.Value, max);
        }

        public void PrintNodesAtDistance(int distance)
        {
            PrintNodesAtDistance(_root, distance);
        }

        private void PrintNodesAtDistance(Node root, int distance)
        {
            if (root == null)
                return;

            if(distance == 0)
            {
                Console.WriteLine(root.Value);
                return;
            }

            PrintNodesAtDistance(root.Left, distance - 1);
            PrintNodesAtDistance(root.Right, distance - 1);
        }

        public List<int> GetNodesAtDistance(int distance)
        {
            var lst = new List<int>();
            GetNodesAtDistance(_root, distance, lst);
            return lst;
        }

        private void GetNodesAtDistance(Node root, int distance, List<int> lst)
        {
            if (root == null)
                return;

            if(distance == 0)
            {
                lst.Add(root.Value);
                return;
            }

            GetNodesAtDistance(root.Left, distance - 1, lst);
            GetNodesAtDistance(root.Right, distance - 1, lst);
        }

        public void TraverseLevelOrder()
        {
            for(var i = 0; i <= Height(); i++)
            {
                foreach(var value in GetNodesAtDistance(i))
                    Console.WriteLine(value);
            }
        }

        public void TraverseLevelOrderUsingQueue()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(_root);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current.Value);
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public int Size()
        {
            return Size(_root);
        }

        //post-order
        private int Size(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return 1 + Size(root.Left) + Size(root.Right);
        }

        public int CountLeaves()
        {
            return CountLeaves(_root);
        }

        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return CountLeaves(root.Left) + CountLeaves(root.Right);
        }

        public int Max()
        {
            return Max(_root);
        }

        private int Max(Node root)
        {
            if (root == null)
                return Int32.MinValue;

            return Math.Max(root.Value, Math.Max(Max(root.Left), Max(root.Right)));
        }

        public bool Contains(int value)
        {
            return Contains(_root, value);
        }

        private bool Contains(Node root, int value)
        {
            if (root == null)
                return false;
            
            if (root.Value == value)
                return true;

            return Contains(root.Left, value) || Contains(root.Right, value);
        }

        public bool AreSiblings(int first, int second)
        {
            return AreSiblings(_root, first, second);
        }

        private bool AreSiblings(Node root, int first, int second)
        {
            if (root == null)
                return false;

            var areSiblings = false;
            if (root.Left != null && root.Right != null)
            {
                areSiblings = (root.Left.Value == first && root.Right.Value == second) ||
                    (root.Left.Value == second && root.Right.Value == first);
            }

            return areSiblings || 
                AreSiblings(root.Left, first, second) || 
                AreSiblings(root.Right, first, second);
        }

        public List<int> GetAncestors(int value)
        {
            var ancestors = new List<int>();
            GetAncestors(_root, value, ancestors);

            return ancestors;
        }

        private bool GetAncestors(Node root, int value, List<int> ancestors)
        {
            if (root == null)
                return false;

            if (root.Value == value)
                return true;

            if(GetAncestors(root.Left, value, ancestors) || GetAncestors(root.Right, value, ancestors))
            {
                ancestors.Add(root.Value);
                return true;
            }

            return false;
        }
    }
}
