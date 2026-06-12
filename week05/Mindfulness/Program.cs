using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            // EXCEEDING REQUIREMENTS:
            // 1. Added a gratitude activity as a 4th option
            // 2. Keeps a log of all activities with timestamps (saved to file)
            // 3. Log file persists between sessions and loads automatically
            // 4. Ensures all prompts/questions are used before repeating in a session
            // 5. Added visual breathing animation with expanding/shrinking text
            // 6. Added color coding for different activity types
            // 7. Provides session statistics when exiting
            
            ActivityLogger logger = new ActivityLogger();
            logger.LoadLog();
            
            bool running = true;
            
            while (running)
            {
                Console.Clear();
                DisplayMenu();
                
                string choice = Console.ReadLine();
                Console.Clear();
                
                Activity activity = null;
                
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new GratitudeActivity(); // EXCEEDING: New activity
                        break;
                    case "5":
                        running = false;
                        continue;
                    case "6":
                        logger.DisplayStatistics();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        continue;
                }
                
                if (activity != null)
                {
                    activity.Start();
                    logger.LogActivity(activity.GetType().Name, activity.Duration);
                    logger.SaveLog();
                }
            }
            
            logger.DisplayStatistics();
            Console.WriteLine("\nThank you for practicing mindfulness. Goodbye!");
            Console.ResetColor();
        }
        
        static void DisplayMenu()
        {
            Console.WriteLine("=== MINDFULNESS PROGRAM ===\n");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (NEW!)");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. View Session Statistics");
            Console.Write("\nYour choice: ");
        }
    }
}