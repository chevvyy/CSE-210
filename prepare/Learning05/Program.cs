using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 9));
        shapes.Add(new Circle("blue", 12));
        shapes.Add(new Rectangle("green", 12,5));

        foreach (Shape i in shapes)
        {
            Console.WriteLine(i.GetArea());
            Console.WriteLine(i.GetColor());
        }
    }
}