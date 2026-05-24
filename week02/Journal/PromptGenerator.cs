using System;
using System.Collections.Generic;

namespace JournalProgram
{
    class PromptGenerator
    {
        private List<string> _prompts;

        public PromptGenerator()
        {
            _prompts = new List<string>
            {
               "What moment today made me feel the happiest?",
        "What challenge did I overcome today?",
        "What is one thing I learned about myself today?",
        "How did I make someone’s day better today?",
        "What am I most grateful for right now?",
        "What is one thing I want to improve tomorrow?"
            };
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}