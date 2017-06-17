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
    public class StoragePageViewModel: CoreViewModel
    {
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;
        IStorageRepository _StorageRepo;

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
        private ICommand _CmdInsert;

        public ICommand CmdInsert
        {
            get { return _CmdInsert = _CmdInsert ?? new Command(RunCmdInsert); }

        }

        void RunCmdInsert(object obj)
        {
            var les = obj as LessonModel;
            LessonRepo.Update(ItemToModelLesson.ModelToItem(les));
        }

        private ObservableCollection<string> _ListCategory;

        public ObservableCollection<string> ListCategory
        {
            get { return _ListCategory; }
            set
            {
                if (_ListCategory != value)
                {
                    _ListCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _SelectedCategory;

        public string SelectedCategory
        {
            get { return _SelectedCategory; }
            set
            {
                if (_SelectedCategory != value)
                {
                    _SelectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }


        public  StoragePageViewModel(INavigationService navigationService, ILessonRepository LessonRepo, IStorageRepository StorageRepo)
        {
            GetListCategory();
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            _StorageRepo = StorageRepo;
            GetData();
            
        }

        async void GetData()
        {
            if (MyList == null)
            {
                var searchResult = await _StorageRepo.SearchLesson("hihi");
                MyList = new ObservableCollection<LessonModel>(searchResult);
            }
        }
        private void GetListCategory()
        {
            ListCategory = new ObservableCollection<string>()
            {
                "Thế giới",
                "Xã hội",
                "Thể thao",
                "Tin Tức"
            };
        }
  
    }
}
