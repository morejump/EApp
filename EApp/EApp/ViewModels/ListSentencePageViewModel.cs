using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;
using System.Diagnostics;

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

        private bool _isTapEyesBtn;

        public bool isTapEyesBtn
        {
            get { return _isTapEyesBtn; }
            set
            {
                if (_isTapEyesBtn != value)
                {
                    _isTapEyesBtn = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _TapEyesBtn;

        public ICommand TapEyesBtn
        {
            get { return _TapEyesBtn = _TapEyesBtn ?? new Command(RunTapEyesBtn); }

        }

        void RunTapEyesBtn(object obj)
        {
             isTapEyesBtn = (bool)obj;
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
            return Listentence.Where(d => d.Start * 1000 < pos && pos < d.End * 1000).FirstOrDefault();
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
                        OnPropertyChanged();
                    }
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
        private bool _TapRepeat;

        public bool TapRepeat
        {
            get { return _TapRepeat; }
            set
            {
                if (_TapRepeat != value)
                {
                    _TapRepeat = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _TapBackward;

        public bool TapBackward
        {
            get { return _TapBackward; }
            set
            {
                if (_TapBackward != value)
                {
                    _TapBackward = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _TapForward;

        public bool TapForward
        {
            get { return _TapForward; }
            set
            {
                if (_TapForward != value)
                {
                    _TapForward = value;
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
            TapBackward = !TapBackward;
        }
        private ICommand _PlayForwardCmd;

        public ICommand PlayForwardCmd
        {
            get { return _PlayForwardCmd = _PlayForwardCmd ?? new Command(RunPlayForwardCmd); }

        }


        void RunPlayForwardCmd(object obj)
        {
            TapForward = !TapForward;

        }
        private ICommand _RepeatSentenceCMD;

        public ICommand RepeatSentenceCMD
        {
            get { return _RepeatSentenceCMD = _RepeatSentenceCMD ?? new Command(RunRepeatSentenceCMD); }

        }

        void RunRepeatSentenceCMD()
        {
            TapRepeat = !TapRepeat;

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
            Path = MyLesson.PathAudio;
        }
        public ListSentencePageViewModel()
        {
           
        }

     
    }
}
