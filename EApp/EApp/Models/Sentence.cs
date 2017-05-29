using Prism.Mvvm;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class Sentence: RealmObject, INotifyPropertyChanged
    {
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _Start;

        public int Start
        {
            get { return _Start; }
            set
            {
                if (_Start != value)
                {
                    _Start = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _End;

        public int End
        {
            get { return _End; }
            set
            {
                if (_End != value)
                {
                    _End = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Sentence()
        {
        }

        private bool _IsSelected;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }


    }
}
