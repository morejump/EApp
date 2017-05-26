using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.ViewModels
{
    public class ListSentencePageViewModel : CoreViewModel
    {

        private int _Position;

        public int Position
        {
            get { return _Position; }
            set
            {
                if (_Position != value)
                {
                    _Position = value;
                    SelectedItem = FindSentenceByPosition(_Position);
                    OnPropertyChanged();
                }
            }
        }



        private Sentence FindSentenceByPosition(int pos)
        {
            return Listentence.Where(d => d.Start <= pos && pos <= d.End).FirstOrDefault();

        }


        private Sentence _SelectedSentence;

        public Sentence SelectedSentence
        {
            get { return _SelectedSentence; }
            set
            {
                if (_SelectedSentence != value)
                {
                    _SelectedSentence = value;
                    if (_SelectedSentence != null)
                    {
                        Position = _SelectedSentence.Start;
                    }
                    OnPropertyChanged();
                }
            }
        }


        private Sentence selectedItem;

        public Sentence SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    if (selectedItem != null)
                        selectedItem.IsSelected = false;
                    selectedItem = value;
                    if (selectedItem != null)
                        selectedItem.IsSelected = true;
                    OnPropertyChanged();
                }
            }
        }
        private ICommand _TapItem;

        public ICommand TapItem
        {
            get { return _TapItem = _TapItem ?? new Command(RunTapItem); }

        }

        void RunTapItem()
        {


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

        private List<Sentence> _listSentencwe;

        public List<Sentence> Listentence
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
            Listentence = new List<Sentence>(lesson.ListSentence);
        }


        public ListSentencePageViewModel()
        {


        }
    }
}
