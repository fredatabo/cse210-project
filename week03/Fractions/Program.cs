using System;
using Fractions;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Testing Constructors ===\n");
        
        // Test constructor 1: no parameters (1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Fraction 1 (default constructor): {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
        
        // Test constructor 2: one parameter (6/1)
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine($"Fraction 2 (single parameter 6): {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");
        
        // Test constructor 3: two parameters (6/7)
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine($"Fraction 3 (6/7): {fraction3.GetFractionString()} = {fraction3.GetDecimalValue():F4}");
        
        Console.WriteLine("\n=== Testing Getters and Setters ===\n");
        
        // Test getters and setters
        Fraction fraction4 = new Fraction(3, 4);
        Console.WriteLine($"Original fraction: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");
        
        // Change values using setters
        Console.WriteLine("\nChanging top from 3 to 5...");
        fraction4.SetTop(5);
        Console.WriteLine($"After setting top to 5: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");
        
        Console.WriteLine("Changing bottom from 4 to 8...");
        fraction4.SetBottom(8);
        Console.WriteLine($"After setting bottom to 8: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");
        
        // Verify getters work
        Console.WriteLine($"\nGetTop() returns: {fraction4.GetTop()}");
        Console.WriteLine($"GetBottom() returns: {fraction4.GetBottom()}");
        
        Console.WriteLine("\n=== Testing Multiple Fractions ===\n");
        
        // Test with different fractions
        Fraction[] testFractions = new Fraction[]
        {
            new Fraction(),           // 1/1
            new Fraction(5),          // 5/1
            new Fraction(3, 4),       // 3/4
            new Fraction(1, 3),       // 1/3
            new Fraction(7, 2),       // 7/2
            new Fraction(2, 5)        // 2/5
        };
        
        foreach (var fraction in testFractions)
        {
            Console.WriteLine($"Fraction: {fraction.GetFractionString(),6} = {fraction.GetDecimalValue(),8:F4}");
        }
        
        // Additional test for the example requested: 1
        Console.WriteLine("\n=== Specific Test: Fraction 1 ===\n");
        Fraction fraction5 = new Fraction(1);
        Console.WriteLine($"Fraction 1 (using single parameter constructor): {fraction5.GetFractionString()} = {fraction5.GetDecimalValue()}");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    }
