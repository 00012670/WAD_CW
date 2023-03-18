using System.Collections.Generic;
using WAD.DAL;
using WAD.Models;
using System.Linq;
using System;

namespace WAD.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly HabitContext _dbContext;
        public ProgressRepository(HabitContext dbContext)
        {
            _dbContext = dbContext;
        }

        private Progress FindHabitById(int progressId)
        {
            return _dbContext.Progresses.Find(progressId);
        }

        public void DeleteProgress(int progressId)
        {
            var progress = FindHabitById(progressId);
            _dbContext.Progresses.Remove(progress);
            Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Progress> GetProgress()
        {
            return _dbContext.Progresses.ToList();
        }

        public Progress GetProgressById(int Id)
        {
            var progress = FindHabitById(Id);
            return progress;
        }

        public void InsertProgress(Progress progress)
        {
            progress.Habit = _dbContext.Habits.Find(progress.Habit.ID);
            _dbContext.Add(progress);
            Save();
        }

        public void UpdateProgress(Progress progress)
        {
            var existingProgress = _dbContext.Progresses.Find(progress.ID);
            existingProgress.Name = progress.Name;
            existingProgress.Date = progress.Date;
            existingProgress.HabitProgress = progress.HabitProgress;
            existingProgress.IsCompleted = progress.IsCompleted;
            existingProgress.Notes = progress.Notes;
            Save();
        }
    }
}
