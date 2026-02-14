using System;
using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public sealed class ConsoleView
    {
        public void ShowOrders(List<Order> orders)
        {
            WriteHeader("INTERESTING ORDERS (custom/rails/shelves)");

            foreach (var o in orders)
            {
                Console.WriteLine($"Order {o.Id}");
                foreach (var item in o.Items)
                {
                    Console.WriteLine($"  - {item.Category(),-8} qty={item.Qty} w={item.WidthIn} h={item.HeightIn} area={item.AreaSqIn()}");
                }
                Console.WriteLine();
            }
        }

        public void ShowCutList(List<OrderItem> items)
        {
            WriteHeader("CUT LIST (flattened items)");
            Console.WriteLine($"{"Category",-10} {"Qty",4} {"W",8} {"H",8} {"Area",10}");
            Console.WriteLine(new string('-', 46));

            foreach (var item in items)
                Console.WriteLine($"{item.Category(),-10} {item.Qty,4} {item.WidthIn,8} {item.HeightIn,8} {item.AreaSqIn(),10}");

            Console.WriteLine();
        }

        private static void WriteHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));
        }
    }
}
