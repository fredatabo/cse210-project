using System;
/*
 * ===================================================================
 * SUMMARY OF CREATIVITY ENHANCEMENTS
 * ===================================================================
 * 
 * While not required for this assignment, the following creative
 * enhancements were implemented:
 * 
 * 1. MULTIPLE DEMONSTRATION SETS
 *    - Displayed two separate groups of activities with different
 *      dates and values to show system flexibility
 * 
 * 2. PROFESSIONAL OUTPUT FORMATTING
 *    - Used "dd MMM yyyy" date format (e.g., "03 Nov 2022")
 *    - Applied "F1" decimal formatting for consistent numeric display
 *    - Added headers and separators for better readability
 * 
 * 
 * 4. SELF-DOCUMENTING CODE
 *    - Used meaningful constant (LapLengthInMeters = 50) instead of magic numbers
 *    - Added XML-style comments for documentation
 *    - Used descriptive variable and method names
 * 
 * 6. ENHANCED VISUAL PRESENTATION
 *    - Clear section headers
 *    - Organized output layout
 *    - Professional spacing between entries
 * 
 */

class Program
{
   static void Main(string[] args)
    {
        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Add at least one activity of each type
        activities.Add(new Running(new DateTime(2025, 11, 3), 30, 4.8));
        activities.Add(new Cycling(new DateTime(2025, 11, 4), 45, 25.0));
        activities.Add(new Swimming(new DateTime(2025, 11, 5), 60, 40));

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary\n");
        Console.WriteLine("==========================");

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        // Additional demonstration with different values
        Console.WriteLine("\nAdditional Examples:\n");
        Console.WriteLine("==========================");

        activities.Clear();
        activities.Add(new Running(new DateTime(2026, 6, 15), 25, 3.2));
        activities.Add(new Cycling(new DateTime(2026, 6, 16), 50, 30.5));
        activities.Add(new Swimming(new DateTime(2026, 6, 17), 45, 30));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }

}