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
using EApp.CustomControl;
using Xamarin.Forms;
using EApp.Droid.Renderer;
using Xamarin.Forms.Platform.Android;
using EApp.Droid.Interface;
using EApp.Droid.Media;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyMediaPlayer), typeof(MyMediaPlayerRenderer))]

namespace EApp.Droid.Renderer
{
    public class MyMediaPlayerRenderer : VisualElementRenderer<MyMediaPlayer>
    {
        MyMediaPlayer view;

        SimpleAudioPlayerImplementation media;

        protected override void OnElementChanged(ElementChangedEventArgs<MyMediaPlayer> e)
        {
            base.OnElementChanged(e);
            // do something here later
            view = e.NewElement;
            media = new SimpleAudioPlayerImplementation();
           
           
            view.ClickPlayBtnEvent += (s, arg) =>
            {
                view.IsPlaying = media.IsPlaying;
                if (media.IsPlaying == true)
                {
                    media.Pause();
                    return;
                }
                if (media.IsPlaying == false)
                {
                    media.Play();
                }
            };


        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Path")
            {
                if (view.Path != null)
                {
                    media.Load(view.Path);
                    view.MaxValue = media.Duration;
                }
            }

        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            media.Stop();
        }

    }
}