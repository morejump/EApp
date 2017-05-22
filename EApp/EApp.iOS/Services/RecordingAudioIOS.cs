using EApp.Dependecy;
using EApp.iOS.Services;
using System;
using System.Collections.Generic;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(RecordingAudioIOS))]

namespace EApp.iOS.Services
{
    public class RecordingAudioIOS: IRecordingAudio
    {
        public RecordingAudioIOS()
        {

        }

        public void RecordAudio()
        {
            //implementing this method laterly

        }
    }
}
