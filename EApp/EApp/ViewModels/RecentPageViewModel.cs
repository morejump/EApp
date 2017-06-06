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
using EApp.Utils;

namespace EApp.ViewModels
{
    public class RecentPageViewModel : CoreViewModel
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
            LessonRepo.Delete(lesson.ID);

        }


        private ICommand _cmSelectedLesson;

        public ICommand cmSelectedLesson
        {
            get { return _cmSelectedLesson = _cmSelectedLesson ?? new Command(RuncmSelectedLesson); }

        }

        void RuncmSelectedLesson(object obj)
        {
            var les = obj as LessonModel;
            les.TimeAccess = DateTimeOffset.Now;
            LessonItem item = ItemToModelLesson.ModelToItem(les);
            if (item != null)
            {
                LessonRepo.Update(item);
            }
            
            NavigationParameters param = new NavigationParameters();
            param.Add("lesson", les);
            navigationService.NavigateAsync(Pages.ListSentence, param);

        }
        private ICommand _cmdCheckFavourite;

        public ICommand CmdCheckFavourite
        {
            get { return _cmdCheckFavourite = _cmdCheckFavourite ?? new Command(RuncmdCheckFavourite); }

        }

        void RuncmdCheckFavourite(object obj)
        {
            var les = obj as LessonModel;
            les.IsFavourite = !les.IsFavourite;
            LessonItem item = ItemToModelLesson.ModelToItem(les);
            if (item != null)
            {
                LessonRepo.Update(item);
            }

        }

        public RecentPageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            List<LessonItem> source = LessonRepo.GetQueryable().ToList();
            MyList = new ObservableCollection<LessonModel>(source.Select(d => ItemToModelLesson.ItemToModel(d)));
           
        }
    }
}
