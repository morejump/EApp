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
using System.IO;

namespace EApp.CustomControl
{
    public partial class MyMediaPlayer : ContentView
    {
        int i = 0;
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
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
                PlaybackController.SeekTo(MySlider.Value);
            }
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
                view.PlaybackController.SeekTo(newv);
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
            isTapPlayButton = !isTapPlayButton;
            if (isTapPlayButton)
            {
                MyPlayButton.Source = "pausebutton.png";
                
                await CrossMediaManager.Current.Play("http://zmp3-mp3-s1-te-zmp3-fpthn-1.zadn.vn/11779c713b35d26b8b24/992888775050630550?key=ip7LPVb1UkVmpS_F51-Fng&expires=1495601215");
                CrossMediaManager.Current.PlayingChanged += Current_PlayingChanged;
            }
            else
            {
                MyPlayButton.Source = "playbutton.png";
                await PlaybackController.Pause();

            }
        }

        private void Current_PlayingChanged(object sender, Plugin.MediaManager.Abstractions.EventArguments.PlayingChangedEventArgs e)
        {
            int min = CrossMediaManager.Current.Duration.Minutes;
            int sec = CrossMediaManager.Current.Duration.Seconds;
            //
            lblEnd.Text = min+ ":" + sec;
            var timespan = TimeSpan.FromSeconds(Position);
            lblStart.Text = timespan.ToString(@"mm\:ss");
            //
            MySlider.Maximum = e.Duration.TotalSeconds;
            MySlider.Value = e.Position.TotalSeconds;
            Position = (int)Math.Round(e.Position.TotalSeconds);
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
