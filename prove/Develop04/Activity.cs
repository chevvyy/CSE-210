using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        SetDurationFromUser();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
        RunCore();

        Finish();
    }

    public void Finish()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void SetDurationFromUser()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine() ?? "0";
        int.TryParse(input, out _durationSeconds);
        if (_durationSeconds < 1) _durationSeconds = 30; // sane default
    }

    protected int GetDurationSeconds() => _durationSeconds;

    protected abstract void RunCore();

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void PauseWithSpinner(int seconds) => ShowSpinner(seconds);
}