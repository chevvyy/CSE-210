using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private LevelSystem _levelSystem = new LevelSystem();

    static void Main(string[] args)
    {
        Program app = new Program();
        app.Run();
    }

    private void Run()
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        while (true)
        {
            ShowMenu();
            Console.Write("Select an option: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": DisplayPlayerStatus(); break;
                case "5": Save("goals.txt"); break;
                case "6": Load("goals.txt"); break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nEternal Quest Menu:");
        Console.WriteLine("1. Create new goal");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Record event");
        Console.WriteLine("4. Show score & level");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Load");
        Console.WriteLine("7. Quit");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal types:");
        Console.WriteLine("  A) Simple goal (one-time)");
        Console.WriteLine("  B) Eternal goal (repeatable forever)");
        Console.WriteLine("  C) Checklist goal (complete X times + bonus)");
        Console.Write("Choose type (A/B/C): ");
        string type = Console.ReadLine()?.ToUpper();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points per completion: ");
        if (!int.TryParse(Console.ReadLine(), out int points)) return;

        Goal goal = null;

        if (type == "A")
        {
            goal = new SimpleGoal(name, desc, points);
        }
        else if (type == "B")
        {
            goal = new EternalGoal(name, desc, points);
        }
        else if (type == "C")
        {
            Console.Write("Bonus points when fully completed: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus)) return;

            Console.Write($"How many times to complete? (target): ");
            if (!int.TryParse(Console.ReadLine(), out int target)) return;

            goal = new ChecklistGoal(name, desc, points, bonus, target);
        }
        else
        {
            Console.WriteLine("Invalid type.");
            return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            Console.WriteLine($"{i + 1}. {g.GetStringRepresentation()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        if (_goals.Count == 0) return;

        Console.Write("\nWhich goal number did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > _goals.Count)
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        Goal selected = _goals[num - 1];
        int earned = selected.RecordEvent();

        if (earned > 0)
        {
            _score += earned;
            _levelSystem.AddPoints(earned);
        }
    }

    private void DisplayPlayerStatus()
    {
        Console.WriteLine("\nPlayer Status");
        Console.WriteLine($"Total Score: {_score}");
        Console.WriteLine(_levelSystem.GetStatus());
    }

    private void Save(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_levelSystem.GetSaveString());

            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
        Console.WriteLine("Progress saved.");
    }

    private void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        _goals.Clear();

        var lines = File.ReadAllLines(filename);
        if (lines.Length < 2) return;

        _score = int.Parse(lines[0]);
        _levelSystem.LoadFromString(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            var parts = lines[i].Split('|');
            if (parts.Length < 4) continue;

            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            Goal g = null;

            if (type == "Simple")
            {
                bool done = bool.Parse(parts[4]);
                g = new SimpleGoal(name, desc, points, done);
            }
            else if (type == "Eternal")
            {
                g = new EternalGoal(name, desc, points);
            }
            else if (type == "Checklist" && parts.Length >= 7)
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int completed = int.Parse(parts[6]);
                g = new ChecklistGoal(name, desc, points, bonus, target, completed);
            }

            if (g != null) _goals.Add(g);
        }

        Console.WriteLine("Progress loaded.");
    }
}