using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        string _name;
        double _number;
        DateTime _date = DateTime.Now;
        int _year = _date.Year;
        int _age;

        PromptUserName(out _name);
        PromptUserNumber(out _number);
        PromptUserBirthYear(out _age, _year);
        double _square = SquareNumber(_number);
        DisplayResult(_square, _name, _age);
        
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static void PromptUserName(out string name)
    {
        Console.Write("Please enter your name: ");
        name = Console.ReadLine();
    }

    static void PromptUserNumber(out double number)
    {
        Console.Write("Please enter your favorite number: ");
        number = int.Parse(Console.ReadLine());
    }

    static void PromptUserBirthYear(out int age, int _year)
    {
        Console.Write("Please enter the year you were born: ");
        age = int.Parse(Console.ReadLine());
        age = _year-age;
    }

    static double SquareNumber(double number)
    {
        number = Math.Pow(number,2);
        return number;
    }

    static void DisplayResult(double square, string name, int age)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
        Console.Write($"{name}, you will be turning {age} this year.");
    }
}