using System.Collections.Generic;
using System;

namespace WAD.Models
{
    public class Habit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Frequency { get; set; }
        public string Repeat { get; set; }
        public DateTime StartDate { get; set; }
        public string Category { get; set; }

        public Progress HabitProgress { get; set; }
    }
}
