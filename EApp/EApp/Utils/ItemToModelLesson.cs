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
            return new LessonItem
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LinkThumbnail = model.LinkThumbnail,
                IsFavourite = model.IsFavourite,
                ID = model.ID,
                Percent = model.Percent,
                //ListSentence = model.ListSentence.Select(d => ModelToItem(d)).ToList(),
                Level = model.Level,
                DownloadCount = model.DownloadCount,
                PathAudio = model.PathAudio,
                Recent = model.Recent

            };

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
            return new LessonModel
            {
                Author = item.Author,
                Description = item.Description,
                Title = item.Title,
                LinkThumbnail = item.LinkThumbnail,
                IsFavourite = item.IsFavourite,
                ID = item.ID,
                Percent = item.Percent,
                ListSentence = item.ListSentence.Select(d=> ItemToModel(d)).ToList(),
                Level = item.Level,
                DownloadCount = item.DownloadCount,
                PathAudio = item.PathAudio,
                Recent = item.Recent
            };
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
