using System;



using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
    
    List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Core Requirement: Collect numbers until user enters 0
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());
            
            // Only add non-zero numbers to the list
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        
        // Core Requirement 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        
        // Core Requirement 2: Compute the average
        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        
        // Core Requirement 3: Find the maximum (largest) number
        int max = numbers[0]; // Start with first number
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        
        // Display core results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        
        // Stretch Challenge 1: Find smallest positive number (closest to zero)
        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number > 0) // Only consider positive numbers
            {
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }
        
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        // Stretch Challenge 2: Sort and display the list
        numbers.Sort(); // Built-in sort method
        
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}