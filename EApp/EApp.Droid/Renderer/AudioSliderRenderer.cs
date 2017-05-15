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
using Xamarin.Forms.Platform.Android;
using EApp.Renderers;
using System.ComponentModel;
using EApp.Droid.Renderer;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(AudioSlider), typeof(AudioSliderRenderer))]
namespace EApp.Droid.Renderer
{
    public class AudioSliderRenderer: SliderRenderer
    {
        private AudioSlider MainSlider
        {
            get { return (AudioSlider)this.Element; }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.Touch += Control_Touch;
            }
        }

        private void Control_Touch(object sender, TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                MainSlider.IsPressed = true;
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                MainSlider.IsPressed = false;
            }

            e.Handled = false;
        }

        private void Control_StopTrackingTouch(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            MainSlider.IsPressed = false;
        }

        private void Control_StartTrackingTouch(object sender, SeekBar.StartTrackingTouchEventArgs e)
        {
            MainSlider.IsPressed = true;
        }
    }
}