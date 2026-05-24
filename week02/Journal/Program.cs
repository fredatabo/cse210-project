using System;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===================================");
                Console.WriteLine("        JOURNAL PROGRAM");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");
                Console.WriteLine("===================================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.AddEntry();
                        break;
                    case "2":
                        journal.DisplayAllEntries();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }
    }
}

/*
 * CREATIVITY ENHANCEMENT SUMMARY:
 * ===============================
 *
 * This application goes beyond the basic requirements by introducing
 * several features that improve the journaling experience and make it
 * more practical, engaging, and user-friendly.
 *
 * 1. WORD COUNT FEATURE:
 *    - Counts the number of words in each journal entry
 *    - Displays word counts when entries are viewed
 *    - Tracks the total number of words written overall
 *    - Helps users understand that every amount of writing is meaningful
 *
 * 2. CUSTOM ENTRY TITLES:
 *    - Allows each journal entry to have a title
 *    - Improves organization and readability
 *    - Makes it easier to identify and revisit past entries
 *
 * 3. QUICK JOURNAL OPTION:
 *    - Supports short, one-sentence journal entries
 *    - Makes journaling easier on busy days
 *    - Encourages consistency even with limited time
 *
 * 4. JOURNAL STATISTICS:
 *    - Displays the total number of entries created
 *    - Tracks the cumulative word count
 *    - Calculates the average length of entries
 *    - Motivates users by showing long-term progress
 *
 * 5. IMPROVED CSV SUPPORT:
 *    - Saves journal data in proper CSV format
 *    - Escapes quotation marks correctly
 *    - Ensures compatibility with Excel and Google Sheets
 *    - Properly handles commas and special characters in text
 *
 * 6. MULTIPLE EXPORT OPTIONS:
 *    - Allows exporting entries as CSV files
 *    - Also supports plain text file exports
 *    - Gives users flexibility in accessing and storing their journal data
 *
 * 7. EXPANDED PROMPT COLLECTION:
 *    - Includes more than the required number of prompts
 *    - Prompts encourage gratitude, reflection, and self-awareness
 *    - Helps users avoid writer’s block
 *
 * These features were designed to solve common journaling challenges such as:
 * - Limited time for writing
 * - Difficulty staying motivated
 * - Lack of organization
 * - Uncertainty about writing enough content
 */