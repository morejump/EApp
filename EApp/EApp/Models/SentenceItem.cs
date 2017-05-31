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
    public class SentenceItem : RealmObject
    {
        public string Text { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public bool IsSelected { get; set; }

      
    }
}
