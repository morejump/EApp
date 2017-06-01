using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class MyMediaPlayer : ContentView
    {
        bool isFirst = false;
        int i = 0;
        private IPlaybackController PlaybackController => Media?.PlaybackController;

        // constructor here
        public MyMediaPlayer()
        {
            InitializeComponent();
            MySlider.ValueChanged += MySlider_ValueChanged;
           
        }

        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue - e.OldValue > 2 || e.NewValue - e.OldValue < -2)
            {
                Position = (int)MySlider.Value;
                PlaybackController?.SeekTo(MySlider.Value);
            }
        }

        public static BindableProperty DisapearProperty = BindableProperty.Create(
          propertyName: "Disapear",
          returnType: typeof(ICommand),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );


        public ICommand Disapear
        {
            get { return (ICommand)GetValue(DisapearProperty); }
            set { SetValue(DisapearProperty, value); }
        }

        public static BindableProperty TextEndProperty = BindableProperty.Create(
          propertyName: "TextEnd",
          returnType: typeof(string),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: "",
          defaultBindingMode: BindingMode.TwoWay
      );

        public string TextEnd
        {
            get { return (string)GetValue(TextEndProperty); }
            set { SetValue(TextEndProperty, value); }
        }



        public static BindableProperty PathProperty = BindableProperty.Create(
          propertyName: "Path",
          returnType: typeof(string),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: "",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnMediaChanged
      );


        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }


        public static BindableProperty MediaProperty = BindableProperty.Create(
          propertyName: "Media",
          returnType: typeof(IMediaManager),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnMediaChanged
      );

        private async static void OnMediaChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            if (view != null)
            {
                
                if (view.Media != null && view.Path!=null)
                {
                    if (view.Media.Status == MediaPlayerStatus.Stopped)
                    {

                        await view.Media.Play(view.Path, MediaFileType.Audio, ResourceAvailability.Local);

                    }

                    view.Media.StatusChanged += view.Media_StatusChanged;
                    view.Media.PlayingChanged += view.Current_PlayingChanged;
                    if (view.Media.Status == MediaPlayerStatus.Stopped)
                    {
                        view.MyPlayButton.Source = "playbutton.png";
                    }
                    else if (view.Media.Status == MediaPlayerStatus.Playing)
                    {
                        view.MyPlayButton.Source = "pausebutton.png";

                    }
                    else
                    {
                        if (view.Media.Status == MediaPlayerStatus.Paused)
                        {
                            view.MyPlayButton.Source = "playbutton.png";

                        }
                    }
                }
            }
        }

        private void Media_StatusChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.StatusChangedEventArgs e)
        {
            if (e.Status == MediaPlayerStatus.Stopped || e.Status == MediaPlayerStatus.Paused)
            {
                MyPlayButton.Source = "playbutton.png";
            }
            else if (e.Status == MediaPlayerStatus.Playing)
            {
                MyPlayButton.Source = "pausebutton.png";

            }

        }

        public IMediaManager Media
        {
            get { return (IMediaManager)GetValue(MediaProperty); }
            set { SetValue(MediaProperty, value); }
        }


        public static BindableProperty MaxValueProperty = BindableProperty.Create(
          propertyName: "MaxValue",
          returnType: typeof(int),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: 0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnMaxValueChanged
      );

        private static void OnMaxValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            view.MySlider.Maximum = view.MaxValue;
        }

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static BindableProperty PositionProperty = BindableProperty.Create(
          propertyName: "Position",
          returnType: typeof(int),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: 0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnPositionChanged
      );

        private static void OnPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            int oldv = (int)oldValue;
            int newv = (int)newValue;
            if (newv - oldv > 2 || newv - oldv < -2)
            {
                Debug.WriteLine("new value =" + newv + "-old value=" + oldv);
                
                view.PlaybackController?.SeekTo(newv);
            }
        }

        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }


        public bool isTapPlayButton { get; set; }
        //
        public static BindableProperty cmdTapPlayButtonProperty = BindableProperty.Create(
          propertyName: "cmdTapPlayButton",
          returnType: typeof(ICommand),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand cmdTapPlayButton
        {
            get { return (ICommand)GetValue(cmdTapPlayButtonProperty); }
            set { SetValue(cmdTapPlayButtonProperty, value); }
        }


        public static BindableProperty cmdTapSpeedButtonProperty = BindableProperty.Create(
          propertyName: "cmdTapSpeedButton",
          returnType: typeof(ICommand),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand cmdTapSpeedButton
        {
            get { return (ICommand)GetValue(cmdTapSpeedButtonProperty); }
            set { SetValue(cmdTapSpeedButtonProperty, value); }
        }


        // change an image when tapping a play button
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // editing it later
            if (Media.Status == MediaPlayerStatus.Stopped)
            {

                await Media.Play(Path, MediaFileType.Audio, ResourceAvailability.Local);
                Debug.WriteLine("thaohandosme" + Path);

            }
            else if (Media.Status == MediaPlayerStatus.Playing)
            {
                await PlaybackController?.PlayPause();

            }
            else
            {
                if (Media.Status == MediaPlayerStatus.Paused)
                {
                    await PlaybackController?.PlayPause();

                }
            }
        }

        private void Current_PlayingChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.PlayingChangedEventArgs e)
        {
           

            if (isFirst == false)
            {
                MySlider.Value = MySlider.Maximum;
                //
                MySlider.Maximum = e.Duration.TotalSeconds;
                isFirst = true;
                Media.Pause();

            }
            MySlider.Value = e.Position.TotalSeconds;
            Position = (int)Math.Round(e.Position.TotalSeconds);

            int min = e.Duration.Minutes;
            int sec = e.Duration.Seconds;
            //
            lblEnd.Text = min + ":" + sec;
            lblStart.Text = e.Position.ToString(@"mm\:ss");

        }

        // change an image when tapping a speed button
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

            if (i == 0)
            {
                MySpeedButton.Source = "icon_xx.png";
                i++;
            }
            else if (i == 1)
            {
                MySpeedButton.Source = "icon_x.png";
                i = 0;

            }

        }
    }
}
