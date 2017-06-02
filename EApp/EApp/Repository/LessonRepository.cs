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

            if (realm.All<LessonItem>().ToList<LessonItem>().Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {

                    realm.Write(() =>
                    {
                        var less = new LessonItem
                        {
                            Level=1,
                            IsFavourite= true,
                            ID = i,
                            Title = "thao dep trai is a title",
                            Author = "more jump hihi",
                            Description = "Nothing to show here is a description",
                            PathAudio= "/data/data/EApp.Droid/files/.config/music"
                        };

                        //adding sentences to a Lesson
                        for (int j = 1; j < 5; j++)
                        {
                            var sen = new SentenceItem
                            {
                                Text = "English is either the" +
                                " official language or one of the official languages " +
                                "in almost 60 sovereign states. It is the most commonly spoken ",
                                Start = j,
                                End = j * 20
                            };
                            less.ListSentence.Add(sen);
                        }
                        //
                        realm.Add(less);
                    });
                }
                
            }

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

        public void Update(LessonItem item)
        {
            realm.Write(() => realm.Add(item, update: true));
        }

        public void Delete(long id)
        {
            LessonItem item = realm.Find<LessonItem>(id);
            if (item != null)
            {
                using (var trans = realm.BeginWrite())
                {
                    realm.Remove(item);
                    trans.Commit();
                }
            }
        }


    }
}
