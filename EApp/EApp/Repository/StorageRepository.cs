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
                .Child("myenity")
                .OrderByKey()
                .LimitToFirst(5)
                .OnceAsync<LessonModel>();


            foreach (var item in items)
            {
                // adding more fields later

                LessonModel les = new LessonModel()
                {
                    ListSentence = new List<SentenceModel>(item.Object.ListSentence),
                    ID=1234321,
                    Title = item.Object.Title,
                    Author = item.Object.Author,
                    Description = item.Object.Description,
                    Level = item.Object.Level,
                    LinkDownload= "http://zmp3-mp3-s1-te-zmp3-fpthn-1.zadn.vn/11779c713b35d26b8b24/992888775050630550?key=pKjSGlnTjlJWXTn54hIhjA&expires=1497178419"
                };
                list.Add(les);
            }

            return list;

        }

    }
    }



