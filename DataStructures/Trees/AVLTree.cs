using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class AVLTree
    {
        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; private set; }
            public int Height { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Value=" + this.Value;
            }
        }

        private Node _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        private Node Insert(Node root, int value)
        {
            if (root == null)
                return new Node(value);

            if (value > root.Value)
                root.Right = Insert(root.Right, value);
            if (value < root.Value)
                root.Left = Insert(root.Left, value);

            SetHeight(root);

            root = Balance(root);

            return root;
        }

        private Node Balance(Node root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.Left) < 0)
                {
                    Console.WriteLine("Rotate Left: " + root.Left.Value);
                    root.Left = RotateLeft(root.Left);
                }
                Console.WriteLine("Rotate Right: " + root.Value);
                root = RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if(BalanceFactor(root.Right) > 0)
                {
                    Console.WriteLine("Rotate Right: " + root.Right.Value);
                    root.Right = RotateRight(root.Right);
                }
                Console.WriteLine("Rotate Left: " + root.Value);
                root = RotateLeft(root);
            }

            return root;
        }

        private Node RotateLeft(Node root)
        {
            var newRoot = root.Right;
            Console.WriteLine(newRoot.Left);
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private Node RotateRight(Node root)
        {
            var newRoot = root.Left;
            Console.WriteLine(newRoot.Right);
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private void SetHeight(Node node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private bool IsLeftHeavy(Node node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(Node node)
        {
            return BalanceFactor(node) < -1;
        }

        private int BalanceFactor(Node node)
        {
            return (node == null) ? 0 : Height(node.Left) - Height(node.Right);
        }

        private int Height(Node node)
        {
            return node == null ? -1 : node.Height;
        }
    }
}
