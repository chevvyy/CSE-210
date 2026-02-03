using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public string GetDisplayText()
    {
        List<string> output = new List<string>();
        foreach (Word word in _words)
        {
            output.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", output)}";
    }

    public void HideRandomWords(int count)
    {
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        int hides = Math.Min(count, visibleIndexes.Count);

        for (int i = 0; i < hides; i++)
        {
            int pick = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pick];

            _words[wordIndex].Hide();
            visibleIndexes.RemoveAt(pick);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}