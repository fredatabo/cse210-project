using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessProgram
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private List<string> _usedPrompts;
        private List<string> _usedQuestions;
        
        public ReflectionActivity() : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
        {
            InitializePromptList();
            InitializeQuestionList();
            _usedPrompts = new List<string>();
            _usedQuestions = new List<string>();
        }
        
        private void InitializePromptList()
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless.",
                "Think of a time when you overcame a significant challenge.",
                "Think of a time when you showed courage in a difficult situation."
            };
        }
        
        private void InitializeQuestionList()
        {
            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?",
                "Who else was affected by your actions?",
                "What strengths did you discover about yourself?"
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
        
        private string GetRandomQuestion()
        {
            // EXCEEDING: Ensure all questions are used before repeating
            if (_usedQuestions.Count == _questions.Count)
            {
                _usedQuestions.Clear();
            }
            
            var availableQuestions = _questions.Except(_usedQuestions).ToList();
            string question = availableQuestions[_random.Next(availableQuestions.Count)];
            _usedQuestions.Add(question);
            return question;
        }
        
        protected override void RunActivity()
        {
            string prompt = GetRandomPrompt();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n{prompt}");
            Console.ResetColor();
            Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("\nNow, ponder on the following questions as they relate to this experience.");
            Console.WriteLine("You may begin in a moment...");
            ShowCountdown(5);
            
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            int questionCount = 0;
            
            while (DateTime.Now < endTime && questionCount < _questions.Count)
            {
                string question = GetRandomQuestion();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n➜ {question}");
                Console.ResetColor();
                
                // Show spinner for 5 seconds or until time runs out
                int remainingSeconds = (int)(endTime - DateTime.Now).TotalSeconds;
                int spinnerSeconds = Math.Min(8, remainingSeconds);
                
                if (spinnerSeconds > 0)
                {
                    ShowSpinner(spinnerSeconds);
                }
                
                questionCount++;
            }
        }
    }
}