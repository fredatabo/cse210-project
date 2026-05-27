using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;
        
        // Constructor for single verse
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }
        
        // Constructor for verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }
        
        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }
        
        public static Reference Parse(string referenceText)
        {
            // Parse format like "John 3:16" or "Proverbs 3:5-6"
            string[] parts = referenceText.Split(' ');
            if (parts.Length != 2)
                throw new FormatException("Invalid reference format");
            
            string book = parts[0];
            string chapterVerse = parts[1];
            
            string[] chapterVerseParts = chapterVerse.Split(':');
            if (chapterVerseParts.Length != 2)
                throw new FormatException("Invalid reference format");
            
            int chapter = int.Parse(chapterVerseParts[0]);
            string versePart = chapterVerseParts[1];
            
            if (versePart.Contains('-'))
            {
                string[] verses = versePart.Split('-');
                int startVerse = int.Parse(verses[0]);
                int endVerse = int.Parse(verses[1]);
                return new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(versePart);
                return new Reference(book, chapter, verse);
            }
        }
        
        public override string ToString()
        {
            return GetDisplayText();
        }
    }
}