using System;
using System.Collections.Generic;

public class CustomActivity : Activity
{
    private List<string> _userMessages = new();
    private int _timeBetweenMessagesSeconds = 3;
    private bool _useFiller = true;
    private List<string> _fillerActivities = new() { "Stand up and stretch.", "Roll your shoulders.", "Take one deep breath.", "Relax your jaw." };
    private Random _rng = new();

    public CustomActivity()
        : base(
            "Custom Activity",
            "Create your own mindfulness loop: enter messages, choose spacing, and optionally include simple filler prompts."
        )
    { }

    protected override void RunCore()
    {
        CollectUserMessages();
        SetMessageTiming();

        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.WriteLine();

            if (_userMessages.Count > 0)
            {
                Console.WriteLine(_userMessages[i % _userMessages.Count]);
                i++;
            }

            if (_useFiller && _fillerActivities.Count > 0)
            {
                Console.WriteLine(_fillerActivities[_rng.Next(_fillerActivities.Count)]);
            }

            PauseWithSpinner(_timeBetweenMessagesSeconds);
        }
    }

    private void CollectUserMessages()
    {
        Console.WriteLine();
        Console.WriteLine("Enter custom messages (blank line to finish):");

        while (true)
        {
            Console.Write("> ");
            string msg = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(msg)) break;
            _userMessages.Add(msg.Trim());
        }

        if (_userMessages.Count == 0)
        {
            _userMessages.Add("Focus on your breathing and posture.");
        }
    }

    private void SetMessageTiming()
    {
        Console.Write("\nSeconds between messages (default 3): ");
        string input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int seconds) && seconds > 0)
        {
            _timeBetweenMessagesSeconds = seconds;
        }

        Console.Write("Use filler prompts too? (y/n, default y): ");
        string yn = (Console.ReadLine() ?? "").Trim().ToLower();
        _useFiller = (yn == "" || yn == "y" || yn == "yes");
    }
}