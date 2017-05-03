using EApp.Models;
using EApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.ViewModels
{
    public class MenuPageViewModel : CoreViewModel
    {
        private List<MyMenuItem> _listItem;

        public List<MyMenuItem> ListItem
        {
            get { return _listItem; }
            set { _listItem = value; }
        }


        public MenuPageViewModel()
        {
            // initializing listItem
            ListItem = new List<MyMenuItem>
            {
               new MyMenuItem
               {
                   Text="menu 1",
                   Type= typeof(ListDownloadedAudioPage)
               },
               new MyMenuItem
               {
                   Text="menu 2",
                   Type= typeof(ListDownloadedAudioPage)
               },
               new MyMenuItem
               {
                   Text="menu 3",
                   Type= typeof(ListDownloadedAudioPage)
               },

            };
        }
    }
}
