// Checklist Goal - must be completed multiple times for bonus
    namespace EternalQuest 
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;
        
        public int TargetCount => _targetCount;
        public int CurrentCount => _currentCount;
        public int BonusPoints => _bonusPoints;
        
        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
            _isComplete = false;
        }
        
        public ChecklistGoal() : base("", "", 0) { }
        
        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _currentCount++;
                int earnedPoints = _points;
                
                if (_currentCount == _targetCount)
                {
                    _isComplete = true;
                    earnedPoints += _bonusPoints;
                    Console.WriteLine($"🎉 Amazing! You completed this goal {_currentCount}/{_targetCount} times!");
                    Console.WriteLine($"✨ You earned {_points} + {_bonusPoints} bonus = {earnedPoints} points!");
                }
                else
                {
                    Console.WriteLine($"✓ Progress! You earned {_points} points! ({_currentCount}/{_targetCount})");
                }
                return earnedPoints;
            }
            Console.WriteLine("⚠ This goal is already complete!");
            return 0;
        }
        
        public override string GetStatus()
        {
            string checkmark = _isComplete ? "X" : " ";
            return $"[{checkmark}] {_name} - {_description} (Completed {_currentCount}/{_targetCount} times, {_points} points each, bonus: {_bonusPoints})";
        }
        
        public override string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_name},{_description},{_points},{_isComplete},{_targetCount},{_currentCount},{_bonusPoints}";
        }
    }
}
    
