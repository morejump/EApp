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

        private List<int> mylist;

        public List<int> MyList
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
            MyList = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                MyList.Add(i);
            }
        }
    }
}
