using EApp.Models;
using EApp.Service;
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
    public class FavouritePageViewModel : CoreViewModel
    {
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;

        private ICommand _cmSelectedLesson;

        public ICommand cmSelectedLesson
        {
            get { return _cmSelectedLesson = _cmSelectedLesson ?? new Command(RuncmSelectedLesson); }

        }

        void RuncmSelectedLesson(object obj)
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("lesson", obj as Lesson);
            navigationService.NavigateAsync(Pages.ListSentence, param);

        }

        // delete a lessom when swipe an item to right side
        private ICommand _cmdDeleteLesson;

        public ICommand cmdDeleteLesson
        {
            get { return _cmdDeleteLesson = _cmdDeleteLesson ?? new Command(RuncmdDeleteLesson); }

        }

        async void RuncmdDeleteLesson(object obj)
        {
            var less = obj as Lesson;
            MyList.Remove(less);
        }

        // remove a lesson from a favourite when swiping an item to left side
        private ICommand _cmdRemoveLesson;

        public ICommand cmdRemoveLesson
        {
            get { return _cmdRemoveLesson = _cmdRemoveLesson ?? new Command(RuncmdRemoveLesson); }

        }

        void RuncmdRemoveLesson(object obj)
        {

        }

        private ObservableCollection<Lesson> _myList;

        public ObservableCollection<Lesson> MyList
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

        public FavouritePageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            MyList = new ObservableCollection<Lesson>(LessonRepo.GetAllLesson().Result);

        }
    }
}
