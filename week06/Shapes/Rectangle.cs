// Derived class Rectangle
public class Rectangle : Shape
{
    private double Length { get; set; }
    private double Width { get; set; }
    
    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }
    
    public override double GetArea()
    {
        return Length * Width;
    }
    
    public double GetLength()
    {
        return Length;
    }
    
    public double GetWidth()
    {
        return Width;
    }
}

