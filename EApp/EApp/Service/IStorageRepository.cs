using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Service
{
    public interface IStorageRepository
    {
        Task<List<LessonModel>> SearchLesson(string keyword);
    }
}
