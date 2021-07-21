using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class HashTableLinearProbing
    {
        private class Entry
        {
            public int Key { get; private set; }
            public string Value { get; set; }

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private Entry[] _arr;
        private int _count;

        public HashTableLinearProbing(int size)
        {
            _arr = new Entry[size];
        }

        public int Size()
        {
            return _count;
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry == null ? null : entry.Value;
        }

        public void Put(int key, string value)
        {
            if (IsFull())
                throw new StackOverflowException(); 

            var entry = GetEntry(key);
            if(entry != null) // Allow overwriting value of existing entry with the same key
            {
                entry.Value = value;
                return;
            }

            _arr[GetIndex(key)] = new Entry(key, value);
            _count++;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);
            if (index == -1 || _arr[index] == null)
                return;

            _arr[index] = null; // It is important to set it to null instead of just clearing the value.
            _count--;
        }

        private Entry GetEntry(int key)
        {
            var index = GetIndex(key);
            return index >= 0 ? _arr[index] : null;
        }

        private bool IsFull()
        {
            return _count == _arr.Length;
        }

        private int GetIndex(int key)
        {
            var steps = 0;

            while(steps < _arr.Length)
            {
                var index = Index(key, steps++);
                var entry = _arr[index];
                if (entry == null || entry.Key == key) // Here we do not throw an exception when entry.Key = key, which is different from the default Dictionary behavior
                    return index;
            }

            return -1; // When the _arr is full, there is no empty slot.
        }

        private int Index(int key, int i)
        {
            return (Hash(key) + i) % _arr.Length;
        }

        public int Hash(int key)
        {
            return key % _arr.Length;
        }
    }
}
