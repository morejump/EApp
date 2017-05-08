using Prism.Mvvm;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class Lesson: BindableBase
    {

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

        private List<string> _listSentence;

        public List<string> ListSentence
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
        // constructor here 
        public Lesson()
        {

        }
    }
}
