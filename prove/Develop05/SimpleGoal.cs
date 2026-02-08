using System;
using System.Collections.Generic;
using System.IO;

public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }

        _isComplete = true;
        Console.WriteLine($"Completed '{_name}'! +{_points} points");
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetDetailsString()} {_name} — {_description}";
    }

    public override string GetSaveString()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}