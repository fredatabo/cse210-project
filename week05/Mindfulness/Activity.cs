using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected static Random _random = new Random();
        
        public int Duration => _duration;
        
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        public void Start()
        {
            DisplayStartingMessage();
            SetDuration();
            PrepareToBegin();
            RunActivity();
            DisplayEndingMessage();
        }
        
        protected virtual void DisplayStartingMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Starting {_name} Activity");
            Console.ResetColor();
            Console.WriteLine($"\n{_description}\n");
        }
        
        protected void SetDuration()
        {
            Console.Write("How many seconds would you like this activity to last? ");
            _duration = int.Parse(Console.ReadLine());
        }
        
        protected void PrepareToBegin()
        {
            Console.WriteLine("\nPrepare to begin...");
            ShowCountdown(5);
        }
        
        protected virtual void RunActivity()
        {
            // To be implemented by derived classes
        }
        
        protected virtual void DisplayEndingMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✨ Good job! ✨");
            ShowSpinner(2);
            Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity.");
            Console.ResetColor();
            ShowSpinner(3);
        }
        
        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(100);
                Console.Write("\b \b");
                i++;
            }
        }
        
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"Starting in: {i}");
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', Console.CursorLeft) + "\r");
            }
        }
        
        protected void ShowCountdownWithMessage(string message, int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{message} {i}");
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', Console.CursorLeft) + "\r");
            }
        }
        
        protected void PauseWithAnimation(int seconds, string animationType = "spinner")
        {
            if (animationType == "spinner")
            {
                ShowSpinner(seconds);
            }
            else if (animationType == "dots")
            {
                for (int i = 0; i < seconds * 2; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
            }
        }
    }
}