using Plugin.MediaManager;
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
        int i = 0;

        // constructor here
        public MyMediaPlayer()
        {
            InitializeComponent();
            MySlider.ValueChanged += MySlider_ValueChanged;
        }

        public static BindableProperty TextEndProperty = BindableProperty.Create(
          propertyName: "TextEnd",
          returnType: typeof(string),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: "",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnTextEndChanged
      );

        private static void OnTextEndChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            view.lblEnd.Text = view.TextEnd;
        }

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
            var view = (MyMediaPlayer)bindable;
            view.MySlider.Value = (int)newValue;
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
        //


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



      
        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
           
        }

        // change an image when tapping a play button
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
          // editing it later
            isTapPlayButton = !isTapPlayButton;
            if (isTapPlayButton)
            {
                MyPlayButton.Source = "pausebutton.png";
                await CrossMediaManager.Current.Play(@"/data/user/0/EApp.Droid/files/KiepDamMe.mp3", MediaFileType.Audio,ResourceAvailability.Local);
            }
            else
            {
                MyPlayButton.Source = "playbutton.png";
                await CrossMediaManager.Current.Stop();

            }
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
                i++;

            }
            else if (i == 2)
            {
                MySpeedButton.Source = "icon_xxx.png";
                i = 0;
            }
        }
    }
}
