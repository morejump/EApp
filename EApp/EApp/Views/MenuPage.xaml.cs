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
            myList.ItemTapped += MyList_ItemTapped;
            //myList.ItemSelected += MyList_ItemSelected;
            Padding = Device.OnPlatform(
                iOS: new Thickness(0, 20, 0, 0),
                Android: new Thickness(0, 20, 0, 0),
                WinPhone: new Thickness(0, 20, 0, 0));

        }

        private void MyList_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            //throw new NotImplementedException();
            SelectedMenu?.Invoke(this, e.ItemData as MyMenuItem);//

        }

        //private void MyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    SelectedMenu?.Invoke(this, e.SelectedItem as MyMenuItem);//
        //}
    }

}
