using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.ViewModels
{
    public class CoreViewModel : BindableBase, INavigationAware
    {
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
             
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
             
        }
    }
}
