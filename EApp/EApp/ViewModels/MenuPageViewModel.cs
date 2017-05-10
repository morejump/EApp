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
                   Text="Recent",
                   Type= typeof(RecentPage),
                   Icon="Recent.png"
               },
               new MyMenuItem
               {
                   Text="Favourites",
                   Type= typeof(FavouritePage),
                   Icon="heart.png"

               },
               new MyMenuItem
               {
                   Text="Downloaded",
                   Type= typeof(ListDownloadedAudioPage),
                   Icon="Downloaded.png"

               },
               new MyMenuItem
               {
                   Text="Storage",
                   Type= typeof(StoragePage),
                   Icon="Storage.png"
               },
               new MyMenuItem
               {
                   Text="Record My Voice",
                   Type= typeof(RecordMyVoicePage),
                   Icon="Mic.png"
               }
            };
        }
    }
}
