using EApp.Models;
using EApp.Service;
using EApp.Utils;
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
        private ICommand _cmSearch;
        // 
        private List<LessonModel> _TempList;

        public List<LessonModel> TempList
        {
            get { return _TempList; }
            set
            {
                if (_TempList != value)
                {
                    _TempList = value;
                    OnPropertyChanged();
                }
            }
        }

        // an item source here
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

        public ICommand SearchCommand
        {
            get { return _cmSearch = _cmSearch ?? new Command(RuncmSearch); }

        }

        void RuncmSearch(object obj)
        {
            var searchedText = obj as string;
            MyList = new ObservableCollection<LessonModel>(TempList.Where(x => x.IsFavourite == true && x.Title.ToLower().Contains(searchedText.ToLower())));

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

        // delete a lessom when swipe an item to right side
        private ICommand _cmdDeleteLesson;

        public ICommand cmdDeleteLesson
        {
            get { return _cmdDeleteLesson = _cmdDeleteLesson ?? new Command(RuncmdDeleteLesson); }

        }

        async void RuncmdDeleteLesson(object obj)
        {
            var less = obj as LessonModel;
            MyList.Remove(less);
            LessonRepo.Delete(less.ID);
        }

        private ICommand _cmdRemoveLesson;

        public ICommand cmdRemoveLesson
        {
            get { return _cmdRemoveLesson = _cmdRemoveLesson ?? new Command(RuncmdRemoveLesson); }

        }
        // Removing a lesson from favourite list
        void RuncmdRemoveLesson(object obj)
        {
            var les = obj as LessonModel;
            les.IsFavourite = !les.IsFavourite;
            MyList.Remove(les);
            LessonItem item = ItemToModelLesson.ModelToItem(les);
            if (item != null)
            {
                LessonRepo.Update(item);
            }

        }
         
        public FavouritePageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            List<LessonItem> source = LessonRepo.GetQueryable().ToList();
            TempList = new List<LessonModel>(source.Select(d => ItemToModelLesson.ItemToModel(d)));
            MyList = new ObservableCollection<LessonModel>(TempList.Where((l) => l.IsFavourite));
        }
    }
}
