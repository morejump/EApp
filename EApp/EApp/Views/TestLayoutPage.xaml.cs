using Acr.UserDialogs;
using EApp.Service;
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
    public partial class TestLayoutPage : ContentPage
    {

        public TestLayoutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ConfirmConfig confirm = new ConfirmConfig();
            confirm.Title = "this is a title";
            confirm.Message = "would you like to delete this lesson";
            confirm.SetAction((x =>
            {
                if (x)
                {
                    // when an user click yes button
                    Debug.WriteLine("thao handosme" + x);
                }
                else
                {
                    // when an user click cancel button
                    Debug.WriteLine("thao handsoke" + x);
                }
            }));
            UserDialogs.Instance.Confirm(confirm);
        }
    }
}
