using System;
using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public sealed class Order
    {
        private readonly List<OrderItem> _items = new();

        public string Id { get; }
        public string Raw { get; }

        public IReadOnlyList<OrderItem> Items => _items;

        public Order(string id, string raw)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Raw = raw ?? "";
        }

        public void AddItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}