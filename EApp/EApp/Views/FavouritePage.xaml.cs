using EApp.CustomControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritePage : ContentPage
    {
        public FavouritePage()
        {
            InitializeComponent();
            ItemOnFavouritePage.SwipeToRight_Event += Item_SwipeToRight_Event;

        }

        private  void Item_SwipeToRight_Event(object sender, Models.Lesson e)
        {
            DisplayAlert("Warning!!!", "Would you like to delete this lesson", "Yes", "No");
            
        }
    }
}
