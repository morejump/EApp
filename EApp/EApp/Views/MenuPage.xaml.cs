using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public event EventHandler<MyMenuItem> SelectedMenu;
        public MenuPage()
        {
            InitializeComponent();
            myList.ItemSelected += MyList_ItemSelected;
            
        }

        private void MyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedMenu?.Invoke(this, e.SelectedItem as MyMenuItem);
        }
    }

}
