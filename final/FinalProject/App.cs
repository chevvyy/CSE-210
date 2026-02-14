using System;
using System.Collections.Generic;
using System.Linq;

namespace LaserOrderCalculator
{
    public sealed class App
    {
        private readonly ISheetsClient _client;
        private readonly OrderService _service;
        private readonly OrderParser _parser;
        private readonly ConsoleView _view;

        public App(ISheetsClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _service = new OrderService(_client);
            _parser = new OrderParser();
            _view = new ConsoleView();
        }

        public void Run()
        {
            try
            {
                var open = _service.GetOpenOrders();
                var completed = _service.GetCompletedIds(daysBack: 21);
                var notCompleted = open.Where(o => !completed.Contains(o.Id)).ToList();

                foreach (var order in notCompleted)
                    _parser.ParseItems(order);

                var interesting = notCompleted.Where(IsInteresting).ToList();
                _view.ShowOrders(interesting);

                var cutList = interesting
                    .SelectMany(o => o.Items)
                    .Where(i => i.Category() is "CUSTOM" or "RAIL" or "SHELF")
                    .ToList();

                _view.ShowCutList(cutList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private static bool IsInteresting(Order order)
        {
            return order.Items.Any(i =>
                i.Category() == "CUSTOM" ||
                i.Category() == "RAIL" ||
                i.Category() == "SHELF");
        }
    }
}
