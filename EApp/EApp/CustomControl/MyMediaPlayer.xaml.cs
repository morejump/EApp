using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class MyMediaPlayer : ContentView
    {
        int i = 0;

        public static BindableProperty isTapPlayButtonProperty = BindableProperty.Create(
          propertyName: "isTapPlayButton",
          returnType: typeof(bool),
          declaringType: typeof(MyMediaPlayer),
          defaultValue: false,
          defaultBindingMode: BindingMode.TwoWay
      );

        public bool isTapPlayButton
        {
            get { return (bool)GetValue(isTapPlayButtonProperty); }
            set { SetValue(isTapPlayButtonProperty, value); }
        }


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
            isTapPlayButton = !isTapPlayButton;
            MyPlayButton.Source = isTapPlayButton ? "pausebutton.png" : "playbutton.png";
        }

        // change an image when taaping a speed button
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
                i=0;
            }
        }
    }
}
