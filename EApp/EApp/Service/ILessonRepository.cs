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
        IQueryable<Lesson> GetQueryable();
        Task<bool> Insert(Lesson item);
        Task<bool> Update(Lesson item);
        Task<bool> Delete(int id);
    }
}
