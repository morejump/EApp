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

namespace EApp.ViewModels
{
    public class ListSentencePageViewModel : CoreViewModel
    {

        private LessonItem _lesson;

        public LessonItem MyLesson
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


        private SentenceItem FindSentenceByPosition(int pos)
        {
            return Listentence.Where(d => d.Start <= pos && pos <= d.End).FirstOrDefault();

        }


        private SentenceItem _SelectedSentence;

        public SentenceItem SelectedSentence
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


        private SentenceItem selectedItem;

        public SentenceItem SelectedItem
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
            if (Position - 15 <= 0)
            {
                MediaManager.Seek(new TimeSpan(0, 0, 0));
            }
            else
            {
                MediaManager.Seek(new TimeSpan(0, 0, Position - 15));
            }
        }
        private ICommand _PlayForwardCmd;

        public ICommand PlayForwardCmd
        {
            get { return _PlayForwardCmd = _PlayForwardCmd ?? new Command(RunPlayForwardCmd); }

        }


        void RunPlayForwardCmd()
        {
            var LastElement = Listentence[Listentence.Count() - 1];
            if (LastElement != null)
            {

                if (Position + 15 >= LastElement.End)
                {
                    MediaManager.Seek(new TimeSpan(0, 0, LastElement.End));
                }
                else
                {
                    MediaManager.Seek(new TimeSpan(0, 0, Position + 15));
                }
            }



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
                MediaManager.Seek(new TimeSpan(0, 0, start.Start));
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

        private List<SentenceItem> _listSentencwe;

        public List<SentenceItem> Listentence
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
        private ICommand _cmdDisapear;

        public ICommand cmdDisapear
        {
            get { return _cmdDisapear = _cmdDisapear ?? new Command(RuncmdDisapear); }

        }

        void RuncmdDisapear()
        {
            MediaManager.Stop();
            MediaManager.MediaNotificationManager?.StopNotifications();
            MediaManager.MediaNotificationManager = null;
            MediaManager = null;
        }



        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            MyLesson = parameters.GetValue<LessonItem>("lesson");
            //Listentence = new List<Sentence>(MyLesson.ListSentence);
            if (Listentence.Count > 0)
                SelectedSentence = Listentence[0];
            Path = MyLesson.PathAudio;

        }
        private IMediaManager mediaManager;

        public IMediaManager MediaManager
        {
            get { return mediaManager; }
            set
            {
                if (mediaManager != value)
                {
                    mediaManager = value;
                    OnPropertyChanged();
                }
            }
        }

        // constructor here
        public ListSentencePageViewModel(IMediaManager mediaManager)
        {
            this.MediaManager = mediaManager;


        }
    }
}
