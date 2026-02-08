using System;
using System.Collections.Generic;
using System.IO;

public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int bonus, int targetCount, int completed = 0)
        : base(name, description, points)
    {
        _bonus = bonus;
        _targetCount = targetCount;
        _amountCompleted = completed;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal is already fully completed.");
            return 0;
        }

        _amountCompleted++;
        int earned = _points;

        if (IsComplete())
        {
            earned += _bonus;
            Console.WriteLine($"Fully completed '{_name}'! +{_points} + bonus {_bonus} = {earned} points");
        }
        else
        {
            Console.WriteLine($"Progress on '{_name}': {_amountCompleted}/{_targetCount} (+{_points} points)");
        }

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _targetCount;

    public override string GetDetailsString()
    {
        return $"Completed {_amountCompleted}/{_targetCount} times {(IsComplete() ? "[X]" : "[ ]")}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetDetailsString()} {_name} — {_description}";
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_amountCompleted}";
    }
}