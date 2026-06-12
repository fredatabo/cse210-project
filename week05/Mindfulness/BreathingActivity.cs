using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) { }
        
        protected override void RunActivity()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            bool breatheIn = true;
            
            while (DateTime.Now < endTime)
            {
                Console.Clear();
                Console.ForegroundColor = breatheIn ? ConsoleColor.Blue : ConsoleColor.Cyan;
                
                if (breatheIn)
                {
                    Console.WriteLine("\n🌬️  Breathe in...");
                    AnimateBreathing("Breathe in...", 4, true);
                }
                else
                {
                    Console.WriteLine("\n🌊 Breathe out...");
                    AnimateBreathing("Breathe out...", 4, false);
                }
                
                Console.ResetColor();
                breatheIn = !breatheIn;
            }
        }
        
        // EXCEEDING: Visual breathing animation with expanding/shrinking text
        private void AnimateBreathing(string message, int seconds, bool isInhale)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            
            while (DateTime.Now < endTime)
            {
                for (int size = 1; size <= 5 && DateTime.Now < endTime; size++)
                {
                    Console.Clear();
                    Console.ForegroundColor = isInhale ? ConsoleColor.Blue : ConsoleColor.Cyan;
                    Console.WriteLine($"\n{message}");
                    
                    string breathText = isInhale ? "◀◀◀" : "▶▶▶";
                    string displayText = isInhale 
                        ? new string(' ', 10 - size) + breathText.Substring(0, Math.Min(size, 3))
                        : new string(' ', size - 1) + breathText;
                    
                    Console.WriteLine($"\n{displayText}");
                    Console.ResetColor();
                    Thread.Sleep(200);
                }
                
                for (int size = 5; size >= 1 && DateTime.Now < endTime; size--)
                {
                    Console.Clear();
                    Console.ForegroundColor = isInhale ? ConsoleColor.Blue : ConsoleColor.Cyan;
                    Console.WriteLine($"\n{message}");
                    
                    string breathText = isInhale ? "◀◀◀" : "▶▶▶";
                    string displayText = isInhale 
                        ? new string(' ', 10 - size) + breathText.Substring(0, Math.Min(size, 3))
                        : new string(' ', size - 1) + breathText;
                    
                    Console.WriteLine($"\n{displayText}");
                    Console.ResetColor();
                    Thread.Sleep(200);
                }
            }
        }
    }
}