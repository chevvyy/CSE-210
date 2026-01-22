using System;

class Program
{
    static void Main(string[] args)
    {
        bool _loop = true;
        Fraction fraction = new();
        while (_loop == true)
        {
            string _number = Console.ReadLine();
            fraction.CheckTypeWF(_number);
        }
    }
}