using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class HashTableClean
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

        public HashTableClean(int size)
        {
            _entryList = new List<Entry>[size];
            _size = size;
        }

        private int Hash(int key)
        {
            return Math.Abs(key) % _size;
        }

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
                throw new ArgumentException();

            var entries = GetOrCreateEntries(key);
            entries.Add(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry == null ? null : entry.Value;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry != null)
                GetEntries(key).Remove(entry);
        }

        private List<Entry> GetEntries(int key)
        {
            return _entryList[Hash(key)];
        }

        private List<Entry> GetOrCreateEntries(int key)
        {
            var index = Hash(key);
            var entries = _entryList[index];
            if (entries == null)
                _entryList[index] = new List<Entry>();

            return _entryList[index];
        }

        private Entry GetEntry(int key)
        {
            var index = Hash(key);
            var entries = _entryList[index];
            if (entries != null)
            {
                foreach (var e in entries)
                    if (e.Key == key)
                        return e;
            }

            return null;
        }
    }
}
