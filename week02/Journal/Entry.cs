using System;

namespace JournalProgram
{
    class Entry
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public int WordCount { get; set; }

        public Entry(string prompt, string response, string title)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Prompt = prompt;
            Response = response;
            Title = title;
            WordCount = CountWords(response);
        }

        // Constructor for loading from file
        public Entry(string date, string title, string prompt, string response, int wordCount)
        {
            Date = date;
            Title = title;
            Prompt = prompt;
            Response = response;
            WordCount = wordCount;
        }

        private int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, 
                                       StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public void Display()
        {
            Console.WriteLine($"\n┌─────────────────────────────────────────┐");
            Console.WriteLine($"│ Date: {Date}");
            Console.WriteLine($"│ Title: {Title}");
            Console.WriteLine($"│ Word Count: {WordCount} words");
            Console.WriteLine($"│ Prompt: {Prompt}");
            Console.WriteLine($"│ Response: {Response}");
            Console.WriteLine($"└─────────────────────────────────────────┘");
        }

        public string ToCsvString()
        {
            // Escape quotes by doubling them and wrap in quotes for CSV
            string escapedTitle = "\"" + Title.Replace("\"", "\"\"") + "\"";
            string escapedPrompt = "\"" + Prompt.Replace("\"", "\"\"") + "\"";
            string escapedResponse = "\"" + Response.Replace("\"", "\"\"") + "\"";
            
            return $"{Date},{escapedTitle},{escapedPrompt},{escapedResponse},{WordCount}";
        }

        public string ToTextString()
        {
            return $"=== {Date} ===\nTitle: {Title}\nPrompt: {Prompt}\n[{WordCount} words]\n{Response}\n{new string('-', 50)}\n";
        }
    }
}