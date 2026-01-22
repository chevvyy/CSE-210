public class Journal
{
    //Fix path using directory code so that it can work on any device that runs program.
    private static string _jPath = @"JournalFolder";
    private static string _tPath = @"Prompt.txt"; //prove\Develop02\JournalFolder\Prompt.txt
    private static string _gPath = @"Glossary.txt";
    private static string _bPath = Directory.GetCurrentDirectory();
    static string _promptPath = Path.Combine(_bPath, _jPath, _tPath);
    static string _journalPath = Path.Combine(_bPath, _jPath);
    static string _glossaryPath = Path.Combine(_bPath, _jPath, _gPath);

    Entry e = new();
    
    private readonly string[] _prompts = File.ReadAllLines(_promptPath);
    string _prompt;
    string _entries;
    private readonly Random random = new Random();

    public string GetPromptPath()
    {
        return _promptPath;
    }

    public void AddEntry()
    {
        e.Entry1(_prompts);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        e.Display();
    }

    public void DeleteEntry()
    {
        Console.WriteLine("Which Entry would you like to delete?");
        string _item = Console.ReadLine();
        string textPath = Path.Combine(_journalPath, @_item);
        if (File.Exists(textPath) == true)
        {
            Console.Write("type YES if you are sure: ");
            string answer = Console.ReadLine();
            answer.ToUpper();
            if (answer == "YES")
            {
                File.Delete(textPath);
                string[] glossary = File.ReadAllLines(_glossaryPath);
                DeleteLine(_glossaryPath, _item);
                Console.WriteLine("File deleted");
            }
            else
            {
                Console.WriteLine("File not deleted.");
            }
        }
        else
        {
            Console.WriteLine("Entry does not exist");
            Console.WriteLine(textPath);
        }
    }
    public void DisplayEntry()
    {
        string[] _glossary = File.ReadAllLines(_glossaryPath);
        foreach (string x in _glossary)
        {
           Console.WriteLine(x);
        }
    }

    public void SaveToFile()
    {
        e.MemFetch(out string _date, out string _prompt, out string _response, out string _mood);
        _date = _date.Replace('/', '-');
        string textPath = Path.Combine(_journalPath, @_date);
        List<string> text = new List<string>
        {
            _date,
            _prompt,
            _response,
            _mood
        };
        if (File.Exists(textPath) == false)
        {

            File.WriteAllLines(textPath, text);
            File.AppendAllText(_glossaryPath, "\n" + _date);
            Console.WriteLine("Saved\n");
        }
        else
        {
            Console.WriteLine("Error While Saving");
        }
    }

    public bool LoadFile()
    {
        Console.WriteLine("Which Entry would you like to see?");
        string _item = Console.ReadLine();
        string textPath = Path.Combine(_journalPath, @_item);
        if (File.Exists(textPath) == true)
        {
            e.MemStore(textPath);
            e.Display();
            return true;
        }
        else
        {
            Console.WriteLine("Entry does not exist");
            Console.WriteLine(textPath);
            return false;
        }
    }


    public void DeleteLine(string textPath, string textToDelete)
    {
        List<string> lines = File.ReadLines(textPath).Where(line => line != textToDelete).ToList();
        File.WriteAllLines(textPath, lines);
    }
}