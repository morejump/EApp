using EApp.Models;
using EApp.Service;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.ViewModels
{
    public class RecentPageViewModel: CoreViewModel
    {
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;
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
        private ICommand _cmdDeleteLesson;

        public ICommand cmdDeleteLesson
        {
            get { return _cmdDeleteLesson = _cmdDeleteLesson ?? new Command(RuncmdDeleteLesson); }

        }

        void RuncmdDeleteLesson(object obj)
        {
            var lesson = obj as LessonModel;
            MyList.Remove(lesson);
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
        private ICommand _cmdCheckFavourite;

        public ICommand CmdCheckFavourite
        {
            get { return _cmdCheckFavourite = _cmdCheckFavourite ?? new Command(RuncmdCheckFavourite); }

        }

        void RuncmdCheckFavourite(object obj)
        {
           // do something here later :))

        }

        public RecentPageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            MyList = new ObservableCollection<LessonModel>(LessonRepo.GetAllLesson().Result);
        }
    }
}
