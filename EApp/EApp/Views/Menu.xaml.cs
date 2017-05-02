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
    public partial class Menu : ContentPage
    {
        public event EventHandler<MenuItem> SelectedMenu;
        public Menu()
        {
            InitializeComponent();
            lstView.ItemsSource = new List<MenuItem>{
                new MenuItem
                {
                    Text = "Menu1",
                    Type = typeof(Page1)
                },
                new MenuItem
                {
                    Text = "Menu2"
                    ,
                    Type = typeof(Page2)
                },
                new MenuItem
                {
                    Text = "Menu3"
                    ,
                    Type = typeof(ListDownloadedAudioPage)
                },
            };
            lstView.ItemSelected += LstView_ItemSelected;
        }

        private void LstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedMenu?.Invoke(this, e.SelectedItem as MenuItem);
        }
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public Type Type { set; get; }
    }
}
