using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _rng = new();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    { }

    protected override void RunCore()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing items (press Enter after each one):");

        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(item))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");
    }
}