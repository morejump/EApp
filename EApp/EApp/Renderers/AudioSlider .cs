using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EApp.Renderers
{
    public class AudioSlider: Slider
    {
        public AudioSlider()
        {
            this.ValueChanged += AudioSlider_ValueChanged;
        }

        private void AudioSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (IsPressed)
            {
                OutPut = this.Value;
            }
        }

        public bool IsPressed { get; set; }

        public static readonly BindableProperty InputProperty = BindableProperty.Create("Input", typeof(double), typeof(AudioSlider), default(double), BindingMode.TwoWay, null, InputChanged);
        public double Input
        {
            get { return (double)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }


        public static readonly BindableProperty OutPutProperty = BindableProperty.Create("OutPut", typeof(double), typeof(AudioSlider), default(double));
        public double OutPut
        {
            get { return (double)GetValue(OutPutProperty); }
            set { SetValue(OutPutProperty, value); }
        }
        private static void InputChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var slider = (AudioSlider)bindable;
            if (oldValue != newValue)
                slider.Value = (double)newValue;
        }

    }

}
