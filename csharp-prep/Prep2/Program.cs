using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade precentage? ");
        string tempgrade = Console.ReadLine();
        int grade = int.Parse(tempgrade);
        string gradeLetter = "";
        string pass = "";

        if (grade >= 90)
        {
            gradeLetter = "A";
            pass = "Pass";
        }
        else if (grade >= 80)
        {
            gradeLetter = "B";
            pass = "Pass";
        }
        else if (grade >= 70)
        {
            gradeLetter = "C";
            pass = "Pass";
        }
        else if (grade >= 60)
        {
            gradeLetter = "D";
            pass = "Fail";
        }
        else
        {
            gradeLetter = "F";
            pass = "Fail";
        }
        Console.WriteLine($"Your grade is {gradeLetter} and you {pass}");
        if (pass == "Pass")
        {
            Console.WriteLine("Congrats!");
        }
        else
        {
            Console.WriteLine("Good luck next time.");
        }
    }
}