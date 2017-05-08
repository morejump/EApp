using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using EApp.iOS.Effects;
using Xamarin.Forms.Platform.iOS;
using EApp.Effects;

[assembly: ResolutionGroupName("EApp.Effects")]// refactor this line later
[assembly: ExportEffect(typeof(MaxLineLabelIosEffect), "MaxLineLabelEffect")]
namespace EApp.iOS.Effects
{
    public class MaxLineLabelIosEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null)
            {
                var uiLabel = Control as UILabel;
                var effect = (MaxLineLabelEffect)Element.Effects.FirstOrDefault(e => e is MaxLineLabelEffect);
                uiLabel.Lines = effect.MaxLine;

            }

        }

        protected override void OnDetached()
        {
            // do something here later
            //throw new NotImplementedException();
        }
    }
}