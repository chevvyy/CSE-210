using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Win32;

class Fraction
{
    private int _top;
    private int _bottom;
    private int _whole;
    private decimal _decimal;

    public void FractionWhole()
    {
        SetTop("1/1");
        SetBottom("1/1");
    }

    public void FractionOverOne(string wholeNumber)
    {
        SetTop(wholeNumber);
        SetBottom("1");
    }

    public void Fraction1(string top, string bottom)
    {
        SetTop(top);
        SetBottom(bottom);
    }


    public int GetTop()
    {
        return _top;
    }

    public void SetTop(string num)
    {
        string symbol = "/";
        string[] numArray = num.Split(symbol);
        string topNum = numArray[0].ToString();
        _top = int.Parse(topNum);
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(string num)
    {
        string symbol = "/";
        string[] numArray = num.Split(symbol);
        string bottomNum = numArray[1].ToString();
        _bottom = int.Parse(bottomNum);
    }


    public string GetFractionString()
    {
        string top = _top.ToString();
        string bottom = _bottom.ToString();
        string num = top + "/" + bottom;
        return num;
    }

    public decimal GetDecimalValue()
    {
        decimal num = (decimal) GetTop() / GetBottom();
        return num;
    }

    public void DisplayWhole()
    {
        Console.WriteLine(_top);
    }

    public void CheckTypeWF(string num)
    {
        if (num.Contains("/"))
        {
            if (num == "1/1")
            {
                FractionWhole();
                Console.WriteLine("1");
            }
            else
            {
                SetTop(num);
                SetBottom(num);
                _decimal = GetDecimalValue();
                Console.WriteLine(_decimal);
            }
        }
        else
        {
            _whole = int.Parse(num);
            Console.WriteLine($"{_whole}/1");
        }
    }
}