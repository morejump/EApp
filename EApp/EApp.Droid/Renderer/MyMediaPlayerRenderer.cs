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
using System.Threading.Tasks;
using Java.Lang;

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
            view = e.NewElement;
            //
            media = new SimpleAudioPlayerImplementation();
            media.PlaybackEnded += Media_PlaybackEnded;

            MyMediaPlayer.ValueSliderChangedEvent += (s, arg) =>
            {
                media.Seek(arg);
            };

            view.ClickPlayBtnEvent += (s, arg) =>
            {
                view.IsPlaying = media.IsPlaying;
                if (!media.IsPlaying)
                {
                    media.Play();
                }
                else
                {
                    media.Pause();
                }
            };

        }
     
        private void Media_PlaybackEnded(object sender, EventArgs e)
        {
            view.IsPlaying = true;
        }

        protected override async void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Path")
            {

                media.Load(view.Path);
                view.MaxValueSlider = media.Duration;
               await Task.Run(() =>
                {
                    while (true)
                    {
                        view.ValueSlider = media.CurrentPosition;
                        Task.Delay(200);
                    }
                });

                media.Play();
                view.IsPlaying = false;
            }
             
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            media.Stop();

        }

    }
}