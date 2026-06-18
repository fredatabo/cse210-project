 // CREATIVE: Negative Goal - lose points for bad habits
   namespace EternalQuest 
{
    public class NegativeGoal : Goal
    {
        private int _penalty;
        
        public NegativeGoal(string name, string description, int penalty) 
            : base(name, description, -Math.Abs(penalty))
        {
            _penalty = -Math.Abs(penalty);
            _isComplete = false; // Negative goals are ongoing
        }
        
        public NegativeGoal() : base("", "", 0) { }
        
        public override int RecordEvent()
        {
            Console.WriteLine($"⚠ Oops! You lost {Math.Abs(_penalty)} points for: {_name}");
            return _penalty;
        }
        
        public override string GetStatus()
        {
            return $"[-] {_name} - {_description} (Penalty: {Math.Abs(_points)} points)";
        }
    }
}
