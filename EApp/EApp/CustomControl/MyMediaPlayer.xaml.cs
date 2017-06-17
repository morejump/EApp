using EApp.Models;
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
        private bool isTapEyesBtn;
        public EventHandler ClickPlayBtnEvent;
        public static EventHandler<int> ValueSliderChangedEvent;

        // constructor here
        public MyMediaPlayer()
        {
            isTapEyesBtn = false;
            InitializeComponent();
            MySlider.ValueChanged += MySlider_ValueChanged;
        }

        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int oldVal = (int)e.OldValue;
            int newVal = (int)e.NewValue;

            if (newVal - oldVal > 2000 || oldVal - newVal > 2000)
            {
                ValueSliderChangedEvent.Invoke(this, newVal);
            }
        }


        public static BindableProperty TapEyesBtnProperty = BindableProperty.Create(
          propertyName: "TapEyesBtn",
          returnType: typeof(ICommand),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay
      );

        

        public ICommand TapEyesBtn
        {
            get { return (ICommand)GetValue(TapEyesBtnProperty); }
            set { SetValue(TapEyesBtnProperty, value); }
        }

        public static BindableProperty SelectedItemProperty = BindableProperty.Create(
          propertyName: "SelectedItem",
          returnType: typeof(SentenceModel),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay
      );


        public SentenceModel SelectedItem
        {
            get { return (SentenceModel)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        public static BindableProperty TapRepeatProperty = BindableProperty.Create(
          propertyName: "TapRepeat",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: false,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnTapRepeatChanged
      );

        private static void OnTapRepeatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            if (view.SelectedItem != null && view != null)
            {
                ValueSliderChangedEvent?.Invoke(null, view.SelectedItem.Start * 1000);
            }

        }

        public bool TapRepeat
        {
            get { return (bool)GetValue(TapRepeatProperty); }
            set { SetValue(TapRepeatProperty, value); }
        }


        public static BindableProperty TapBackwardProperty = BindableProperty.Create(
          propertyName: "TapBackward",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: false,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnTapBackwardChanged
      );

        private static void OnTapBackwardChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            ValueSliderChangedEvent.Invoke(null, view.ValueSlider - 3000);
        }

        public bool TapBackward
        {
            get { return (bool)GetValue(TapBackwardProperty); }
            set { SetValue(TapBackwardProperty, value); }
        }

        public static BindableProperty TapForwardProperty = BindableProperty.Create(
          propertyName: "TapForward",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: false,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnTapForwardChanged
      );

        private static void OnTapForwardChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            ValueSliderChangedEvent.Invoke(null, view.ValueSlider + 3000);
        }

        public bool TapForward
        {
            get { return (bool)GetValue(TapForwardProperty); }
            set { SetValue(TapForwardProperty, value); }
        }

        public static BindableProperty ValueSliderProperty = BindableProperty.Create(
          propertyName: "ValueSlider",
          returnType: typeof(int),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: 0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnValueSliderChanged
      );

        private static void OnValueSliderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Device.BeginInvokeOnMainThread(
                () =>
                {
                    int newVal = (int)newValue;
                    MyMediaPlayer view = bindable as MyMediaPlayer;
                    view.MySlider.Value = newVal;
                    TimeSpan time = TimeSpan.FromMilliseconds(newVal);
                    view.lblStart.Text = time.ToString(@"mm\:ss");
                }
                );

        }

        public int ValueSlider
        {
            get { return (int)GetValue(ValueSliderProperty); }
            set { SetValue(ValueSliderProperty, value); }
        }

        public static BindableProperty SentenceModelProperty = BindableProperty.Create(
          propertyName: "SentenceModel",
          returnType: typeof(SentenceModel),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnSentenceModelChanged
      );

        private static void OnSentenceModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newVal = newValue as SentenceModel;
            var view = bindable as MyMediaPlayer;
            if (view != null && newVal != null)
            {
                ValueSliderChangedEvent?.Invoke(null, newVal.Start * 1000);
            }
        }

        public SentenceModel SentenceModel
        {
            get { return (SentenceModel)GetValue(SentenceModelProperty); }
            set { SetValue(SentenceModelProperty, value); }
        }


        public static BindableProperty MaxValueSliderProperty = BindableProperty.Create(
          propertyName: "MaxValueSlider",
          returnType: typeof(int),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: default(int),
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnMaxValueSliderChanged
      );

        private static void OnMaxValueSliderChanged(BindableObject bindable, object oldValue, object newValue)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                var newVal = (int)newValue;
                var view = bindable as MyMediaPlayer;
                view.MySlider.Maximum = newVal;
                TimeSpan time = TimeSpan.FromMilliseconds(newVal);
                view.lblEnd.Text = time.ToString(@"mm\:ss");
            });

        }

        public int MaxValueSlider
        {
            get { return (int)GetValue(MaxValueSliderProperty); }
            set { SetValue(MaxValueSliderProperty, value); }
        }

        public static BindableProperty IsPlayingProperty = BindableProperty.Create(
          propertyName: "IsPlaying",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: true,
          defaultBindingMode: BindingMode.OneWay,
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

        public static BindableProperty PathProperty = BindableProperty.Create(
          propertyName: "Path",
          returnType: typeof(string),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: "",
          defaultBindingMode: BindingMode.OneWay
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
        // when tapping a eyes button
        private void TapEyesButton(object sender, EventArgs e)
        {
            //var view = sender as MyMediaPlayer;
            if (isTapEyesBtn == false)
            {
                MyEyesBtn.Source = "ic_close_eyes.png";
                isTapEyesBtn = !isTapEyesBtn;
            }
            else
            {
                MyEyesBtn.Source = "ic_eyes.png";
                isTapEyesBtn = !isTapEyesBtn;
            }
            if (TapEyesBtn.CanExecute(isTapEyesBtn))
            {
                TapEyesBtn.Execute(isTapEyesBtn);
            }
        }
    }
}
