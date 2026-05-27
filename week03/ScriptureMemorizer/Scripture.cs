using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;
        private string _originalText;
        
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _originalText = text;
            _random = new Random();
            _words = new List<Word>();
            
            // Split the text into words (preserve punctuation)
            string[] wordArray = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }
        
        public string GetDisplayText()
        {
            StringBuilder display = new StringBuilder();
            display.AppendLine(_reference.GetDisplayText());
            display.AppendLine();
            
            foreach (Word word in _words)
            {
                display.Append(word.GetDisplayText());
                display.Append(' ');
            }
            
            return display.ToString().Trim();
        }
        
        public string GetOriginalText()
        {
            return _originalText;
        }
        
        public Reference GetReferenceObject()
        {
            return _reference;
        }
        
        public string GetReference()
        {
            return _reference.GetDisplayText();
        }
        
        public bool HideRandomWords(int count)
        {
            // Get all visible words
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    visibleIndices.Add(i);
                }
            }
            
            // If no visible words left, return false
            if (visibleIndices.Count == 0)
            {
                return false;
            }
            
            // Hide up to 'count' random visible words
            int wordsToHide = Math.Min(count, visibleIndices.Count);
            for (int i = 0; i < wordsToHide; i++)
            {
                int randomIndex = _random.Next(visibleIndices.Count);
                int wordIndex = visibleIndices[randomIndex];
                _words[wordIndex].Hide();
                visibleIndices.RemoveAt(randomIndex);
            }
            
            return true;
        }
        
        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
        
        public string ShowHint()
        {
            // Find the first hidden word and reveal it as a hint
            foreach (Word word in _words)
            {
                if (word.IsHidden())
                {
                    return word.GetHint();
                }
            }
            return null;
        }
        
        public double GetProgressPercentage()
        {
            int hiddenCount = _words.Count(w => w.IsHidden());
            return (double)hiddenCount / _words.Count * 100;
        }
        
        public int GetVisibleWordCount()
        {
            return _words.Count(w => !w.IsHidden());
        }
    }
}