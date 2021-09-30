using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Trees
{
    //Insert: O(L) where L is the length of the word.
    //Lookup: O(L) where L is the length of the word.
    //Delete: O(L) where L is the length of the word.
    //Good for implementing auto completion.
    public class Trie
    {
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

            public bool HasChildren()
            {
                return !(Children.Count == 0);
            }

            public void AddChild(char ch)
            {
                Children.Add(ch, new Node(ch));
            }

            public void RemoveChild(char ch)
            {
                Children.Remove(ch);
            }

            public Node GetChild(char ch)
            {
                return Children.ContainsKey(ch) ? Children[ch] : null;
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

        public bool ContainsRecursive(string word)
        {
            if (word == null)
                return false;

            return ContainsRecursive(_root, word, 0);
        }

        private bool ContainsRecursive(Node root, string word, int index)
        {
            if (index == word.Length)
                return root.IsEndOfWord;

            var ch = word[index];
            var child = root.GetChild(ch);
            if (child == null)
                return false;

            return ContainsRecursive(child, word, ++index);
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

        public void Remove(string word)
        {
            if (word == null)
                return;

            Remove(_root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if(index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = root.GetChild(ch);
            if (child == null)
                return;

            Remove(child, word, ++index);
            if (!child.HasChildren() && !child.IsEndOfWord)
                root.RemoveChild(ch);
        }

        public List<string> FindWords(string prefix)
        {
            var lastNode = FindLastNodeOf(prefix);
            var words = new List<string>();
            FindWords(lastNode, prefix, words);

            return words;
        }

        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;

            var current = _root;
            foreach(var c in prefix)
            {
                var child = current.GetChild(c);
                if (child == null)
                    return null;

                current = child;
            }

            return current;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
                return;
            
            if (root.IsEndOfWord)
                words.Add(prefix);

            foreach(var child in root.GetChildren())
                FindWords(child, prefix + child.Value, words);
        }

        public int CountWords()
        {
            return CountWords(_root, 0);
        }

        private int CountWords(Node root, int count)
        {
            foreach(var child in root.GetChildren())
            {
                count = CountWords(child, count);
            }

            if (root.IsEndOfWord)
                return count + 1;
            else
                return count;
        }

        private int CountWords2(Node root)
        {
            var total = 0;

            if (root.IsEndOfWord)
                total++;

            foreach (var child in root.GetChildren())
                total += CountWords2(child);

            return total;
        }

        public void PrintWords()
        {
            PrintWords(_root, "");
        }

        private void PrintWords(Node root, string word)
        {
            if(root.IsEndOfWord)
                Console.WriteLine(word);

            foreach (var child in root.GetChildren())
                PrintWords(child, word + child.Value);
        }

        // Reference from Mosh Hamedani:
        // We add these words to a trie and walk down
        // the trie. If a node has more than one child,
        // that's where these words deviate. Try this
        // with "can", "canada", "care" and "cab". You'll
        // see that these words deviate after "ca".
        //
        // So, we keep walking down the tree as long as
        // the current node has only one child.
        //
        // One edge cases we need to count is when two
        // words are in the same branch and don't deviate.
        // For example "can" and "canada". In this case,
        // we keep walking down to the end because every
        // node (except the last node) has only one child.
        // But the longest common prefix here should be
        // "can", not "canada". So, we should find the
        // shortest word in the list first. The maximum
        // number of characters we can include in the
        // prefix should be equal to the length of the
        // shortest word.
        public static string LongestCommonPrefix(string[] words)
        {
            if (words == null || words.Length == 0)
                return string.Empty;

            var trie = new Trie();
            foreach (var word in words)
                trie.Insert(word);

            var prefix = new StringBuilder();
            var maxChars = GetShortest(words).Length;
            var current = trie._root;
            while(prefix.Length < maxChars)
            {
                var children = current.GetChildren();
                if (children.Length != 1)
                    break;

                current = children[0];
                prefix.Append(current.Value);
            }

            return prefix.ToString();
        }

        private static string GetShortest(string[] words)
        {
            if (words == null || words.Length == 0)
                return string.Empty;

            var shortest = words[0];
            foreach(var word in words)
            {
                if (word.Length < shortest.Length)
                    shortest = word;
            }

            return shortest;
        }
    }
}
