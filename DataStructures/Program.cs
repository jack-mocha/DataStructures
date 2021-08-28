using DataStructures.HashTables;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = new Dictionary<string, string>()
            {
                { "Chennai", "Banglore"},
                { "Bombay", "Delhi" },
                { "Goa", "Chennai" },
                { "Delhi", "Goa" }
            };

            var map = new HashTableOps();
            map.PrintItinerary(tickets);
        }
    }
}
