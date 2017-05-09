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
using Xamarin.Forms;
using EApp.Droid.Effects;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(SelectedItemColorDroidEffect), "SelectedItemColorEffect")]
namespace EApp.Droid.Effects
{
    public class SelectedItemColorDroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var list = Control as Android.Widget.ListView;
            if (list!=null)
            {
                list.SetSelector(Resource.Drawable.listSelector);
            }
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }
    }
}