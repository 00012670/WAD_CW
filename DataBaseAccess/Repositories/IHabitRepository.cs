using System.Collections.Generic;
using WAD.Models;

namespace WAD.Repositories
{
    public interface IHabitRepository
    {
        void InsertHabit (Habit habit); 
        void UpdateHabit (Habit habit);
        void DeleteHabit (int habitId);
        Habit GetHabitById(int Id);
        IEnumerable<Habit> GetHabits();
    }
}
