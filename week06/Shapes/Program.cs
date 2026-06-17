using System;
using System.Collections.Generic;


class Program
{
     static void DisplayShapeInfo(Shape shape)
    {
        Console.Write($"Color: {shape.GetColor()}");
        
        // Use pattern matching to determine the actual type
        switch (shape)
        {
            case Square square:
                Console.Write($" (Square, side: {square.GetSide()})");
                break;
            case Rectangle rect:
                Console.Write($" (Rectangle, {rect.GetLength()}x{rect.GetWidth()})");
                break;
            case Circle circle:
                Console.Write($" (Circle, radius: {circle.GetRadius()})");
                break;
        }
        
        Console.WriteLine($" -> Area: {shape.GetArea():F2}");
    }
    
    static void Main()
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();
        
        // Add different shapes to the list
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));
        shapes.Add(new Square("Yellow", 7.5));
        shapes.Add(new Rectangle("Purple", 3.5, 8.2));
        shapes.Add(new Circle("Orange", 2.5));
        shapes.Add(new Square("White", 10.0));
        
        Console.WriteLine("=== Shape Information ===");
        Console.WriteLine("------------------------");
        
        // Iterate through the list and display areas using polymorphism
        foreach (var shape in shapes)
        {
            DisplayShapeInfo(shape);
        }
        
        Console.WriteLine("------------------------");
        Console.WriteLine($"Total shapes: {shapes.Count}");
        
        // Calculate and display total area
        double totalArea = 0.0;
        foreach (var shape in shapes)
        {
            totalArea += shape.GetArea();
        }
        Console.WriteLine($"Total area of all shapes: {totalArea:F2}");
    }

}