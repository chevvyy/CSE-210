using System;
using System.Collections.Generic;

// Temporary for me but final for the project

namespace LaserOrderCalculator
{
    public sealed class MockSheetsClient : ISheetsClient
    {
        private readonly Dictionary<string, List<List<string>>> _data = new(StringComparer.OrdinalIgnoreCase)
        {
            // Open orders (each row: OrderId, RawLineItems)
            ["OpenOrders!A2:B"] = new List<List<string>>
            {
                new() { "1001", "CUSTOM|qty=2|w=12|h=18; RAIL|qty=4|w=1.5|h=36; SHELF|qty=1|w=24|h=36" },
                new() { "1002", "STANDARD|qty=6|w=4|h=6; RAIL|qty=2|w=1.5|h=24" },
                new() { "1003", "SHELF|qty=2|w=18|h=18; STANDARD|qty=1|w=10|h=10" },
                new() { "1004", "STANDARD|qty=3|w=2|h=8" },
            },

            // Completed order IDs
            ["Completed!A2:A"] = new List<List<string>>
            {
                new() { "1004" }
            }
        };

        public List<List<string>> Read(string rangeA1)
        {
            if (_data.TryGetValue(rangeA1, out var rows))
                return rows;

            return new List<List<string>>();
        }
    }
}
