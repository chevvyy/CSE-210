using System.Globalization;
using Microsoft.Win32;

class Fraction
{
    private int _top;
    private int _bottom;

    public void FractionWhole()
    {
        SetTop(1);
        SetBottom(1);
    }

    public void FractionOverOne(int wholeNumber)
    {
        SetTop(wholeNumber);
        SetBottom(1);
    }

    public void Fraction(int top, int bottom)
    {
        SetTop(top);
        SetBottom(bottom);
    }


    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int num)
    {
        _top = num;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int num)
    {
        _bottom = num;
    }


    public string GetFractionString()
    {
        string top = _top.ToString();
        string bottom = _bottom.ToString();
        string num = top + "/" + bottom;
        return num;
    }

    public double GetDecimalValue()
    {
        double num = GetTop() / GetBottom();
        return num;
    }

    public int GetWholeNumber(string num)
    {
        char[] numArray = num.ToCharArray();
        string topNum = numArray[0].ToString();
        _top = int.Parse(topNum);
    }

    public int DisplayWhole()
    {
        Console.WriteLine(_top);
    }
}