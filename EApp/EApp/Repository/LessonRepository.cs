using System;
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

        // instead of this method later
        public async Task<Lesson[]> GetAllLesson()
        {
            List<Lesson> list = new List<Lesson>();
            for (int i = 0; i < 2; i++)
            {
                list.Add(new Lesson
                {
                    //ListSentence = new ObservableCollection<Sentence>
                    //{
                    //    new Sentence
                    //    {
                    //Start = 40 * i,
                    //End = 40 * (i + 1) - 1,
                    //Text = "Dù khá giả, có điều kiện nhưng một số sao Việt vẫn tin tưởng các thương hiệu" +
                    //" váy cưới trong nước, có giá thành phải chăng"
                    //        }
                    //},
                    Title = "this is a title",
                    Author = "more jump ",
                    Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
                    "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
                    "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
                    "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
                    "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
                    DownloadCount = 96,
                    ID = 456,
                    LinkThumbnail = "chiphu.jpg",
                    IsFavourite = true,
                    Percent = 0,
                    //Level = Level.normal,
                    PathAudio = "/data/data/EApp.Droid/files/.config/music"
                });

                list.Add(new Lesson
                {
                    //ListSentence = new ObservableCollection<Sentence>
                    //{
                    //    new Sentence
                    //    {
                    //Start = 40 * i,
                    //End = 40 * (i + 1) - 1,
                    //Text = "Dù khá giả, có điều kiện nhưng một số sao Việt vẫn tin tưởng các thương hiệu" +
                    //" váy cưới trong nước, có giá thành phải chăng"
                    //        }
                    //},
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
                    //Level = Level.normal,
                    PathAudio = "/data/data/EApp.Droid/files/.config/music"
                });
            }

            return list.ToArray();
        }

        // get all lesson
        public IQueryable<Lesson> GetQueryable()
        {
            return realm.All<Lesson>();
        }

        public void Insert(Lesson lesson)
        {
            var obj = realm.Find<Lesson>(lesson.ID);
            if (obj==null)
            {
                realm.Write(() =>
                {
                    realm.Add(lesson);
                });
            }

        }

        public void Update(Lesson lesson)
        {
            var obj = realm.Find<Lesson>(lesson.ID);
            if (obj != null)
            {
                obj.IsFavourite = lesson.IsFavourite;
                obj.Recent = lesson.Recent;
                obj.DownloadCount = lesson.DownloadCount;
            }

        }

        // deleting a lesson by an ID
        public void Delete(long ID)
        {
            var lesson = realm.Find<Lesson>(ID);

            using (var trans = realm.BeginWrite())
            {
                realm.Remove(lesson);
                trans.Commit();
            }

        }

        // a constructor here
        public LessonRepository(Realm realm)
        {
            this.realm = realm;

                for (var i = 0; i < 3; i++)
                {
                    var lesson = new Lesson
                    {
                        Title = "this is a title",
                        Author = "more jump ",
                        Description = "Từ đầu năm 3 mình bắt đầu đi thực " +
                    "tập, nơi đầu tiên thực tập 6 tháng, mang lạ" +
                    "i nhiều trải nghiệm mới, mọi thứ tuyệt vời, mình " +
                    "tiếp đón những điều mới lạ môi trường doanh nghiệp. " +
                    "Sau đó mình có đi thực tập vị trí tương đương ở 1 công ty nữa",
                        DownloadCount = 96,
                        ID = i,
                        LinkThumbnail = "chiphu.jpg",
                        IsFavourite = true,
                        Percent = 0,
                        //Level = Level.normal,
                        PathAudio = "/data/data/EApp.Droid/files/.config/music"
                    };
                    Insert(lesson);
                   
                }

        }
    }
}
