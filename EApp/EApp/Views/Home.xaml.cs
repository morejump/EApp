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
    public partial class Home : MasterDetailPage
    {
        public Home()
        {
            InitializeComponent();
            var menuPage = new Menu();
            menuPage.Title = "aa";
            menuPage.SelectedMenu += DetailsPage_SelectedMenu;
            Master = menuPage;
            
        }

        private void MenuPage_SelectedMenu(object sender, MenuItem e)
        {
            throw new NotImplementedException();
        }



        private void DetailsPage_SelectedMenu(object sender, MenuItem e)
        {
            if (IsPresented)
                IsPresented = !IsPresented;
            var page = Activator.CreateInstance(e.Type) as Page;
            Detail = page;
        }
    }
}
