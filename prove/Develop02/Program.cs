using System;
using System.IO;

class Program
{ 
    static void Main(string[] args)
    {
        Journal j = new();
        bool _currentEntry = false;
        bool _openJournal = true;
        Console.WriteLine("Welcome to you journal, what would you like to do? Enter the Number");
        while (_openJournal == true){
            Console.WriteLine("\n1 - Write New Entry");
            Console.WriteLine("2 - Display Journal");
            Console.WriteLine("3 - Load Entry");
            Console.WriteLine("4 - Delete Entry");
            if (_currentEntry == true)
            {
                Console.WriteLine("5 - Save current Entry");
            }
            else
            {
                Console.WriteLine("5 - Unavailable until entry entered");
            }
            Console.WriteLine("6 - Exit Journal\n");

            int _menu = int.Parse(Console.ReadLine());
            
            if (_menu == 1)
            {
                j.AddEntry();
                _currentEntry = true;
            }
            else if (_menu == 2)
            {
                j.DisplayEntry();
            }
            else if (_menu == 3)
            {
                _currentEntry = j.LoadFile();
            }
            else if (_menu == 4)
            {
                j.DeleteEntry();
            }
            else if (_menu == 5)
            {
                j.SaveToFile();
            }
            else if (_menu == 6)
            {
                Console.WriteLine("Goodbye.");
                _openJournal = false;
            }
            else
            {
                Console.WriteLine("Invalid Menue item, try again.");
            }
        }
    }
}