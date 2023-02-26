using System;

namespace WAD.Models
{
    public class Progress
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int HabitProgress { get; set; }
        public bool IsCompleted { get; set; }
        public string Notes { get; set; }
    }
}
