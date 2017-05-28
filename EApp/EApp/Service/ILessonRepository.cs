using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EApp.Models;

namespace EApp.Service
{
    public interface ILessonRepository
    {
        Task<Lesson[]> GetAllLesson();
        IQueryable<Lesson> GetQueryable();

        Task<bool> Insert(Lesson lesson);
        Task<bool> Update(Lesson lesson);
        Task<bool> Delete(int id);
    }
}
