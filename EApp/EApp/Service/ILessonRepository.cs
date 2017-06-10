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
        IQueryable<LessonItem> GetQueryable();
        void Insert(LessonItem item);
        void Update(LessonItem item);
        void UpdateTime(long id, DateTimeOffset Date);
        void Delete(long id);

    }
}
