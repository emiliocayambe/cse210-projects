public class Square : Shape
{
    private double _side;

    public Square(string color, double sideLength) : base(color)
    {
        _side = sideLength;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}