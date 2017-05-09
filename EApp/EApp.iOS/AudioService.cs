using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using Xamarin.Forms;
using System.IO;
using Foundation;
using AVFoundation;
using EApp.iOS;
using EApp.Service;
[assembly: Dependency(typeof(AudioService))]
namespace EApp.iOS
{

    public class AudioService: NSObject, IAudio, IAVAudioPlayerDelegate
    {
        AVAudioPlayer _player;
        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {

            NSError error = null;
            AVAudioSession.SharedInstance().SetCategory(AVAudioSession.CategoryPlayback, out error);

            string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            _player = AVAudioPlayer.FromUrl(url);
            _player.Delegate = this;
            _player.Volume = 100f;
            _player.PrepareToPlay();
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
                _player = null;
            };
            _player.Play();

        }

        public void Dispose()
        {

        }
    }
}