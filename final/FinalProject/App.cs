using System;
using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public sealed class App
    {
        private readonly ISheetsClient _client;

        private readonly OrderService _orderService;
        private readonly OrderParser _orderParser;
        private readonly OrderFilter _orderFilter;
        private readonly CutListBuilder _cutListBuilder;
        private readonly ConsoleView _consoleView;

        private List<Order> _cachedInterestingOrders = new();
        private List<OrderItem> _cachedCutListItems = new();

        public App(ISheetsClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _orderService = new OrderService(_client);
            _orderParser = new OrderParser();
            _orderFilter = new OrderFilter();
            _cutListBuilder = new CutListBuilder();
            _consoleView = new ConsoleView();
        }

        public void Run()
        {
            RefreshData();

            while (true)
            {
                _consoleView.ShowMenu();

                var choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        _consoleView.ShowOrders(_cachedInterestingOrders);
                        break;

                    case "2":
                        _consoleView.ShowCutList(_cachedCutListItems);
                        break;

                    case "3":
                        RefreshData();
                        _consoleView.ShowInfo("Data refreshed.");
                        break;

                    case "4":
                        _consoleView.ShowInfo("Exiting...");
                        return;

                    default:
                        _consoleView.ShowError("Invalid option. Choose 1-4.");
                        break;
                }
            }
        }

        private void RefreshData()
        {
            var openOrders = _orderService.GetOpenOrders();
            var completedIds = _orderService.GetCompletedIds(daysBack: 21);

            var notCompleted = _orderFilter.RemoveCompleted(openOrders, completedIds);

            foreach (var order in notCompleted)
            {
                _orderParser.ParseItems(order);
            }

            _cachedInterestingOrders = _orderFilter.FilterInteresting(notCompleted);
            _cachedCutListItems = _cutListBuilder.Build(_cachedInterestingOrders);
        }
    }
}