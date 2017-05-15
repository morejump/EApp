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
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
            menu.SelectedMenu += Menu_SelectedMenu;

        }

        private async void Menu_SelectedMenu(object sender, MyMenuItem e)
        {
            if (IsPresented)
                IsPresented = !IsPresented;
            var page = new NavigationPage(Activator.CreateInstance(e.Type) as Page);
            Detail = page;
        }


    }
}
