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

        void Insert(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(long ID);
    }
}
