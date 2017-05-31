using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EApp.Models;
using EApp.Service;
using EApp.Utils;
using System.Collections.ObjectModel;
using Realms;

namespace EApp.Repository
{
    public class LessonRepository : ILessonRepository
    {
        readonly Realm realm;
        public LessonRepository(Realm realm)
        {
            this.realm = realm;
            realm.Write(() =>
            {
                var less = new LessonItem
                {
                    Title = "this is a title",
                    Author = "more jump",
                    Description = "this is a description"
                };

                realm.Add(less);
            });

        }

        //public async Task<LessonItem[]> GetAllLesson()
        //{
        //    List<LessonItem> list = new List<LessonItem>();
        //    //for (int i = 0; i < 2; i++)
        //    //{
        //    //    list.Add(new LessonItem
        //    //    {
        //    //        //ListSentence = new ObservableCollection<Sentence>
        //    //        //{
        //    //        //    new Sentence
        //    //        //    {
        //    //        //Start = 40 * i,
        //    //        //End = 40 * (i + 1) - 1,
        //    //        //Text = "Dù khá giả, có điều kiện nhưng một số sao Việt vẫn tin tưởng các thương hiệu" +
        //    //        //" váy cưới trong nước, có giá thành phải chăng"
        //    //        //        }
        //    //        //},
        //    //        Title = "this is a title",
        //    //        Author = "more jump ",
        //    //        Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
        //    //        "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
        //    //        "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
        //    //        "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
        //    //        "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
        //    //        DownloadCount = 96,
        //    //        ID = 456,
        //    //        LinkThumbnail = "chiphu.jpg",
        //    //        IsFavourite = true,
        //    //        Percent = 0,
        //    //        //Level = Level.normal,
        //    //        PathAudio = "/data/data/EApp.Droid/files/.config/music"
        //    //    });

        //    //    list.Add(new LessonItem
        //    //    {
        //    //        //ListSentence = new ObservableCollection<Sentence>
        //    //        //{
        //    //        //    new Sentence
        //    //        //    {
        //    //        //Start = 40 * i,
        //    //        //End = 40 * (i + 1) - 1,
        //    //        //Text = "Dù khá giả, có điều kiện nhưng một số sao Việt vẫn tin tưởng các thương hiệu" +
        //    //        //" váy cưới trong nước, có giá thành phải chăng"
        //    //        //        }
        //    //        //},
        //    //        Title = "thao dep trai nhe",
        //    //        Author = "more jump ",
        //    //        Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
        //    //        "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
        //    //        "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
        //    //        "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
        //    //        "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
        //    //        DownloadCount = 96,
        //    //        ID = 123,
        //    //        LinkThumbnail = "ChiPhu01.jpg",
        //    //        IsFavourite = false,
        //    //        Percent = 40,
        //    //        //Level = Level.normal,
        //    //        PathAudio = "/data/data/EApp.Droid/files/.config/music"
        //    //    });
        //    //}

        //    return list.ToArray();
        //}

        public IQueryable<LessonItem> GetQueryable()
        {
            return realm.All<LessonItem>();

        }

        public Task<bool> Insert(LessonItem item)
        {
            return null;
        }

        public Task<bool> Update(LessonItem item)
        {
            return null;
        }

        public Task<bool> Delete(long id)
        {
            return null;
        }

       
    }
}
