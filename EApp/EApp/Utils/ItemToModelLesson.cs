using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Utils
{
    public class ItemToModelLesson
    {

        public static LessonItem ModelToItem(LessonModel model)
        {
            List<SentenceItem> listSentenItem = new List<SentenceItem>(model.ListSentence.Select(d => ModelToItem(d)));
            LessonItem item = new LessonItem()
            {
                TimeAccess = model.TimeAccess,
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LinkThumbnail = model.LinkThumbnail,
                IsFavourite = model.IsFavourite,
                ID = model.ID,
                Percent = model.Percent,
                Level = model.Level,
                DownloadCount = model.DownloadCount,
                PathAudio = model.PathAudio,
            };

            foreach (var itemList in listSentenItem)
            {
                item.ListSentence.Add(itemList);

            }
            return item;
           
        }
        public static SentenceItem ModelToItem(SentenceModel model)
        {

            return new SentenceItem
            {
                End = model.End,
                Start = model.Start,
                IsSelected = model.IsSelected,
                Text = model.Text
            };
        }


        public static LessonModel ItemToModel(LessonItem item )
        {
            LessonModel model = new LessonModel()
            {
                TimeAccess = item.TimeAccess,
                Author = item.Author,
                Description = item.Description,
                Title = item.Title,
                LinkThumbnail = item.LinkThumbnail,
                IsFavourite = item.IsFavourite,
                ID = item.ID,
                Percent = item.Percent,
                Level = item.Level,
                DownloadCount = item.DownloadCount,
                PathAudio = item.PathAudio,

            };
            model.ListSentence = new List<SentenceModel>(item.ListSentence.Select(d => ItemToModel(d)));

            return model;
            
        }

        public static SentenceModel ItemToModel(SentenceItem item)
        {
            return new SentenceModel {
                End = item.End,
                Start= item.Start,
                IsSelected= item.IsSelected,
                Text= item.Text
            };
        }
    }

}
