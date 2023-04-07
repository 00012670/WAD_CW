using System.Collections.Generic;
using WAD.Models;

namespace WAD.Repositories
{
    public interface IProgressRepository
    {
        void InsertProgress(Progress progress);
        void UpdateProgress(Progress progress);
        void DeleteProgress(int progressId);
        Progress GetProgressById(int Id);
        IEnumerable<Progress> GetProgresses();
    }
}
