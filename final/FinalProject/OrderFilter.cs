using System;
using System.Collections.Generic;
using System.Linq;

namespace LaserOrderCalculator
{
    public sealed class OrderFilter
    {
        public List<Order> RemoveCompleted(List<Order> orders, HashSet<string> completedIds)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));
            if (completedIds == null) throw new ArgumentNullException(nameof(completedIds));

            return orders.Where(o => !completedIds.Contains(o.Id)).ToList();
        }

        public List<Order> FilterInteresting(List<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));

            return orders.Where(IsInteresting).ToList();
        }

        private static bool IsInteresting(Order order)
        {
            return order.Items.Any(i => i.IsInteresting());
        }
    }
}