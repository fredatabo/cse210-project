using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MindfulnessProgram
{
    // EXCEEDING: Logging system to track activity usage
    public class ActivityLogger
    {
        private List<ActivityLogEntry> _logs;
        private string _logFilePath;
        
        public ActivityLogger()
        {
            _logs = new List<ActivityLogEntry>();
            _logFilePath = "mindfulness_log.txt";
        }
        
        public void LogActivity(string activityName, int duration)
        {
            var entry = new ActivityLogEntry
            {
                ActivityName = activityName,
                Duration = duration,
                Timestamp = DateTime.Now
            };
            _logs.Add(entry);
        }
        
        public void SaveLog()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath))
                {
                    foreach (var log in _logs)
                    {
                        writer.WriteLine($"{log.Timestamp:yyyy-MM-dd HH:mm:ss}|{log.ActivityName}|{log.Duration}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log: {ex.Message}");
            }
        }
        
        public void LoadLog()
        {
            if (File.Exists(_logFilePath))
            {
                try
                {
                    _logs.Clear();
                    string[] lines = File.ReadAllLines(_logFilePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            var entry = new ActivityLogEntry
                            {
                                Timestamp = DateTime.Parse(parts[0]),
                                ActivityName = parts[1],
                                Duration = int.Parse(parts[2])
                            };
                            _logs.Add(entry);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading log: {ex.Message}");
                }
            }
        }
        
        public void DisplayStatistics()
        {
            if (_logs.Count == 0)
            {
                Console.WriteLine("No activity logs found yet. Complete some activities to see statistics!");
                return;
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 SESSION STATISTICS");
            Console.WriteLine("=" .PadRight(40, '='));
            Console.ResetColor();
            
            Console.WriteLine($"Total activities completed: {_logs.Count}");
            Console.WriteLine($"Total mindful minutes: {_logs.Sum(l => l.Duration) / 60.0:F1}");
            Console.WriteLine($"Total mindful seconds: {_logs.Sum(l => l.Duration)}");
            
            Console.WriteLine("\nActivity breakdown:");
            var grouped = _logs.GroupBy(l => l.ActivityName);
            foreach (var group in grouped)
            {
                Console.WriteLine($"  • {group.Key}: {group.Count()} sessions ({group.Sum(g => g.Duration)} seconds)");
            }
            
            if (_logs.Any())
            {
                Console.WriteLine($"\nLast activity: {_logs.Last().ActivityName} at {_logs.Last().Timestamp:hh:mm tt}");
            }
        }
        
        private class ActivityLogEntry
        {
            public string ActivityName { get; set; }
            public int Duration { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}