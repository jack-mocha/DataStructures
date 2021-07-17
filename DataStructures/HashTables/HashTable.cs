using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class HashTable
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

        private List<Entry>[] _entryList;
        private int _size;

        public HashTable(int size)
        {
            _entryList = new List<Entry>[size];
            _size = size;
        }

        private int Hash(int key)
        {
            return Math.Abs(key) % _size;
        }

        public string Get(int key)
        {
            var index = Hash(key);
            var entries = _entryList[index];
            if (entries != null)
            {
                foreach(var e in entries)
                    if (e.Key == key)
                        return e.Value;
            }

            return null;
        }

        public void Put(int key, string value)
        {
            var index = Hash(key);
            if (_entryList[index] == null)
                _entryList[index] = new List<Entry>();

            var entries = _entryList[index];
            foreach (var e in entries)
                if (e.Key == key)
                    throw new ArgumentException();

            entries.Add(new Entry(key, value));
        }

        public void Remove(int key)
        {
            var index = Hash(key);
            var entries = _entryList[index];
            if (entries == null)
                return;

            for(int i = 0; i < entries.Count; i++)
                if (entries[i].Key == key)
                {
                    entries.Remove(entries[i]);
                    return;
                }
        }
    }
}
