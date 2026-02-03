using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        
        string path = "scriptures.txt";

        List<Scripture> library = ScriptureFileLoader.Load(path);

        if (library.Count == 0)
        {
            Console.WriteLine("No valid scriptures found in scriptures.txt.");
            return;
        }

        Random rng = new Random();
        Scripture scripture = library[rng.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Nice.");
                break;
            }

            Console.Write("\nPress Enter to hide more words or type 'quit' to finish: ");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}