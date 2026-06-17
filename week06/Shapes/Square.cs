// Derived class Square
using System;
public class Square : Shape
{
    private double Side { get; set; }
    
    public Square(string color, double side) : base(color)
    {
        Side = side;
    }
    
    public override double GetArea()
    {
        return Side * Side;
    }
    
    public double GetSide()
    {
        return Side;
    }
}
