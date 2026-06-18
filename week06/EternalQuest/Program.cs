using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

/* CREATIVE FEATURES EXCEEDING REQUIREMENTS:
   - Leveling System: Earn levels every 1000 points with +500 bonus rewards
   - Negative Goals: Track bad habits with point penalties
   - Progressive Goals: Track large goals with milestone progress
   - Enhanced UI: Colored output, emojis, and visual borders
   - Detailed Statistics: Completion rates, lifetime points, progress tracking
   - JSON Serialization: Modern, polymorphic save/load system
   - Intelligent Feedback: Goal-specific messages and celebrations
   - Extendable Architecture: Designed for easy addition of new features */

namespace EternalQuest 
{
    class Program
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        private int _level = 1;
        private int _totalPointsEarned = 0;
        
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║      🌟 ETERNAL QUEST PROGRAM 🌟       ║");
            Console.WriteLine("║    Gamified Goal Tracker for Growth    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            
            LoadData();
            
            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        DisplayScoreAndLevel();
                        break;
                    case "5":
                        SaveData();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════");
            
            // Calculate points needed for next level (1000 points per level)
            int pointsForNextLevel = _level * 1000;
            int pointsRemaining = pointsForNextLevel - _score;
            if (pointsRemaining < 0) pointsRemaining = 0;
            
            Console.WriteLine($"📊 Score: {_score}  |  🎮 Level: {_level}  |  📈 Points to next level: {pointsRemaining}");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List All Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Show Score and Level");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Select an option: ");
        }
        
        private void CreateGoal()
        {
            Console.WriteLine("\n📝 GOAL TYPES:");
            Console.WriteLine("1. Simple Goal (Complete once)");
            Console.WriteLine("2. Eternal Goal (Never ends, repeatable)");
            Console.WriteLine("3. Checklist Goal (Multiple times for bonus)");
            Console.WriteLine("4. Negative Goal (Penalty for bad habits) [CREATIVE]");
            Console.WriteLine("5. Progressive Goal (Large goal with milestones) [CREATIVE]");
            Console.Write("Choose goal type: ");
            
            string typeChoice = Console.ReadLine();
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            
            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter points for completion: ");
                    if (int.TryParse(Console.ReadLine(), out int points))
                    {
                        _goals.Add(new SimpleGoal(name, description, points));
                        Console.WriteLine($"✓ Simple goal '{name}' created!");
                    }
                    break;
                    
                case "2":
                    Console.Write("Enter points each time: ");
                    if (int.TryParse(Console.ReadLine(), out int eternalPoints))
                    {
                        _goals.Add(new EternalGoal(name, description, eternalPoints));
                        Console.WriteLine($"♾ Eternal goal '{name}' created!");
                    }
                    break;
                    
                case "3":
                    Console.Write("Enter points each time: ");
                    if (int.TryParse(Console.ReadLine(), out int checklistPoints))
                    {
                        Console.Write("Enter number of times needed: ");
                        if (int.TryParse(Console.ReadLine(), out int target))
                        {
                            Console.Write("Enter bonus points for completion: ");
                            if (int.TryParse(Console.ReadLine(), out int bonus))
                            {
                                _goals.Add(new ChecklistGoal(name, description, checklistPoints, target, bonus));
                                Console.WriteLine($"✓ Checklist goal '{name}' created!");
                            }
                        }
                    }
                    break;
                    
                case "4": // CREATIVE: Negative goal
                    Console.Write("Enter penalty points (positive number): ");
                    if (int.TryParse(Console.ReadLine(), out int penalty))
                    {
                        _goals.Add(new NegativeGoal(name, description, penalty));
                        Console.WriteLine($"⚠ Negative goal '{name}' created! Penalty: {penalty} points");
                    }
                    break;
                    
                case "5": // CREATIVE: Progressive goal
                    Console.Write("Enter target progress units: ");
                    if (int.TryParse(Console.ReadLine(), out int targetProgress))
                    {
                        Console.Write("Enter points per unit of progress: ");
                        if (int.TryParse(Console.ReadLine(), out int milestonePoints))
                        {
                            _goals.Add(new ProgressiveGoal(name, description, targetProgress, milestonePoints));
                            Console.WriteLine($"📈 Progressive goal '{name}' created!");
                        }
                    }
                    break;
                    
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }
        
        private void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\n📭 No goals created yet. Create some goals first!");
                return;
            }
            
            Console.WriteLine("\n🎯 YOUR GOALS:");
            Console.WriteLine("═══════════════════════════════════════");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }
            Console.WriteLine("═══════════════════════════════════════");
        }
        
        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\n📭 No goals to record. Create some goals first!");
                return;
            }
            
            ListGoals();
            Console.Write("\nSelect goal number to record: ");
            if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
            {
                int earnedPoints = _goals[goalIndex - 1].RecordEvent();
                if (earnedPoints != 0)
                {
                    AddPoints(earnedPoints);
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        
        private void AddPoints(int points)
        {
            _score += points;
            _totalPointsEarned += Math.Abs(points);
            
            // Level up system - each level requires 1000 points
            int pointsForNextLevel = _level * 1000;
            
            while (_score >= pointsForNextLevel)
            {
                _level++;
                Console.WriteLine($"🎉🎉🎉 LEVEL UP! You reached Level {_level}! 🎉🎉🎉");
                
                // Bonus for leveling up
                int levelBonus = 500;
                _score += levelBonus;
                Console.WriteLine($"✨ Level up bonus: +{levelBonus} points! ✨");
                
                // Recalculate for next level
                pointsForNextLevel = _level * 1000;
            }
        }
        
        private void DisplayScoreAndLevel()
        {
            Console.WriteLine("\n📊 PROGRESS REPORT:");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine($"🏆 Total Score: {_score}");
            Console.WriteLine($"🎮 Current Level: {_level}");
            
            int pointsForNextLevel = _level * 1000;
            int pointsRemaining = pointsForNextLevel - _score;
            if (pointsRemaining < 0) pointsRemaining = 0;
            Console.WriteLine($"✨ Points to next level: {pointsRemaining}");
            
            Console.WriteLine($"📈 Total points earned (lifetime): {_totalPointsEarned}");
            
            // Display completion statistics
            int completedGoals = _goals.Count(g => g.IsComplete);
            int totalGoals = _goals.Count;
            if (totalGoals > 0)
            {
                Console.WriteLine($"✅ Goal completion rate: {completedGoals}/{totalGoals} ({(completedGoals * 100 / totalGoals)}%)");
            }
            
            // Motivational message based on level
            Console.WriteLine("\n💪 " + GetMotivationalMessage());
            Console.WriteLine("═══════════════════════════════════════");
        }
        
        private string GetMotivationalMessage()
        {
            if (_level >= 20) return "You're a Legendary Hero! Keep inspiring others!";
            if (_level >= 15) return "Master level! You're an example to all!";
            if (_level >= 10) return "Amazing progress! You're becoming unstoppable!";
            if (_level >= 5) return "Great dedication! Every step counts toward eternal growth!";
            if (_level >= 2) return "Good start! Consistency is key to success!";
            return "Every small step brings you closer to your eternal goals!";
        }
        
        private void SaveData()
        {
            try
            {
                var saveData = new
                {
                    Score = _score,
                    Level = _level,
                    TotalPointsEarned = _totalPointsEarned,
                    Goals = _goals
                };
                
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    Converters = { new GoalConverter() }  // Add custom converter
                };
                
                string json = JsonSerializer.Serialize(saveData, options);
                File.WriteAllText("eternal_quest_save.json", json);
                Console.WriteLine("\n💾 Game saved successfully!");
                Console.WriteLine("May your eternal quest continue! 🌟");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }
        
        private void LoadData()
        {
            try
            {
                if (File.Exists("eternal_quest_save.json"))
                {
                    string json = File.ReadAllText("eternal_quest_save.json");
                    
                    var options = new JsonSerializerOptions 
                    { 
                        Converters = { new GoalConverter() }  // Add custom converter
                    };
                    
                    var saveData = JsonSerializer.Deserialize<SaveData>(json, options);
                    
                    if (saveData != null)
                    {
                        _score = saveData.Score;
                        _level = saveData.Level;
                        _totalPointsEarned = saveData.TotalPointsEarned;
                        _goals = saveData.Goals ?? new List<Goal>();
                        Console.WriteLine("📀 Previous save loaded successfully!");
                        Console.WriteLine($"Welcome back! You're at Level {_level} with {_score} points.");
                    }
                }
                else
                {
                    Console.WriteLine("🆕 No save file found. Starting a new quest!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                Console.WriteLine("Starting fresh...");
            }
        }
    }
    
    // ============================================================
    // CUSTOM JSON CONVERTER FOR POLYMORPHIC DESERIALIZATION
    // ============================================================
    public class GoalConverter : JsonConverter<Goal>
    {
        public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;
                
                // Try to get the type discriminator
                if (root.TryGetProperty("Type", out JsonElement typeElement))
                {
                    string typeName = typeElement.GetString();
                    
                    // Deserialize based on the type
                    switch (typeName)
                    {
                        case "SimpleGoal":
                            return JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options);
                        case "EternalGoal":
                            return JsonSerializer.Deserialize<EternalGoal>(root.GetRawText(), options);
                        case "ChecklistGoal":
                            return JsonSerializer.Deserialize<ChecklistGoal>(root.GetRawText(), options);
                        case "NegativeGoal":
                            return JsonSerializer.Deserialize<NegativeGoal>(root.GetRawText(), options);
                        case "ProgressiveGoal":
                            return JsonSerializer.Deserialize<ProgressiveGoal>(root.GetRawText(), options);
                        default:
                            throw new NotSupportedException($"Unknown goal type: {typeName}");
                    }
                }
                
                // Fallback: try to detect type by checking for specific properties
                if (root.TryGetProperty("TargetCount", out _))
                    return JsonSerializer.Deserialize<ChecklistGoal>(root.GetRawText(), options);
                if (root.TryGetProperty("Penalty", out _))
                    return JsonSerializer.Deserialize<NegativeGoal>(root.GetRawText(), options);
                if (root.TryGetProperty("TargetProgress", out _))
                    return JsonSerializer.Deserialize<ProgressiveGoal>(root.GetRawText(), options);
                if (root.TryGetProperty("IsComplete", out JsonElement isComplete) && isComplete.GetBoolean())
                    return JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options);
                
                // Default to SimpleGoal
                return JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options);
            }
        }
        
        public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
        {
            // Add a type discriminator when saving
            string typeName = value.GetType().Name;
            
            // Serialize the goal and add the Type property
            string json = JsonSerializer.Serialize((object)value, value.GetType(), options);
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                JsonElement root = doc.RootElement;
                
                writer.WriteStartObject();
                
                // Write all existing properties
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    property.WriteTo(writer);
                }
                
                // Add the Type discriminator
                writer.WriteString("Type", typeName);
                
                writer.WriteEndObject();
            }
        }
    }
    
    // Helper class for JSON serialization
    
   
}