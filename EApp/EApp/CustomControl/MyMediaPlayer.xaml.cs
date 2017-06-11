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

        // constructor here
        public MyMediaPlayer()
        {
            InitializeComponent();
        }

        public EventHandler ClickPlayBtnEvent;

       
        public static BindableProperty IsPlayingProperty = BindableProperty.Create(
          propertyName: "IsPlaying",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: true,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnIsPlayingChanged
      );

        private static void OnIsPlayingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            if (view.IsPlaying)
            {
                view.MyPlayButton.Source = "playbutton.png";
            }
            else
            {
                view.MyPlayButton.Source = "pausebutton.png";
            }
        }

        public bool IsPlaying
        {
            get { return (bool)GetValue(IsPlayingProperty); }
            set { SetValue(IsPlayingProperty, value); }
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
          defaultBindingMode: BindingMode.TwoWay
      );


        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }


        public static BindableProperty MaxValueProperty = BindableProperty.Create(
          propertyName: "MaxValue",
          returnType: typeof(double),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: default(double),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnMaxValueChanged
      );

        private static void OnMaxValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            double newVal = (double)newValue;
            var view = bindable as MyMediaPlayer;
            if (newValue != null)
            {
                view.MySlider.Maximum = newVal;
            }
        }

        public double MaxValue
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
        }

        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }


        public bool isTapPlayButton { get; set; }

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



        // change an image when tapping a play button
        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

                ClickPlayBtnEvent?.Invoke(this, EventArgs.Empty);

        }

        

      
    }
}
