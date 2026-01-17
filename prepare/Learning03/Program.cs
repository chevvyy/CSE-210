using System;

class Program
{
    static void Main(string[] args)
    {
        string _response;
        do
        {
            int _number = Random.Shared.Next(1,50);
            int _guesses = 0;
            Guess guess = new Guess();
            int _guess = 0;

            while (_guess != _number)
            {
                Console.Write("What is your guess? ");
                _guess = int.Parse(Console.ReadLine());

                string _correct = guess.Guessed(_guess, _number);
                _guesses++;
                
                Console.WriteLine($"{_correct}");
            }
            Console.WriteLine($"You got the Number in {_guesses} guesses");
            Console.Write("Would you like to play again? ");
            _response = Console.ReadLine().ToUpper();
        } while (_response == "YES");

    }
}