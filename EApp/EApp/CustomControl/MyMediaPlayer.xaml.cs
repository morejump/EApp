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

        public EventHandler ClickPlayBtnEvent;
        public EventHandler<double> ValueSliderChangedEvent;

        // constructor here
        public MyMediaPlayer()
        {
            InitializeComponent();
            MySlider.ValueChanged += MySlider_ValueChanged;
        }

        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double oldVal = (double)e.OldValue;
            double newVal = (double)e.NewValue;

            if (newVal - oldVal > 2 || oldVal - newVal > 2)
            {
                ValueSliderChangedEvent.Invoke(this, newVal);
            }
        }

        public static BindableProperty ValueSliderProperty = BindableProperty.Create(
          propertyName: "ValueSlider",
          returnType: typeof(double),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: default(double),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnValueSliderChanged
      );

        private static void OnValueSliderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newVal = (double)newValue;
            var view = bindable as MyMediaPlayer;
            view.MySlider.Value = newVal;
        }

        public double ValueSlider
        {
            get { return (double)GetValue(ValueSliderProperty); }
            set { SetValue(ValueSliderProperty, value); }
        }

        public static BindableProperty MaxValueSliderProperty = BindableProperty.Create(
          propertyName: "MaxValueSlider",
          returnType: typeof(double),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: default(double),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnMaxValueSliderChanged
      );

        private static void OnMaxValueSliderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newVal = (double)newValue;
            var view = bindable as MyMediaPlayer;
            view.MySlider.Maximum = newVal;
        }

        public double MaxValueSlider
        {
            get { return (double)GetValue(MaxValueSliderProperty); }
            set { SetValue(MaxValueSliderProperty, value); }
        }

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
            var newVal = (bool)newValue;
            if (newVal)
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
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            ClickPlayBtnEvent?.Invoke(this, EventArgs.Empty);

        }

    }
}
