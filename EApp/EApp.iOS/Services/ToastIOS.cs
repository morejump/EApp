using EApp.Dependecy;
using EApp.iOS.Services;
using System;
using System.Collections.Generic;
using System.Text;


[assembly: Xamarin.Forms.Dependency(typeof(ToastIOS))]
namespace EApp.iOS.Services
{
    public class ToastIOS: IToast
    {
        public ToastIOS()
        {

        }

        public void MakeToast(string message)
        {
            // do nothing :))
        }
    }
}
