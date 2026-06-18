 // Eternal Goal - never complete, earn points each time
    namespace EternalQuest 
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) 
        {
            _isComplete = false; // Eternal goals are never complete
        }
        
        public EternalGoal() : base("", "", 0) { }
        
        public override int RecordEvent()
        {
            Console.WriteLine($"✓ Great job! You earned {_points} points!");
            return _points; // Always return points, never mark complete
        }
        
        public override string GetStatus()
        {
            return $"[∞] {_name} - {_description} ({_points} points each time)";
        }
    }
}