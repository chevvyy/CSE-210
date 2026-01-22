
class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;
    static DateTime _current = DateTime.Now;
    static DateOnly  _current2 = DateOnly.FromDateTime(_current);
    Random random = new Random();

    public void Entry1(string[] prompts)
    {
        _date = _current2.ToString();

        int _random = random.Next(0,4);
        _prompt = prompts[_random];

        Console.WriteLine(_prompt);
        Console.WriteLine("Enter your entry: ");
        _response = Console.ReadLine();

        Console.WriteLine("How did you feel Today?");
        _mood = Console.ReadLine();

    }

    public void MemFetch(out string _date, out string _prompt, out string _response, out string _mood)
    {
        _date =  this._date; 
        _prompt = this._prompt;
        _response = this._response;
        _mood = this._mood;
    }

    public void MemStore(string textPath)
    {
        string[] text = File.ReadAllLines(textPath);
        _date = text[0];
        _prompt = text[1];
        _response = text[2];
        _mood = text[3];
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine("");
        Console.WriteLine($"Entry Response:");
        Console.WriteLine($"{_response}");
        Console.WriteLine("");
        Console.WriteLine($"Mood: {_mood}");
    }    
}