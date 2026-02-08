using System;
using System.Collections.Generic;
using System.IO;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Recorded '{_name}' → +{_points} points");
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return "[∞]";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetDetailsString()} {_name} — {_description}";
    }

    public override string GetSaveString()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}