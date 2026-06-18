// Simple Goal - complete once for points
    namespace EternalQuest 
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) { }
        
        public SimpleGoal() : base("", "", 0) { }
        
        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                Console.WriteLine($"✓ Congratulations! You earned {_points} points!");
                return _points;
            }
            Console.WriteLine("⚠ This goal is already completed!");
            return 0;
        }
        
        public override string GetStatus()
        {
            return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description} ({_points} points)";
        }
    }
}