using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureFileLoader
{
    public static List<Scripture> Load(string path)
    {
        var results = new List<Scripture>();

        if (!File.Exists(path))
        {
            Console.WriteLine($"Could not find file: {path}");
            Console.WriteLine("Fix: put scriptures.txt in the same folder as your program runs from.");
            return results;
        }

        string[] lines = File.ReadAllLines(path);

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            // Skip blank lines or comments
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                continue;
            }

            // Format: Book|Chapter|VerseOrRange|Text
            // Example: Proverbs|3|5-6|Trust in the Lord...
            string[] parts = line.Split('|', 4);

            if (parts.Length != 4)
            {
                continue;
            }

            string book = parts[0].Trim();
            string chapterStr = parts[1].Trim();
            string verseStr = parts[2].Trim();
            string text = parts[3].Trim();

            if (!int.TryParse(chapterStr, out int chapter))
            {
                continue;
            }

            Reference reference;

            // Range like "5-6"
            if (verseStr.Contains('-'))
            {
                string[] rangeParts = verseStr.Split('-', 2);
                if (rangeParts.Length != 2) continue;

                if (!int.TryParse(rangeParts[0].Trim(), out int startVerse)) continue;
                if (!int.TryParse(rangeParts[1].Trim(), out int endVerse)) continue;

                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                // Single verse like "16"
                if (!int.TryParse(verseStr, out int verse)) continue;

                reference = new Reference(book, chapter, verse);
            }

            results.Add(new Scripture(reference, text));
        }

        return results;
    }
}