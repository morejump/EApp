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
using Android.Media;
using Android.Content.Res;
using EApp.Service;
using EApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace EApp.Droid
{

    // android service--->
    public class AudioService : IAudio
    {

        // constructor here
        public AudioService()
        {

        }
        // playing audio

        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}