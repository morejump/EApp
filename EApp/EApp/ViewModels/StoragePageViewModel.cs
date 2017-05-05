using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.ViewModels
{
    public class StoragePageViewModel: CoreViewModel
    {
        private List<int> _mylist;

        public List<int> MyList
        {
            get { return _mylist; }
            set
            {
                if (_mylist != value)
                {
                    _mylist = value;
                    OnPropertyChanged();
                }
            }
        }


        public StoragePageViewModel()
        {
            MyList = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                MyList.Add(i);
            }

        }
    }
}
