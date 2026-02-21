using System;
using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public sealed class OrderService
    {
        private readonly ISheetsClient _client;

        public OrderService(ISheetsClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public List<Order> GetOpenOrders()
        {
            var rows = _client.Read("OpenOrders!A2:B");
            var orders = new List<Order>();

            foreach (var row in rows)
            {
                if (row.Count < 2) continue;

                var id = row[0];
                var raw = row[1];

                if (string.IsNullOrWhiteSpace(id)) continue;

                orders.Add(new Order(id, raw));
            }

            return orders;
        }

        public HashSet<string> GetCompletedIds(int daysBack)
        {
            var rows = _client.Read("Completed!A2:A");
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var row in rows)
            {
                if (row.Count == 0) continue;

                var id = row[0];
                if (!string.IsNullOrWhiteSpace(id))
                {
                    set.Add(id);
                }
            }

            return set;
        }
    }
}