using System;
using System.Collections.Generic;
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

        //
        public static BindableProperty SlierValueProperty = BindableProperty.Create(
          propertyName: "SlierValue",
          returnType: typeof(double),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: 0.0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnSliderValueChanged
      );

        private static void OnSliderValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MyMediaPlayer;
            if(view !=null && newValue != null)
            {
                view.MySlider.Value = view.SlierValue;
            }
        }

        public double SlierValue
        {
            get { return (double)GetValue(SlierValueProperty); }
            set { SetValue(SlierValueProperty, value); }
        }

        // constructor here
        public MyMediaPlayer()
        {
            InitializeComponent();
        }

        // change an image when tapping a play button
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (cmdTapPlayButton.CanExecute("par"))
            {
                cmdTapPlayButton.Execute("par");
            }


            isTapPlayButton = !isTapPlayButton;
            MyPlayButton.Source = isTapPlayButton ? "pausebutton.png" : "playbutton.png";
        }

        // change an image when tapping a speed button
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (cmdTapSpeedButton.CanExecute("par"))
            {
                cmdTapSpeedButton.Execute("par");
            }

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
                i=0;
            }
        }
    }
}
