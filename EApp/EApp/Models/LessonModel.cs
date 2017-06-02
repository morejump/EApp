using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class LessonModel: BindableBase
    {
        private DateTimeOffset _TimeAccess;

        public DateTimeOffset TimeAccess
        {
            get { return _TimeAccess; }
            set
            {
                if (_TimeAccess != value)
                {
                    _TimeAccess = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _PathAudio;

        public string PathAudio
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

        private string _LinkDownload;

        public string MyProperty
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

        private int _Level;

        public int Level
        {
            get { return _Level; }
            set
            {
                if (_Level != value)
                {
                    _Level = value;
                    OnPropertyChanged();
                }
            }
        }

        private long _ID;

        public long ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _Percent;

        public int Percent
        {
            get { return _Percent; }
            set
            {
                if (_Percent != value)
                {
                    _Percent = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _DownloadCount;

        public int DownloadCount
        {
            get { return _DownloadCount; }
            set
            {
                if (_DownloadCount != value)
                {
                    _DownloadCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _LinkThumbnail;

        public string LinkThumbnail
        {
            get { return _LinkThumbnail; }
            set
            {
                if (_LinkThumbnail != value)
                {
                    _LinkThumbnail = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _IsFavourite;

        public bool IsFavourite
        {
            get { return _IsFavourite; }
            set
            {
                if (_IsFavourite != value)
                {
                    _IsFavourite = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _Recent;

        public bool Recent
        {
            get { return _Recent; }
            set
            {
                if (_Recent != value)
                {
                    _Recent = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _Author;

        public string Author
        {
            get { return _Author; }
            set
            {
                if (_Author != value)
                {
                    _Author = value;
                    OnPropertyChanged();
                }
            }
        }

        private IList<SentenceModel> _ListSentence;

        public IList<SentenceModel> ListSentence
        {
            get { return _ListSentence; }
            set
            {
                if (_ListSentence != value)
                {
                    _ListSentence = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
