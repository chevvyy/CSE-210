class Rectangle : Shape
{
    double _side1;
    double _side2;
    public Rectangle(string color, double side1, double side2) : base(color)
    {
        _side1 = side1;
        _side2 = side2;
    }

    public override double GetArea()
    {
        double area = _side1*_side2;
        return area;
    }
}