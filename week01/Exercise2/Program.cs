using System;

class Program
{
    static void Main(string[] args)
    {
       // Core Requirement 1 & 3: Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());
        
        string letter = "";
        
        // Core Requirement 1: Determine letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Stretch Challenge: Add + or - sign
        string sign = "";
        
        // Only add signs for grades that allow them (not A+, F+, or F-)
        if (letter != "F")
        {
            int lastDigit = gradePercentage % 10;
            
            if (letter == "A")
            {
                // A+ doesn't exist, only A or A-
                if (lastDigit < 3)
                {
                    sign = "-";
                }
                // For A, 90-92 is A-, 93-100 is A (no sign)
            }
            else
            {
                // For B, C, D grades
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
                // Otherwise no sign
            }
        }
        
        // Core Requirement 3: Print the final letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
        // Core Requirement 2: Determine if user passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time!");
        }
    }
    
}