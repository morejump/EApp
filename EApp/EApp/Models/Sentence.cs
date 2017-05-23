using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class Sentence: BindableBase
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        public Sentence()
        {
        }

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
