using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    /*
 * ENHANCED FEATURES REPORT:
 * 
 * This program goes beyond the basic requirements through the following improvements:
 * 
 * 1. **Dynamic Scripture Collection**:
 *    The application reads multiple scriptures from a file, giving users access
 *    to different verses instead of relying on a single scripture. A random
 *    scripture is chosen each time the program runs to create a varied experience.
 * 
 * 2. **Improved Word-Hiding Logic**:
 *    Rather than selecting words blindly, the program only hides words that are
 *    still visible. This ensures that new words disappear progressively, making
 *    memorization more effective and engaging.
 * 
 * 3. **Hint Support**:
 *    Users can enter the command "hint" to temporarily uncover a hidden word,
 *    providing assistance whenever they struggle to remember a verse.
 * 
 * 4. **Selectable Difficulty Modes**:
 *    The program includes Easy, Medium, and Hard difficulty settings that determine
 *    how many words are hidden per round (2, 4, or 6 words).
 * 
 * 5. **Learning Progress Display**:
 *    A progress indicator shows the percentage completed along with the number of
 *    rounds attempted, helping users monitor their memorization progress.
 * 
 * 6. **Reliable User Input Processing**:
 *    Different types of user input are handled smoothly, including uppercase or
 *    lowercase commands and empty responses, improving usability.
 * 
 * 7. **User-Added Scriptures**:
 *    Users are able to add new scriptures while the program is running. These
 *    entries are stored in the file so they remain available in future sessions.
 */
    
    class Program
    {
        private static List<Scripture> _scriptureLibrary = new List<Scripture>();
        private static Random _random = new Random();
        private static string _scriptureFile = "scriptures.txt";
        
        static void Main(string[] args)
        {
            Console.Title = "Scripture Memorizer";
            LoadScriptureLibrary();
            
            if (_scriptureLibrary.Count == 0)
            {
                Console.WriteLine("No scriptures found. Please add at least one scripture.");
                AddCustomScripture();
                LoadScriptureLibrary(); // Reload after adding
                
                if (_scriptureLibrary.Count == 0)
                {
                    Console.WriteLine("No scriptures available. Exiting program.");
                    return;
                }
            }
            
            bool playAgain = true;
            while (playAgain)
            {
                Scripture currentScripture = SelectRandomScripture();
                DifficultyLevel difficulty = SelectDifficulty();
                
                RunMemorizationSession(currentScripture, difficulty);
                
                Console.Write("\nWould you like to memorize another scripture? (yes/no): ");
                string response = Console.ReadLine()?.Trim().ToLower();
                playAgain = response == "yes" || response == "y";
                
                if (playAgain)
                {
                    Console.Clear();
                }
            }
            
            Console.WriteLine("\nThank you for using the Scripture Memorizer. Goodbye!");
        }
        
        static void LoadScriptureLibrary()
        {
            if (File.Exists(_scriptureFile))
            {
                string[] lines = File.ReadAllLines(_scriptureFile);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && line.Contains('|'))
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            Reference reference = Reference.Parse(parts[0]);
                            Scripture scripture = new Scripture(reference, parts[1]);
                            _scriptureLibrary.Add(scripture);
                        }
                    }
                }
            }
            
            // Add default scriptures if file doesn't exist or is empty
            if (_scriptureLibrary.Count == 0)
            {
                AddDefaultScriptures();
                SaveScriptureLibrary();
            }
        }
        
        static void AddDefaultScriptures()
{
    _scriptureLibrary.Add(new Scripture(
        new Reference("Isaiah", 41, 10),
        "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee."
    ));
    
    _scriptureLibrary.Add(new Scripture(
        new Reference("Romans", 8, 28),
        "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."
    ));
    
    _scriptureLibrary.Add(new Scripture(
        new Reference("Joshua", 1, 9),
        "Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."
    ));
    
    _scriptureLibrary.Add(new Scripture(
        new Reference("Matthew", 5, 14),
        "Ye are the light of the world. A city that is set on an hill cannot be hid."
    ));
}
        
        static void SaveScriptureLibrary()
        {
            List<string> lines = new List<string>();
            foreach (Scripture scripture in _scriptureLibrary)
            {
                lines.Add($"{scripture.GetReference()}|{scripture.GetOriginalText()}");
            }
            File.WriteAllLines(_scriptureFile, lines);
        }
        
        static void AddCustomScripture()
        {
            Console.Clear();
            Console.WriteLine("=== Add a New Scripture ===");
            
            Console.Write("Enter book name: ");
            string book = Console.ReadLine()?.Trim();
            
            Console.Write("Enter chapter number: ");
            if (!int.TryParse(Console.ReadLine(), out int chapter))
            {
                Console.WriteLine("Invalid chapter number.");
                return;
            }
            
            Console.Write("Enter starting verse (or single verse): ");
            if (!int.TryParse(Console.ReadLine(), out int startVerse))
            {
                Console.WriteLine("Invalid verse number.");
                return;
            }
            
            Console.Write("Enter ending verse (press Enter if single verse): ");
            string endVerseInput = Console.ReadLine()?.Trim();
            int? endVerse = string.IsNullOrEmpty(endVerseInput) ? null : (int?)int.Parse(endVerseInput);
            
            Console.Write("Enter the scripture text: ");
            string text = Console.ReadLine()?.Trim();
            
            Reference reference;
            if (endVerse.HasValue)
            {
                reference = new Reference(book, chapter, startVerse, endVerse.Value);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse);
            }
            
            Scripture scripture = new Scripture(reference, text);
            _scriptureLibrary.Add(scripture);
            SaveScriptureLibrary();
            
            Console.WriteLine("\nScripture added successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        static Scripture SelectRandomScripture()
        {
            int index = _random.Next(_scriptureLibrary.Count);
            Scripture selected = _scriptureLibrary[index];
            return new Scripture(selected.GetReferenceObject(), selected.GetOriginalText());
        }
        
        static DifficultyLevel SelectDifficulty()
        {
            Console.Clear();
            Console.WriteLine("=== Select Difficulty Level ===");
            Console.WriteLine("1. Easy (Hide 2 words at a time)");
            Console.WriteLine("2. Medium (Hide 4 words at a time)");
            Console.WriteLine("3. Hard (Hide 6 words at a time)");
            Console.Write("\nYour choice (1-3): ");
            
            string choice = Console.ReadLine()?.Trim();
            
            switch (choice)
            {
                case "1":
                    return DifficultyLevel.Easy;
                case "2":
                    return DifficultyLevel.Medium;
                case "3":
                    return DifficultyLevel.Hard;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Medium.");
                    System.Threading.Thread.Sleep(1000);
                    return DifficultyLevel.Medium;
            }
        }
        
        static void RunMemorizationSession(Scripture scripture, DifficultyLevel difficulty)
        {
            int wordsToHidePerRound = GetWordsToHide(difficulty);
            int roundCount = 0;
            
            while (true)
            {
                Console.Clear();
                DisplayScriptureWithProgress(scripture, roundCount);
                
                Console.WriteLine("\nCommands:");
                Console.WriteLine("  Press Enter - Hide more words");
                Console.WriteLine("  Type 'quit' - Exit the program");
                Console.WriteLine("  Type 'hint' - Show a hint (reveal a random hidden word)");
                Console.WriteLine("  Type 'new' - Choose a different scripture");
                Console.WriteLine("  Type 'add' - Add a new scripture to the library");
                
                Console.Write("\n> ");
                string input = Console.ReadLine()?.Trim().ToLower();
                
                if (input == "quit")
                {
                    Environment.Exit(0);
                }
                else if (input == "new")
                {
                    return; // Return to main menu to select new scripture
                }
                else if (input == "add")
                {
                    AddCustomScripture();
                    LoadScriptureLibrary(); // Reload the library
                    return; // Restart the selection process
                }
                else if (input == "hint")
                {
                    string hint = scripture.ShowHint();
                    if (hint != null)
                    {
                        Console.Clear();
                        DisplayScriptureWithProgress(scripture, roundCount);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n💡 Hint: {hint}");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        DisplayScriptureWithProgress(scripture, roundCount);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n💡 No words to reveal - all words are hidden!");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (input == "")
                {
                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        DisplayScriptureWithProgress(scripture, roundCount);
                        Console.WriteLine("\n🎉 Congratulations! You've memorized the entire scripture! 🎉");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    
                    bool hiddenAny = scripture.HideRandomWords(wordsToHidePerRound);
                    roundCount++;
                    
                    if (!hiddenAny)
                    {
                        Console.Clear();
                        DisplayScriptureWithProgress(scripture, roundCount);
                        Console.WriteLine("\n🎉 Amazing! You've memorized the entire scripture! 🎉");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
        
        static int GetWordsToHide(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy: return 2;
                case DifficultyLevel.Medium: return 4;
                case DifficultyLevel.Hard: return 6;
                default: return 4;
            }
        }
        
        static void DisplayScriptureWithProgress(Scripture scripture, int roundCount)
        {
            Console.WriteLine($"=== Scripture Memorizer - Round {roundCount + 1} ===\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\n📊 Progress: {scripture.GetProgressPercentage():F1}% memorized");
            Console.WriteLine($"📖 Words remaining: {scripture.GetVisibleWordCount()}");
        }
    }
    
    enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
}