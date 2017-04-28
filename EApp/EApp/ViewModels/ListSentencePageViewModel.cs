using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.ViewModels
{
    public class ListSentencePageViewModel: CoreViewModel
    {
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

        private List<ListSentenceModel> _listSentencwe;

        public List<ListSentenceModel> Listentence
        {
            get { return _listSentencwe; }
            set
            {
                if (_listSentencwe != value)
                {
                    _listSentencwe = value;
                    OnPropertyChanged();
                }
            }
        }

        public ListSentencePageViewModel()
        {
            //MyList = new List<int>();
            //for (int i = 0; i < 30; i++)
            //{
            //    MyList.Add(1);

            //}
            Listentence = new List<ListSentenceModel>();
            for (int i = 0; i < 30; i++)
            {
                Listentence.Add(new ListSentenceModel());
            }
        }
    }
}
