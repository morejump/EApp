﻿using EApp.Utils;
using Prism.Mvvm;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{

    public class Lesson : BindableBase
    {

        // constructor here 
        public Lesson()
        {
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

        private String _PathAudio;

        public String PathAudio
        {
            get { return _PathAudio; }
            set
            {
                if (_PathAudio != value)
                {
                    _PathAudio = value;
                    OnPropertyChanged();
                }
            }
        }

        private Uri _LinkDownload;

        public Uri LinkDownload
        {
            get { return _LinkDownload; }
            set
            {
                if (_LinkDownload != value)
                {
                    _LinkDownload = value;
                    OnPropertyChanged();
                }
            }
        }

        private Level _level;

        public Level Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _percent;

        public int Percent
        {
            get { return _percent; }
            set
            {
                if (_percent != value)
                {
                    _percent = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _downloadCount;

        public int DownloadCount
        {
            get { return _downloadCount; }
            set
            {
                if (_downloadCount != value)
                {
                    _downloadCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _linkThumbnail;

        public string LinkThumbnail
        {
            get { return _linkThumbnail; }
            set
            {
                if (_linkThumbnail != value)
                {
                    _linkThumbnail = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isFavourite;

        public bool IsFavourite
        {
            get { return _isFavourite; }
            set
            {
                if (_isFavourite != value)
                {
                    _isFavourite = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _recent;

        public bool Recent
        {
            get { return _recent; }
            set
            {
                if (_recent != value)
                {
                    _recent = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _author;

        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged();
                }
            }
        }
        // a list sentence when clicking a lesson

        private List<Sentence> _listSentence;

        public List<Sentence> ListSentence
        {
            get { return _listSentence; }
            set
            {
                if (_listSentence != value)
                {
                    _listSentence = value;
                    OnPropertyChanged();
                }
            }
        }
      
    }
}
