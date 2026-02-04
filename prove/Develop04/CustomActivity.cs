using System;
using System.Collections.Generic;
using System.IO;

public class CustomActivity : Activity
{
    private List<string> _userMessages = new();
    private List<string> _fillerActivities = new();
    private int _timeBetweenMessagesSeconds = 3;
    private bool _useFiller = true;

    private static readonly string ConfigFilePath =
        Path.Combine(AppContext.BaseDirectory, "custom_activity.txt");

    private Random _rng = new();

    private CustomActivity()
        : base(
            "Custom Activity",
            "A user-built mindfulness loop. You define messages, timing, and optional filler prompts."
        )
    { }

    // ======== MENU ACTIONS ========

    public static void RunFromSaved()
    {
        CustomActivity activity = File.Exists(ConfigFilePath) ? Load() : CreateAndSave();
        activity.Start();
    }

    public static void EditAndSave()
    {
        CustomActivity activity = File.Exists(ConfigFilePath) ? Load() : new CustomActivity();

        activity.SetupWizard();
        activity.Save();

        Console.WriteLine("\nSaved. Press Enter to return to menu.");
        Console.ReadLine();
    }

    public static void ResetAndCreate()
    {
        if (File.Exists(ConfigFilePath))
        {
            File.Delete(ConfigFilePath);
        }

        CreateAndSave();

        Console.WriteLine("\nReset complete. Press Enter to return to menu.");
        Console.ReadLine();
    }

    private static CustomActivity CreateAndSave()
    {
        var activity = new CustomActivity();
        activity.SetupWizard();
        activity.Save();
        return activity;
    }

    // ======== ACTIVITY CORE ========

    protected override void RunCore()
    {
        if (_userMessages.Count == 0)
        {
            _userMessages.Add("Focus on steady breathing and relax your shoulders.");
        }

        DateTime end = DateTime.Now.AddSeconds(GetDurationSeconds());
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.WriteLine();
            Console.WriteLine(_userMessages[i % _userMessages.Count]);
            i++;

            if (_useFiller && _fillerActivities.Count > 0)
            {
                Console.WriteLine(_fillerActivities[_rng.Next(_fillerActivities.Count)]);
            }

            PauseWithSpinner(_timeBetweenMessagesSeconds);
        }
    }

    // ======== SETUP WIZARD ========

    private void SetupWizard()
    {
        Console.Clear();
        Console.WriteLine("Custom Activity Setup");
        Console.WriteLine("\nEnter your custom messages (blank line to finish):");

        _userMessages.Clear();
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

        Console.Write("\nSeconds between messages (default 3): ");
        string t = Console.ReadLine() ?? "";
        if (int.TryParse(t, out int seconds) && seconds > 0)
            _timeBetweenMessagesSeconds = seconds;
        else
            _timeBetweenMessagesSeconds = 3;

        Console.Write("Use filler prompts too? (y/n, default y): ");
        string yn = (Console.ReadLine() ?? "").Trim().ToLower();
        _useFiller = (yn == "" || yn == "y" || yn == "yes");

        _fillerActivities.Clear();
        if (_useFiller)
        {
            Console.WriteLine("\nEnter filler prompts (blank line to finish).");
            Console.WriteLine("Examples: 'Relax your jaw.' 'Unclench your hands.'");

            while (true)
            {
                Console.Write("> ");
                string filler = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(filler)) break;
                _fillerActivities.Add(filler.Trim());
            }

            if (_fillerActivities.Count == 0)
            {
                _fillerActivities.AddRange(new[]
                {
                    "Relax your jaw.",
                    "Drop your shoulders.",
                    "Take one slow breath in and out.",
                    "Unclench your hands."
                });
            }
        }
    }

    // ======== SAVE / LOAD ========
    // File format:
    // timeBetween=3
    // useFiller=true
    // [MESSAGES]
    // message line...
    // [FILLER]
    // filler line...
    private void Save()
    {
        using StreamWriter sw = new StreamWriter(ConfigFilePath);

        sw.WriteLine($"timeBetween={_timeBetweenMessagesSeconds}");
        sw.WriteLine($"useFiller={_useFiller.ToString().ToLower()}");

        sw.WriteLine("[MESSAGES]");
        foreach (var m in _userMessages) sw.WriteLine(m);

        sw.WriteLine("[FILLER]");
        foreach (var f in _fillerActivities) sw.WriteLine(f);
    }

    private static CustomActivity Load()
    {
        var activity = new CustomActivity();

        string[] lines = File.ReadAllLines(ConfigFilePath);

        bool inMessages = false;
        bool inFiller = false;

        foreach (string raw in lines)
        {
            string line = raw.TrimEnd();

            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.StartsWith("timeBetween="))
            {
                string val = line.Substring("timeBetween=".Length);
                if (int.TryParse(val, out int seconds) && seconds > 0)
                    activity._timeBetweenMessagesSeconds = seconds;
                continue;
            }

            if (line.StartsWith("useFiller="))
            {
                string val = line.Substring("useFiller=".Length).Trim().ToLower();
                activity._useFiller = (val == "true");
                continue;
            }

            if (line == "[MESSAGES]")
            {
                inMessages = true;
                inFiller = false;
                continue;
            }

            if (line == "[FILLER]")
            {
                inMessages = false;
                inFiller = true;
                continue;
            }

            if (inMessages) activity._userMessages.Add(line.Trim());
            else if (inFiller) activity._fillerActivities.Add(line.Trim());
        }

        if (activity._userMessages.Count == 0)
            activity._userMessages.Add("Focus on steady breathing and posture.");

        if (activity._useFiller && activity._fillerActivities.Count == 0)
        {
            activity._fillerActivities.AddRange(new[]
            {
                "Relax your jaw.",
                "Drop your shoulders.",
                "Take one slow breath in and out.",
                "Unclench your hands."
            });
        }

        return activity;
    }
}