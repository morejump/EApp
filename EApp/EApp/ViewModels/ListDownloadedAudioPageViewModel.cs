﻿using EApp.Models;
using EApp.Service;
using EApp.Utils;
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
        readonly INavigationService navigationService;
        ILessonRepository LessonRepo;

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
            var les = obj as LessonModel;
            les.IsFavourite = !les.IsFavourite;
            LessonItem item = ItemToModelLesson.ModelToItem(les);
            if (item != null)
            {
                LessonRepo.Update(item);
            }
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
        private ICommand _searchCommad;

        public ICommand SearchCommand
        {
            get { return _searchCommad = _searchCommad ?? new Command(RunsearchCommad); }

        }

        void RunsearchCommad(object obj)
        {
            var searchedText = obj as string;
            MyList = new ObservableCollection<LessonModel>(TempList.Where(x => x.Title.ToLower().Contains(searchedText.ToLower())));

        }



        public ListDownloadedAudioPageViewModel(INavigationService navigationService, ILessonRepository LessonRepo)
        {
            IsCheck = false;
            this.navigationService = navigationService;
            this.LessonRepo = LessonRepo;
            List<LessonItem> source = LessonRepo.GetQueryable().ToList();
            MyList = new ObservableCollection<LessonModel>(source.Select(d => ItemToModelLesson.ItemToModel(d)));
            TempList = new ObservableCollection<LessonModel>(MyList);
        }

    }


}
