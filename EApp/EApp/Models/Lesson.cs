using EApp.Utils;
using Prism.Mvvm;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{

    public class Lesson : RealmObject
    {

        //constructor here
        public Lesson()
        {
            
        }
        public String PathAudio { get; set; }

        //public Uri LinkDownload { get; set; }
       
        //public Level Level { get; set; }
      

        public int ID { get; set; }
       
        public int Percent { get; set; }
       
        public int DownloadCount { get; set; }
      
        public string Title { get; set; }
       
        public string Description { get; set; }
        
        public string LinkThumbnail { get; set; }
        
        public bool IsFavourite { get; set; }
       
        public bool Recent { get; set; }
       
        public string Author { get; set; }

        public IList<Sentence> ListSentence { get; }



    }
}

