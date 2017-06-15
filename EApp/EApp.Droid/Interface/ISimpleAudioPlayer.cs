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
using System.IO;

namespace EApp.Droid.Interface
{
    public interface ISimpleAudioPlayer: IDisposable
    {
        ///<Summary>
        /// Raised when audio playback completes successfully 
        ///</Summary>
        event EventHandler PlaybackEnded;

        ///<Summary>
        /// Length of audio in seconds
        ///</Summary>
        int Duration { get; }

        ///<Summary>
        /// Current position of audio playback in seconds
        ///</Summary>
        int CurrentPosition { get; }

        ///<Summary>
        /// Playback volume 0 to 1 where 0 is no-sound and 1 is full volume
        ///</Summary>
        double Volume { get; set; }

        ///<Summary>
        /// Balance left/right: -1 is 100% left : 0% right, 1 is 100% right : 0% left, 0 is equal volume left/right
        ///</Summary>
        int Balance { get; set; }

        ///<Summary>
        /// Indicates if the currently loaded audio file is playing
        ///</Summary>
        bool IsPlaying { get; }

        bool Loop { get; set; }

        ///<Summary>
        /// Indicates if the position of the loaded audio file can be updated
        ///</Summary>
        bool CanSeek { get; }

        ///<Summary>
        /// Load wav or mp3 audio file as a stream
        ///</Summary>

        ///<Summary>
        /// Load wav or mp3 audio file from local path
        ///</Summary>
        bool Load(string PathAudio);

        ///<Summary>
        /// Begin playback or resume if paused
        ///</Summary>
        void Play();

        ///<Summary>
        /// Pause playback if playing (does not resume)
        ///</Summary>
        void Pause();

        ///<Summary>
        /// Stop playack and set the current position to the beginning
        ///</Summary>
        void Stop();

        ///<Summary>
        /// Set the current playback position (in seconds)
        ///</Summary>
        void Seek(int position);
    }
}