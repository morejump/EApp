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

        private List<string> _listSentencwe;

        public List<string> Listentence
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
            Listentence = new List<string>();
            for (int i = 0; i < 30; i++)
            {
                Listentence.Add("Are you a football fan? " +
                    "Try this game to see how " +
                    "many football words you" +
                    " know in English. Can you beat the " +
                    "goalkeeper? Good luck!");
            }
        }
    }
}
