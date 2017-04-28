using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public class ListSentenceModel: BindableBase
    {
        private String _sentence;

        public String Sentence
        {
            get { return _sentence; }
            set
            {
                if (_sentence != value)
                {
                    _sentence = value;
                    OnPropertyChanged();
                }
            }
        }

        public ListSentenceModel()
        {
            Sentence = "thao dep trai";
        }
    }
}
