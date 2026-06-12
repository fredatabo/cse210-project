using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    // EXCEEDING: Added a 4th activity - Gratitude Activity
    public class GratitudeActivity : Activity
    {
        private List<string> _gratitudePrompts;
        
        public GratitudeActivity() : base(
            "Gratitude",
            "This activity will help you cultivate gratitude by focusing on the positive aspects of your life. Research shows that practicing gratitude increases happiness and wellbeing."
        )
        {
            InitializePrompts();
        }
        
        private void InitializePrompts()
        {
            _gratitudePrompts = new List<string>
            {
                "What is something beautiful you saw today?",
                "Who is someone that made you smile recently?",
                "What is a comfort you often take for granted?",
                "What ability or skill are you grateful for?",
                "What challenge made you stronger?",
                "What memory brings you joy?",
                "What opportunity are you thankful for?",
                "What simple pleasure did you enjoy today?",
                "Who is a teacher or mentor you appreciate?",
                "What about your health are you grateful for?"
            };
        }
        
        protected override void RunActivity()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nLet's practice gratitude together.\n");
            Console.ResetColor();
            
            List<string> gratitudes = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            
            Console.WriteLine("For each prompt, take a moment to think, then write your answer:\n");
            
            int promptIndex = 0;
            while (DateTime.Now < endTime && promptIndex < _gratitudePrompts.Count)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Prompt {promptIndex + 1}: {_gratitudePrompts[promptIndex]}");
                Console.ResetColor();
                
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(response))
                {
                    gratitudes.Add(response);
                }
                
                if (DateTime.Now < endTime && promptIndex < _gratitudePrompts.Count - 1)
                {
                    Console.WriteLine("\nTake a deep breath before the next prompt...");
                    ShowSpinner(3);
                    Console.Clear();
                }
                
                promptIndex++;
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✨ You expressed {gratitudes.Count} things you're grateful for! ✨");
            Console.ResetColor();
            
            if (gratitudes.Count > 0)
            {
                Console.WriteLine("\nYour gratitude reflections:");
                foreach (string gratitude in gratitudes)
                {
                    Console.WriteLine($"  ❤ {gratitude}");
                }
            }
            
            ShowSpinner(3);
        }
    }
}