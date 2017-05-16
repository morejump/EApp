using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class SwipeControl : ContentView
    {
        public SwipeControl()
        {
            InitializeComponent();
        }

        public static BindableProperty ImageProperty = BindableProperty.Create(
          propertyName: "Image",
          returnType: typeof(string),
          declaringType: typeof(SwipeControl),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnImageChanged
      );

        private static void OnImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as SwipeControl;
            view.myImage.Source = view.Image;
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }




        public static BindableProperty CommandProperty = BindableProperty.Create(
          propertyName: "Command",
          returnType: typeof(ICommand),
          declaringType: typeof(SwipeControl),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        // doing a command when tapping an image
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ConfirmConfig confirm = new ConfirmConfig();
            confirm.Title = "Warning!!!";
            confirm.Message = "Would you like to delete this lesson";
            confirm.SetAction((x =>
            {
                if (x)
                {
                    // when an user click yes button
                    if (Command.CanExecute(BindingContext))
                    {
                        Command.Execute(BindingContext);
                    }
                }
               
            }));

            // instanitate a confirm dialog here 
            UserDialogs.Instance.Confirm(confirm);

            
        }
    }
}
