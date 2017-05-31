using EApp.Models;
using EApp.Service;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.ViewModels
{
    public class StoragePageViewModel: CoreViewModel
    {
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;
        private ObservableCollection<LessonItem> _myList;

        public ObservableCollection<LessonItem> MyList
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


        public StoragePageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            MyList = new ObservableCollection<LessonItem>(LessonRepo.GetQueryable());
        }
    }
}
