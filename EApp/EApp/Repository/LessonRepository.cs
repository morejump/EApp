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
                            TimeAccess = DateTimeOffset.Now,
                            Level = 1,
                            IsFavourite = true,
                            ID = i,
                            Title = " " + i + "    thao dep trai is a title",
                            Author = "more jump hihi",
                            Description = "Nothing to show here is a description",
                            PathAudio = "/data/data/EApp.Droid/files/.config/music"
                        };

                        //adding sentences to a Lesson
                        for (int j = 0; j < 5; j++)
                        {
                            var sen = new SentenceItem
                            {
                                Text = "  " + j + "Thao is either the" +
                                " official language or one of the official languages " +
                                "in almost 60 sovereign states. It is the most commonly spoken ",
                                Start = 20 * j,
                                End = 20 * j + 20,
                            };
                            less.ListSentence.Add(sen);
                        }
                        //
                        realm.Add(less);
                    });
                }

            }

        }

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

        public void UpdateTime(long id, DateTimeOffset Date)
        {
            LessonItem item = realm.Find<LessonItem>(id);
            if (item != null)
            {
                using (var trans = realm.BeginWrite())
                {
                    item.TimeAccess = Date;
                    trans.Commit();
                }
            }
        }
    }
    }
