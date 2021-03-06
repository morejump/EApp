﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EApp.Models;
using EApp.Service;
using Realms;
using EApp.Utils;
using System.Collections.ObjectModel;

namespace EApp.Repository
{
    public class LessonRepository : ILessonRepository
    {
        readonly Realm realm;

        public List<Sentence> ListSentence { get; set; }
        public async Task<Lesson[]> GetAllLesson()
        {

            List<Lesson> list = new List<Lesson>();
            for (int i = 0; i < 2; i++)
            {
                list.Add(new Lesson
                {
                    ListSentence= new List<Sentence>(this.ListSentence),
                    Title = "this is a title",
                    Author = "more jump ",
                    Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
                    "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
                    "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
                    "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
                    "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
                    DownloadCount = 96,
                    ID = 123,
                    LinkThumbnail = "chiphu.jpg",
                    IsFavourite = true,
                    Percent = 40,
                    Level = Level.normal
                });

                list.Add(new Lesson
                {
                    ListSentence = new List<Sentence>(this.ListSentence),
                    Title = "thao dep trai nhe",
                    Author = "more jump ",
                    Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
                    "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
                    "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
                    "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
                    "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
                    DownloadCount = 96,
                    ID = 123,
                    LinkThumbnail = "ChiPhu01.jpg",
                    IsFavourite = false,
                    Percent = 40,
                    Level = Level.normal
                });
            }

            return list.ToArray();
        }

        public IQueryable<Lesson> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Lesson item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Lesson item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        // a constructor here
        public LessonRepository(Realm realm)
        {
            this.realm = realm;

            ListSentence = new List<Sentence>();
            for (int i = 0; i < 5; i++)
            {
                ListSentence.Add(new Sentence
                {
                    Start = 40 * i,
                    End = 40 * (i + 1) - 1,
                    Text = "Dù khá giả, có điều kiện nhưng một số sao Việt vẫn tin tưởng các thương hiệu" +
                    " váy cưới trong nước, có giá thành phải chăng"
                });

            }
        }
    }
}
