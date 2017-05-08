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
using EApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using EApp.Effects;

[assembly: ResolutionGroupName("EApp.Effects")]
[assembly: ExportEffect(typeof(MaxLineLabelDroidEffect), "MaxLineLabelEffect")]
namespace EApp.Droid.Effects
{
    public class MaxLineLabelDroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {

            if (Control != null)
            {
                var textView = Control as TextView;
                var effect = (MaxLineLabelEffect)Element.Effects.FirstOrDefault(e => e is MaxLineLabelEffect);
                textView.SetMaxLines(effect.MaxLine);
            }
        }

        protected override void OnDetached()
        {
            // do what???
            //throw new NotImplementedException();
        }
    }
}