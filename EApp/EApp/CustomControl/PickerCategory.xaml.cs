using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class PickerCategory : ContentView
    {
        public PickerCategory()
        {
            InitializeComponent();
            MyPicker.ItemsSource = new List<string>
            {
                "Kinh tế",
                "Thể thao",
                "Xã hội",
                "Chính trị"
            };
        }

        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(
          propertyName: "ItemsSource",
          returnType: typeof(IList),
          declaringType: typeof(PickerCategory),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnItemsSourceChanged
      );

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // do something here
            var view = bindable as PickerCategory;
            //view.MyPicker.ItemsSource = new List<string>(newValue)
           ;

        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }



        public static BindableProperty TitleProperty = BindableProperty.Create(
          propertyName: "Title",
          returnType: typeof(string),
          declaringType: typeof(PickerCategory),
          defaultValue: "",
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnTitleChanged
      );

        private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as PickerCategory;
            var newVal = (string)newValue;
            view.MyPicker.Title = newVal;

        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }



        public static BindableProperty SelectedItemProperty = BindableProperty.Create(
          propertyName: "SelectedItem",
          returnType: typeof(object),
          declaringType: typeof(PickerCategory),
          defaultValue: null,
          defaultBindingMode: BindingMode.OneWayToSource,
          propertyChanged: OnSelectedItemChanged
      );

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as PickerCategory;
            view.MyPicker.SelectedItem = newValue;
        }

        public int SelectedItem
        {
            get { return (int)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

    }
}
