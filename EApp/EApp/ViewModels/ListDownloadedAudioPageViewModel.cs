using EApp.Models;
using EApp.Service;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.ViewModels
{
    public class ListDownloadedAudioPageViewModel : CoreViewModel
    {
        // just for commiting hihihi hihihi
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;

        // temporary list 
        private ObservableCollection<LessonModel> _tempList;

        public ObservableCollection<LessonModel> TempList
        {
            get { return _tempList; }
            set
            {
                if (_tempList != value)
                {
                    _tempList = value;
                    OnPropertyChanged();
                }
            }
        }
       
        private bool _isCheck;

        public bool IsCheck
        {
            get { return _isCheck; }
            set
            {
                if (_isCheck != value)
                {
                    _isCheck = value;
                    OnPropertyChanged();
                }
            }
        }

        
        private ICommand _cmdCheckFavourite;

        public ICommand CmdCheckFavourite
        {
            get { return _cmdCheckFavourite = _cmdCheckFavourite ?? new Command(RuncmdCheckFavourite); }

        }

        void RuncmdCheckFavourite(object obj)
        {
           // do something here later

        }
        
        private ObservableCollection<LessonModel> _myList;

        public ObservableCollection<LessonModel> MyList
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
        private ICommand _cmSelectedLesson;

        public ICommand cmSelectedLesson
        {
            get { return _cmSelectedLesson = _cmSelectedLesson ?? new Command(RuncmSelectedLesson); }

        }

        void RuncmSelectedLesson(object obj)
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("lesson", obj as LessonModel);
            navigationService.NavigateAsync(Pages.ListSentence, param);

        }
        // delete command
        private ICommand _cmdDeleteLesson;

        public ICommand cmdDeleteLesson
        {
            get { return _cmdDeleteLesson = _cmdDeleteLesson ?? new Command(RuncmdDeleteLesson); }

        }

        void RuncmdDeleteLesson(object obj)
        {
            var lesson = obj as LessonModel;
            MyList.Remove(lesson);
            TempList = new ObservableCollection<LessonModel>(MyList);
        }
        private ICommand _searchCommad;

        public ICommand SearchCommand
        {
            get { return _searchCommad = _searchCommad ?? new Command(RunsearchCommad); }

        }

        void RunsearchCommad(object obj)
        {
            var searchedText = obj as string;
            TempList = new ObservableCollection<LessonModel>(MyList.Where(d => d.Title.ToLower().Contains(searchedText.ToLower())));

        }



        public ListDownloadedAudioPageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            IsCheck = false;
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            MyList = new ObservableCollection<LessonModel>(LessonRepo.GetAllLesson().Result);
            TempList = new ObservableCollection<LessonModel>(MyList);
        }

    }


}
