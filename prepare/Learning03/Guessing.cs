class Guess
{
    public string Guessed(int guess, int number)
        {
            string _check = "";
            if (guess == number)
            {
                _check = "You guessed it!";
            }

            else if (guess > number)
            {
                _check = "Lower";
            }

            else if (guess < number)
            {
                _check = "Higher";
            }

            return _check;
        }
}