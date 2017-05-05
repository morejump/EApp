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
        private List<int> _myList;

        public List<int> MyList
        {
            get { return _myList; }
            set
            {
                if (_myList != value)
                {
                    _myList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ListDownloadedAudioPageViewModel()
        {
            MyList = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                MyList.Add(1);
            }
        }

    }

   
}
