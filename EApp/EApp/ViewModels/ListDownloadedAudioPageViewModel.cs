using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.ViewModels
{
    public class ListDownloadedAudioPageViewModel : CoreViewModel
    {
        private bool _checkBookMark;

        public bool CheckBookMark
        {
            get { return _checkBookMark; }
            set
            {
                if (_checkBookMark != value)
                {
                    _checkBookMark = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<ItemDemo> mylist;

        public List<ItemDemo> MyList
        {
            get { return mylist; }
            set
            {
                if (mylist != value)
                {
                    mylist = value;
                    OnPropertyChanged();
                }
            }
        }
        private ICommand _tapBookMark;

        public ICommand TapBookMark
        {
            get { return _tapBookMark = _tapBookMark ?? new Command(RuntapBookMark); }

        }

        void RuntapBookMark()
        {
            CheckBookMark = !CheckBookMark;
        }



        public ListDownloadedAudioPageViewModel()
        {
            // the BookMark is uncheck by default
            CheckBookMark = false;
            // this list just is used to test
            MyList = new List<ItemDemo>();
            for (int i = 0; i < 4; i++)
            {
                MyList.Add(new ItemDemo());
            }
        }

        private ItemDemo _ItemSeletect;

        public ItemDemo ItemSeletect
        {
            get { return _ItemSeletect; }
            set
            {
                if (_ItemSeletect != value && value != null)
                {
                    if (_ItemSeletect != null)
                        _ItemSeletect.IsBookmark = false;
                    _ItemSeletect = value;

                    _ItemSeletect.IsBookmark = true;
                    OnPropertyChanged();
                }
            }
        }


    }

    public class ItemDemo : BindableBase
    {
        private bool _IsBookmark;

        public bool IsBookmark
        {
            get { return _IsBookmark; }
            set
            {
                if (_IsBookmark != value)
                {
                    _IsBookmark = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
