using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _usedPrompts;
        
        public ListingActivity() : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
        {
            InitializePromptList();
            _usedPrompts = new List<string>();
        }
        
        private void InitializePromptList()
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?",
                "What are things that made you smile today?",
                "What are accomplishments you're proud of?",
                "What are things you're grateful for?"
            };
        }
        
        private string GetRandomPrompt()
        {
            // EXCEEDING: Ensure all prompts are used before repeating
            if (_usedPrompts.Count == _prompts.Count)
            {
                _usedPrompts.Clear();
            }
            
            var availablePrompts = _prompts.Except(_usedPrompts).ToList();
            string prompt = availablePrompts[_random.Next(availablePrompts.Count)];
            _usedPrompts.Add(prompt);
            return prompt;
        }
        
        protected override void RunActivity()
        {
            string prompt = GetRandomPrompt();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{prompt}");
            Console.ResetColor();
            Console.WriteLine("\nYou will have a few seconds to prepare, then list as many items as you can.");
            
            ShowCountdown(5);
            
            Console.WriteLine("\nStart listing items now (press Enter after each item, or just press Enter to finish early):\n");
            
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            
            while (DateTime.Now < endTime)
            {
                Console.Write("• ");
                string item = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(item))
                {
                    break;
                }
                
                items.Add(item);
                
                // Show remaining time occasionally
                if (items.Count % 3 == 0)
                {
                    int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                    if (remaining > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"  ({remaining} seconds remaining)");
                        Console.ResetColor();
                    }
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n📝 You listed {items.Count} items!");
            
            if (items.Count > 0)
            {
                Console.WriteLine("\nYour items:");
                foreach (string item in items)
                {
                    Console.WriteLine($"  • {item}");
                }
            }
            Console.ResetColor();
            
            ShowSpinner(3);
        }
    }
}