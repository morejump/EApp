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
        //Task<LessonItem[]> GetAllLesson();
        IQueryable<LessonItem> GetQueryable();

        Task<bool> Insert(LessonItem item);
        Task<bool> Update(LessonItem item);
        Task<bool> Delete(long id);

    }
}
