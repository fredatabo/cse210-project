using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalProgram
{
    class Journal
    {
        private List<Entry> _entries;
        private PromptGenerator _promptGenerator;

        public Journal()
        {
            _entries = new List<Entry>();
            _promptGenerator = new PromptGenerator();
        }

        public void AddEntry()
        {
            Console.WriteLine("\n--- New Journal Entry ---");
            
            // Option for quick entry
            Console.Write("Quick entry? (y/n): ");
            string quickChoice = Console.ReadLine()?.ToLower();
            
            string response;
            if (quickChoice == "y")
            {
                Console.Write("One sentence about your day: ");
                response = Console.ReadLine();
            }
            else
            {
                string prompt = _promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                response = Console.ReadLine();
            }

            Console.Write("Enter a title for this entry: ");
            string title = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(title))
            {
                title = $"Entry {_entries.Count + 1}";
            }

            Entry newEntry = new Entry(_promptGenerator.GetRandomPrompt(), response, title);
            _entries.Add(newEntry);
            
            Console.WriteLine($"\n✓ Entry added! ({newEntry.WordCount} words written)");
        }

        public void DisplayAllEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\n📭 No entries found. Start by writing your first entry!");
                return;
            }

            Console.WriteLine($"\n========== JOURNAL ({_entries.Count} entries) ==========");
            
            // Display statistics
            DisplayStatistics();
            
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        private void DisplayStatistics()
        {
            int totalWords = _entries.Sum(e => e.WordCount);
            double avgWords = _entries.Average(e => e.WordCount);
            
            Console.WriteLine($"\n📊 STATISTICS:");
            Console.WriteLine($"   Total entries: {_entries.Count}");
            Console.WriteLine($"   Total words written: {totalWords}");
            Console.WriteLine($"   Average entry length: {avgWords:F1} words");
            Console.WriteLine($"   Most productive day: {GetMostProductiveDay()}");
            Console.WriteLine(new string('=', 40));
        }

        private string GetMostProductiveDay()
        {
            if (_entries.Count == 0) return "N/A";
            
            var productiveDay = _entries.OrderByDescending(e => e.WordCount).First();
            return $"{productiveDay.Date.Split(' ')[0]} ({productiveDay.WordCount} words)";
        }

        public void SaveToFile()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\n⚠ No entries to save. Please write a new entry first.");
                return;
            }

            Console.Write("\nEnter filename for CSV (e.g., journal.csv): ");
            string csvFilename = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(csvFilename))
                csvFilename = "journal.csv";
            
            if (!csvFilename.EndsWith(".csv"))
                csvFilename += ".csv";

            try
            {
                // Save as CSV
                using (StreamWriter writer = new StreamWriter(csvFilename))
                {
                    writer.WriteLine("Date,Title,Prompt,Response,WordCount");
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine(entry.ToCsvString());
                    }
                }
                Console.WriteLine($"✓ Journal saved to {csvFilename} (CSV format - can open in Excel)");
                
                // Also save as readable text file
                string txtFilename = csvFilename.Replace(".csv", ".txt");
                using (StreamWriter writer = new StreamWriter(txtFilename))
                {
                    writer.WriteLine($"JOURNAL EXPORT - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine($"Total Entries: {_entries.Count}");
                    writer.WriteLine(new string('=', 60));
                    
                    foreach (Entry entry in _entries)
                    {
                        writer.Write(entry.ToTextString());
                    }
                }
                Console.WriteLine($"✓ Also saved as {txtFilename} (readable text format)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            Console.Write("\nEnter filename to load (e.g., journal.csv): ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("No filename provided.");
                return;
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine($"✗ File '{filename}' does not exist.");
                return;
            }

            try
            {
                List<Entry> loadedEntries = new List<Entry>();
                string[] lines = File.ReadAllLines(filename);
                
                // Skip header row
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    
                    // Parse CSV (handles quoted fields)
                    List<string> fields = ParseCsvLine(line);
                    
                    if (fields.Count >= 5)
                    {
                        string date = fields[0];
                        string title = fields[1];
                        string prompt = fields[2];
                        string response = fields[3];
                        int wordCount = int.Parse(fields[4]);
                        
                        Entry entry = new Entry(date, title, prompt, response, wordCount);
                        loadedEntries.Add(entry);
                    }
                }

                _entries = loadedEntries;
                Console.WriteLine($"✓ Successfully loaded {_entries.Count} entries from {filename}!");
                DisplayStatistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error loading file: {ex.Message}");
                Console.WriteLine("Make sure the file is in the correct format.");
            }
        }

        private List<string> ParseCsvLine(string line)
        {
            List<string> result = new List<string>();
            bool inQuotes = false;
            string currentField = "";
            
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        currentField += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += c;
                }
            }
            
            result.Add(currentField);
            return result;
        }
    }
}