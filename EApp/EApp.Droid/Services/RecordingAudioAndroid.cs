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
using Xamarin.Forms;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(RecordingAudioAndroid))]
namespace EApp.Droid.Services
{
    public class RecordingAudioAndroid 
    {
        public RecordingAudioAndroid()
        {

        }
        public void RecordAudio()
        {
            Intent sendIntent = new Intent(MediaStore.Audio.Media.RecordSoundAction);
            //sendIntent.SetAction(Intent.media);
            //sendIntent.SetAction(Intent.ActionSend);
            //sendIntent.PutExtra(Intent.ExtraText, "This is my text to send.");
            //sendIntent.SetType("text/plain");
            var activity = Forms.Context as Activity;
            activity.StartActivity(sendIntent);
        }
    }
}