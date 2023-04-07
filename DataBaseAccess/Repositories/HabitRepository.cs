using System.Collections.Generic;
using System.Linq;
using WAD.Models;
using WAD.DAL;

namespace WAD.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly HabitContext _dbContext;
        public HabitRepository(HabitContext dbContext)
        {
            _dbContext = dbContext;
        }

        private Habit FindHabitById(int habitId)
        {
            return _dbContext.Habits.Find(habitId);
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public void DeleteHabit(int habitId)
        {
            var habit = FindHabitById(habitId);
            _dbContext.Habits.Remove(habit);
            Save();
        }

        public Habit GetHabitById(int  Id)
        {
            var habit = FindHabitById(Id);
            return habit;
        }

        public IEnumerable<Habit> GetHabits()
        {
            return _dbContext.Habits.ToList();
        }

        public void InsertHabit(Habit habit)
        {
            _dbContext.Add(habit);
            Save();
        }

        public void UpdateHabit(Habit habit)
        {
            var existingHabit = _dbContext.Habits.Find(habit.ID);
            existingHabit.Name = habit.Name;
            existingHabit.Frequency = habit.Frequency;
            existingHabit.Repeat = habit.Repeat;
            existingHabit.StartDate = habit.StartDate;
            Save();
        }
    }
}
