﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EApp.Models;
using EApp.Service;
using Realms;

namespace EApp.Repository
{
    public class LessonRepository : ILessonRepository
    {
        public async Task<Lesson[]> GetAllLesson()
        {
            // Do something here later :))
            List<Lesson> list = new List<Lesson>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Lesson
                {
                    Title = "this is a title",
                    Author = "more jump",
                    Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
                    "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
                    "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
                    "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
                    "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
                    DownloadCount = 96,
                    ID = 123,
                    LinkThumbnail = "chiphu.jpg",
                    IsFavourite = true,
                });
            }

            return list.ToArray();
        }

        // a constructor here
        public LessonRepository( )
        {

        }
    }
}
