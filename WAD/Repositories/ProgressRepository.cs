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

        public void DeleteProgress(int progressId)
        {
            var progress = _dbContext.Progresses.Find(progressId);
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
            var progress = _dbContext.Progresses.Find(Id);
            return progress;
        }

        public void InsertProgress(Progress progress)
        {
            _dbContext.Add(progress);
            Save();
        }

        public void UpdateProgress(Progress progress)
        {
            _dbContext.Entry(progress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
