using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager;
using System.IO;

namespace EApp.ViewModels
{
    public class ListSentencePageViewModel : CoreViewModel
    {

        private LessonModel _lesson;

        public LessonModel MyLesson
        {
            get { return _lesson; }
            set
            {
                if (_lesson != value)
                {
                    _lesson = value;
                    OnPropertyChanged();
                }
            }
        }


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
       
        private SentenceModel FindSentenceByPosition(int pos)
        {
             return Listentence.Where(d => d.Start/1000 < pos && pos  < d.End/1000).FirstOrDefault();
             
        }


        private SentenceModel _SelectedSentence;

        public SentenceModel SelectedSentence
        {
            get { return _SelectedSentence; }
            set
            {
                if (_SelectedSentence != value)
                {
                    _SelectedSentence = value;
                    if (_SelectedSentence != null)
                    {
                        Position = _SelectedSentence.Start/1000;
                    }
                    OnPropertyChanged();
                }
            }
        }


        private SentenceModel selectedItem;

        public SentenceModel SelectedItem
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


        private ICommand _PlayBackwardCmd;

        public ICommand PlayBackwardCmd
        {
            get { return _PlayBackwardCmd = _PlayBackwardCmd ?? new Command(RunPlayBackwardCmd); }

        }

        void RunPlayBackwardCmd()
        {

        }
        private ICommand _PlayForwardCmd;

        public ICommand PlayForwardCmd
        {
            get { return _PlayForwardCmd = _PlayForwardCmd ?? new Command(RunPlayForwardCmd); }

        }


        void RunPlayForwardCmd()
        {
            


        }
        private ICommand _RepeatSentenceCMD;

        public ICommand RepeatSentenceCMD
        {
            get { return _RepeatSentenceCMD = _RepeatSentenceCMD ?? new Command(RunRepeatSentenceCMD); }

        }

        void RunRepeatSentenceCMD()
        {
            var start = Listentence.Where(d => d.Start <= Position && Position <= d.End).FirstOrDefault();
            if (start != null)
            {
                // do something here
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

        private List<SentenceModel> _listSentencwe;

        public List<SentenceModel> Listentence
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

        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }
        }
       
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            MyLesson = parameters.GetValue<LessonModel>("lesson");
            Listentence = new List<SentenceModel>(MyLesson.ListSentence);
            if (Listentence.Count > 0)
            {
               // SelectedSentence = Listentence[0];
            }
            Path = MyLesson.PathAudio;
        }

        // constructor here
        public ListSentencePageViewModel()
        {

        }
    }
}
