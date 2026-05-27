using System.Text;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _isHidden;
        
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }
        
        public void Hide()
        {
            _isHidden = true;
        }
        
        public void Show()
        {
            _isHidden = false;
        }
        
        public bool IsHidden()
        {
            return _isHidden;
        }
        
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            else
            {
                return _text;
            }
        }
        
        public string GetOriginalText()
        {
            return _text;
        }
        
        public string GetHint()
        {
            if (_isHidden)
            {
                // Reveal the first letter as a hint
                return $"{_text[0]}{new string('_', _text.Length - 1)}";
            }
            return _text;
        }
    }
}