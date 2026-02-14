using System;

namespace LaserOrderCalculator
{
    public sealed class OrderParser
    {
        public void ParseItems(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            order.Items.Clear();

            var parts = (order.Raw ?? "")
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var rawItem in parts)
            {
                var item = CreateItem(rawItem);
                item.Parse(rawItem);
                order.AddItem(item);
            }
        }

        private OrderItem CreateItem(string raw)
        {
            var type = raw.Split('|', 2, StringSplitOptions.TrimEntries)[0].ToUpperInvariant();

            return type switch
            {
                "CUSTOM" => new CustomItem(),
                "RAIL" => new RailItem(),
                "SHELF" => new ShelfItem(),
                "STANDARD" => new StandardItem(),
                _ => new StandardItem(),
            };
        }
    }
}
