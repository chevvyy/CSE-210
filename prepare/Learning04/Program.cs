using System;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<int> _numbers = [];
        int _number = 1;

        List<int> _sorted = [];
        float _sum = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (_number != 0)
        {
           Console.Write("Wnter number: ");
           _number = int.Parse(Console.ReadLine());
           if (_number != 0)
           {
                _numbers.Add(_number);
           }
            _sum += _number;
        }

        _sorted = _numbers;
        _sorted.Sort();

        float _average = 0;
        int _total = 0;
        int _largest = 0;
        float _smallest = _sum;

        foreach (int i in _sorted)
        {
            _total++;

            if (i > _largest)
            {
                _largest = i;
            }

            if (i > 0 && i < _smallest)
            {
                _smallest = i;
            }

        }

         _average = _sum/_total;

         Console.WriteLine($"The Sum is: {_sum}");
         Console.WriteLine($"The Average is: {_average}");
         Console.WriteLine($"The Largest is: {_largest}");
         Console.WriteLine($"The smallest positive is: {_smallest}");
         Console.WriteLine($"The sorted list is: ");

         foreach (int i in _sorted)
        {
            Console.Write($"{i}, ");
        }

    }
}