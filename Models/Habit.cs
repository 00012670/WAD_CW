using System;

namespace HabitTracker.Models
{
    public class Habit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public string Repeat { get; set; }
        public DateTime StartDate { get; set; }
        public Progress HabitProgress { get; set; }
        public int HabitId { get; set; }

    }
}
