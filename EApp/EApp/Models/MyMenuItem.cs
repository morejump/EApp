using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Models
{
    public enum TypePage
    {
        Page, Action
    }
    public class MyMenuItem
    {
        
        public string Text { get; set; }
        public Type Type { set; get; }
        public TypePage TypePage { set; get; }
        public string Icon { get; set; }
    }
}
