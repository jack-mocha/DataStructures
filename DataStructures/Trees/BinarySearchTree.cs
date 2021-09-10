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
    }
}
