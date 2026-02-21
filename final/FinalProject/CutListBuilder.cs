using System;
using System.Collections.Generic;
using System.Linq;

namespace LaserOrderCalculator
{
    public sealed class CutListBuilder
    {
        public List<OrderItem> Build(List<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));

            // Flatten only the interesting items (polymorphism again)
            return orders
                .SelectMany(o => o.Items)
                .Where(i => i.IsInteresting())
                .ToList();
        }
    }
}