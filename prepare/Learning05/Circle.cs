public class Circle : Shape
{
    double _radius;
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        double area1 = _radius*_radius;
        area1 = area1*3.14;
        return area1;
    }
}