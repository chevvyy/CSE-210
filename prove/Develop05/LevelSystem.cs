using System;
using System.Collections.Generic;
using System.IO;

public class LevelSystem
{
    private int _level = 1;
    private int _xp = 0;
    private int _nextLevelXp = 1000;  // XP needed for next level

    public void AddPoints(int points)
    {
        _xp += points;
        Console.WriteLine($"Gained {points} XP. Total XP: {_xp}");

        while (_xp >= _nextLevelXp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _xp -= _nextLevelXp;
        _nextLevelXp = (int)(_nextLevelXp * 1.5);  // progressive difficulty

        Console.WriteLine($"\n╔════════════════════════════╗");
        Console.WriteLine($"║       LEVEL UP! Level {_level}      ║");
        Console.WriteLine($"╚════════════════════════════╝");
        Console.WriteLine($"Next level requires {_nextLevelXp} XP\n");
    }

    public int GetLevel() => _level;

    public string GetStatus()
    {
        return $"Level: {_level} | XP: {_xp} / {_nextLevelXp}";
    }

    // For saving
    public string GetSaveString()
    {
        return $"{_level}|{_xp}|{_nextLevelXp}";
    }

    // For loading
    public void LoadFromString(string data)
    {
        var parts = data.Split('|');
        if (parts.Length == 3)
        {
            _level = int.Parse(parts[0]);
            _xp = int.Parse(parts[1]);
            _nextLevelXp = int.Parse(parts[2]);
        }
    }
}