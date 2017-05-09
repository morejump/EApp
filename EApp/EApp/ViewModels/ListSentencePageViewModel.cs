using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;

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


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Lesson lesson = parameters.GetValue<Lesson>("lesson");
            Listentence = lesson.ListSentence;
        }


        public ListSentencePageViewModel()
        {
            
            
        }
    }
}
