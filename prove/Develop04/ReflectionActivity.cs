using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn that applies to other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rng = new();

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
    { }

    protected override void RunCore()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("When you have something in mind, press Enter to continue. ");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());

        while (DateTime.Now < end)
        {
            string q = _questions[_rng.Next(_questions.Count)];
            Console.WriteLine();
            Console.Write(q + " ");
            PauseWithSpinner(5);
        }
    }
}