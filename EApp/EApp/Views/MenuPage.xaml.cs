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
        }

        private void MyList_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            SelectedMenu?.Invoke(sender, e.ItemData as MyMenuItem);

        }

    }

}
