using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Trees
{
    public class Trie
    {
        public static int ALPHABET_SIZE = 26;

        private class Node
        {
            public Dictionary<char, Node> Children = new Dictionary<char, Node>();
            public char Value { get; set; }
            public bool IsEndOfWord { get; set; }

            public Node(char value)
            {
                this.Value = value;
            }

            public override string ToString()
            {
                return "value=" + this.Value;
            }

            public bool HasChild(char ch)
            {
                return Children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                Children.Add(ch, new Node(ch));
            }

            public Node GetChild(char ch)
            {
                return Children[ch];
            }

            public Node[] GetChildren()
            {
                return Children.Values.ToArray();
            }
        }
        
        private Node _root = new Node((char)0);

        public void Insert(string word)
        {
            var current = _root;
            foreach(var c in word)
            {
                if (!current.HasChild(c))
                    current.AddChild(c);

                current = current.GetChild(c);
            }

            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
                return false;

            var current = _root;
            foreach(var c in word)
            {
                if (!current.HasChild(c))
                    return false;

                current = current.GetChild(c);
            }

            return current.IsEndOfWord;
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(_root);
        }

        private void PreOrderTraversal(Node root)
        {
            Console.WriteLine(root.Value);

            foreach (var node in root.GetChildren())
                PreOrderTraversal(node);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(_root);
        }

        private void PostOrderTraversal(Node root)
        {
            foreach (var node in root.GetChildren())
                PostOrderTraversal(node);
            
            Console.WriteLine(root.Value);

        }
    }
}
