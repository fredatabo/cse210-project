using System;
using System.Collections.Generic;

// Base class Shape
public abstract class Shape
{
    protected string Color { get; set; }
    
    public Shape(string color)
    {
        Color = color;
    }
    
    // Virtual method to get area - to be overridden by derived classes
    public abstract double GetArea();
    
    public string GetColor()
    {
        return Color;
    }
}

