using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EternalQuest 
{
    // Base Goal class - abstract to enforce polymorphism
    [JsonDerivedType(typeof(SimpleGoal))]
    [JsonDerivedType(typeof(EternalGoal))]
    [JsonDerivedType(typeof(ChecklistGoal))]
    [JsonDerivedType(typeof(NegativeGoal))]
    [JsonDerivedType(typeof(ProgressiveGoal))]
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;
        
        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsComplete => _isComplete;
        
        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }
        
        // Virtual method - can be overridden by derived classes
        public virtual int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }
        
        // Abstract method - must be implemented by derived classes
        public abstract string GetStatus();
        
        public virtual string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_name},{_description},{_points},{_isComplete}";
        }
        
        // For JSON serialization
        public Goal() { }
    }
}
