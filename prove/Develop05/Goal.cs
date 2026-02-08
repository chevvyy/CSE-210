using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public abstract int RecordEvent();           // returns points earned this time
    public abstract bool IsComplete();
    public abstract string GetDetailsString();   // short status like [X] or 3/10
    public abstract string GetStringRepresentation();  // for display
    public abstract string GetSaveString();      // for file persistence
}