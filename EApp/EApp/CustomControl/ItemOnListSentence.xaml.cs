using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnListSentence : ContentView
    {

        public static BindableProperty IsSelectedProperty = BindableProperty.Create(
          propertyName: "IsSelected",
          returnType: typeof(bool),
          declaringType: typeof(ItemOnListSentence),
          defaultValue: false,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnIsSelectedChanged
      );

        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnListSentence;
            if(view.IsTapEyesBtn== true && view.IsSelected==true)
            {
                view.MyBackground.Color = Color.Black;
            }
            else if(view.IsTapEyesBtn == true && view.IsSelected == false)
            {
                view.MyBackground.Color = Color.White;
            }
            else if (view.IsTapEyesBtn == false && view.IsSelected == true)
            {
                view.MyBackground.Color = Color.Green;
            }
            else if (view.IsTapEyesBtn == false && view.IsSelected == false)
            {
                view.MyBackground.Color = Color.White;
            }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }


        public static BindableProperty IsTapEyesBtnProperty = BindableProperty.Create(
          propertyName: "IsTapEyesBtn",
          returnType: typeof(bool),
          declaringType: typeof(ItemOnListSentence),
          defaultValue: false,
          defaultBindingMode: BindingMode.OneWay
      );


        public bool IsTapEyesBtn
        {
            get { return (bool)GetValue(IsTapEyesBtnProperty); }
            set { SetValue(IsTapEyesBtnProperty, value); }
        }


        public static BindableProperty TextProperty = BindableProperty.Create(
          propertyName: "Text",
          returnType: typeof(string),
          declaringType: typeof(ItemOnListSentence),
          defaultValue: "",
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnTextChanged
      );

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnListSentence;
            var newVal = (string)newValue;
            view.MyText.Text = newVal;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ItemOnListSentence()
        {
            InitializeComponent();
            MyBackground.Color = Color.White;
        }
    }
}
