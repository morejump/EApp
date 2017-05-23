using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EApp.Droid.Services;
using EApp.Dependecy;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ToastAndroid))]

namespace EApp.Droid.Services
{
    public class ToastAndroid: IToast
    {
        public ToastAndroid()
        {

        }

        public void MakeToast(string message)
        {
          
            Toast.MakeText(Forms.Context, message, ToastLength.Long).Show();
        }
    }
}