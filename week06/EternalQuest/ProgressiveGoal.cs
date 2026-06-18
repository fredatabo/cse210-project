 // CREATIVE: Progressive Goal - large goal with multiple levels
    namespace EternalQuest 
{
    public class ProgressiveGoal : Goal
    {
        private int _currentProgress;
        private int _targetProgress;
        private int _milestonePoints;
        
        public int CurrentProgress => _currentProgress;
        public int TargetProgress => _targetProgress;
        
        public ProgressiveGoal(string name, string description, int targetProgress, int milestonePoints) 
            : base(name, description, 0)
        {
            _targetProgress = targetProgress;
            _currentProgress = 0;
            _milestonePoints = milestonePoints;
            _isComplete = false;
        }
        
        public ProgressiveGoal() : base("", "", 0) { }
        
        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                Console.Write($"How much progress did you make on '{_name}'? ");
                if (int.TryParse(Console.ReadLine(), out int progress))
                {
                    int oldProgress = _currentProgress;
                    _currentProgress = Math.Min(_currentProgress + progress, _targetProgress);
                    int actualProgress = _currentProgress - oldProgress;
                    int earnedPoints = actualProgress * _milestonePoints;
                    
                    if (_currentProgress >= _targetProgress)
                    {
                        _isComplete = true;
                        Console.WriteLine($"🎯 GOAL COMPLETE! You reached {_currentProgress}/{_targetProgress}!");
                    }
                    
                    Console.WriteLine($"✓ Progress! You earned {earnedPoints} points! ({_currentProgress}/{_targetProgress})");
                    return earnedPoints;
                }
                Console.WriteLine("Invalid input. No points earned.");
                return 0;
            }
            Console.WriteLine("⚠ This goal is already complete!");
            return 0;
        }
        
        public override string GetStatus()
        {
            string checkmark = _isComplete ? "X" : " ";
            return $"[{checkmark}] {_name} - {_description} (Progress: {_currentProgress}/{_targetProgress}, {_milestonePoints} points per unit)";
        }
    }
}
    
