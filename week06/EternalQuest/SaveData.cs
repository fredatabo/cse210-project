  // Helper class for JSON deserialization
  namespace EternalQuest 
{
        public class SaveData
        {
            public int Score { get; set; }
            public int Level { get; set; }
            public int TotalPointsEarned { get; set; }
            public List<Goal> Goals { get; set; }
        }
} 