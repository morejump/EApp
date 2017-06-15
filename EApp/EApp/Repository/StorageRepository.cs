using EApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EApp.Models;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System.Diagnostics;
using Firebase.Xamarin.Token;
using Firebase.Xamarin.Auth;

namespace EApp.Repository
{
    public class StorageRepository : IStorageRepository
    {

        public async Task<List<LessonModel>> SearchLesson(string keyword)
        {
            List<LessonModel> list = new List<LessonModel>();

            var firebase = new FirebaseClient("https://eapp-7095b.firebaseio.com");
            var items = await firebase
                .Child("e_upload")
                .OrderByKey()
                .LimitToFirst(20)
                .OnceAsync<LessonModel>();

            foreach (var item in items)
            {
                LessonModel les = new LessonModel()
                {
                    ListSentence = new List<SentenceModel>(item.Object.ListSentence),
                    ID = item.Object.ID,
                    Title = item.Object.Title,
                    Author = item.Object.Author,
                    Description = item.Object.Description,
                    Level = item.Object.Level,
                    LinkDownload = item.Object.LinkDownload
                };
                list.Add(les);
            }

            return list;

        }

    }
    }



