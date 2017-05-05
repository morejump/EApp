using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class Lesson: BindableBase
    {
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
