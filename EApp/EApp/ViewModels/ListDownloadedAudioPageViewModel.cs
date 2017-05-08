using EApp.Models;
using EApp.Service;
using Prism.Mvvm;
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
    public class ListDownloadedAudioPageViewModel : CoreViewModel
    {

        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;

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


        public ListDownloadedAudioPageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            IsCheck = false;
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            MyList = new ObservableCollection<Lesson>(LessonRepo.GetAllLesson().Result);
        }

    }


}
