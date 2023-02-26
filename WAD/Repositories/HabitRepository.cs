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

  
        public void DeleteHabit(int habitId)
        {
            var habit = _dbContext.Habits.Find(habitId);
            _dbContext.Habits.Remove(habit);
            Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public Habit GetHabitById(int habitId)
        {
            var habit = FindHabitById(habitId);
            return habit;
        }

        public IEnumerable<Habit> GetHabits()
        {
            return _dbContext.Habits.ToList();
        }

        public void InsertHabit(Habit habit)
        {
            habit.HabitProgress = _dbContext.Progresses.Find(habit.HabitProgress.ID);
            _dbContext.Add(habit);
            Save();
        }

        public void UpdateHabit(Habit habit)
        {
            _dbContext.Entry(habit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
