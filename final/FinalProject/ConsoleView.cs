using System;
using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public sealed class ConsoleView
    {
        public void ShowMenu()
        {
            WriteHeader("LASER ORDER CALCULATOR");
            Console.WriteLine("1) Show interesting orders");
            Console.WriteLine("2) Show cut list");
            Console.WriteLine("3) Refresh data");
            Console.WriteLine("4) Exit");
            Console.Write("Choose: ");
        }

        public void ShowOrders(List<Order> orders)
        {
            WriteHeader("INTERESTING ORDERS");

            if (orders.Count == 0)
            {
                Console.WriteLine("No interesting orders found.\n");
                return;
            }

            foreach (var o in orders)
            {
                Console.WriteLine($"Order {o.Id}");
                foreach (var item in o.Items)
                {
                    if (!item.IsInteresting()) continue;

                    Console.WriteLine($"  - {item.Category(),-7} qty={item.Qty} w={item.WidthIn} h={item.HeightIn} area={item.AreaSqIn()}");
                }
                Console.WriteLine();
            }
        }

        public void ShowCutList(List<OrderItem> items)
        {
            WriteHeader("CUT LIST");

            if (items.Count == 0)
            {
                Console.WriteLine("No cut list items.\n");
                return;
            }

            Console.WriteLine($"{"Category",-10} {"Qty",4} {"W",8} {"H",8} {"Area",10}");
            Console.WriteLine(new string('-', 46));

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Category(),-10} {item.Qty,4} {item.WidthIn,8} {item.HeightIn,8} {item.AreaSqIn(),10}");
            }

            Console.WriteLine();
        }

        public void ShowError(string message)
        {
            Console.WriteLine($"ERROR: {message}\n");
        }

        public void ShowInfo(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        private static void WriteHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));
        }
    }
}