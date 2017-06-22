using EApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnFavouritePage : ContentView
    {
        // cmd click
        public static BindableProperty cmdClickProperty = BindableProperty.Create(
          propertyName: "cmdClick",
          returnType: typeof(ICommand),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand cmdClick
        {
            get { return (ICommand)GetValue(cmdClickProperty); }
            set { SetValue(cmdClickProperty, value); }
        }


        // delete an item when swiping the item to right side
        public static BindableProperty cmdDeleteProperty = BindableProperty.Create(
          propertyName: "cmdDelete",
          returnType: typeof(ICommand),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );

        public ICommand cmdDelete
        {
            get { return (ICommand)GetValue(cmdDeleteProperty); }
            set { SetValue(cmdDeleteProperty, value); }
        }

        // remove an item from a favourite list 
        public static BindableProperty cmdRemoveFavouriteProperty = BindableProperty.Create(
          propertyName: "cmdRemoveFavourite",
          returnType: typeof(ICommand),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );


        public ICommand cmdRemoveFavourite
        {
            get { return (ICommand)GetValue(cmdRemoveFavouriteProperty); }
            set { SetValue(cmdRemoveFavouriteProperty, value); }
        }


        public static BindableProperty LevelProperty = BindableProperty.Create(
           propertyName: "Level",
           returnType: typeof(int),
           declaringType: typeof(ItemOnFavouritePage),
           defaultValue: -1,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: OnLevelChanged
       );

        private static void OnLevelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnFavouritePage;
            if (view != null && newValue != null)
            {
                if (view.Level == 0)
                {
                    view.MyLevel.BackgroundColor = Color.Yellow;

                }
                if (view.Level == 1)
                {
                    view.MyLevel.BackgroundColor = Color.Blue;

                }
                if (view.Level == 2)
                {
                    view.MyLevel.BackgroundColor = Color.Red;
                }

            }

        }


        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }
        public static BindableProperty DescriptionProperty = BindableProperty.Create(
          propertyName: "Description",
          returnType: typeof(string),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: "No Descritption",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnDescriptionChanged
      );

        private static void OnDescriptionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnFavouritePage;
            if (view != null && newValue != null)
            {
                view.MyDescription.Text = view.Description;

            }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static BindableProperty TitleProperty = BindableProperty.Create(
          propertyName: "Title",
          returnType: typeof(string),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: "No Title",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnTitleChanged

      );

        private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnFavouritePage;
            if (view != null && newValue != null)
            {
                view.MyTitle.Text = view.Title;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static BindableProperty AuthorProperty = BindableProperty.Create(
          propertyName: "Author",
          returnType: typeof(string),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: "No Author",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnAuthorPropertyChanged
      );

        private static void OnAuthorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnFavouritePage;
            if (view != null && newValue != null)
            {
                view.MyAuthor.Text = "by " + view.Author;
            }
        }

        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }
        public static BindableProperty ThumbnailProperty = BindableProperty.Create(
          propertyName: "Thumbnail",
          returnType: typeof(string),
          declaringType: typeof(ItemOnFavouritePage),
          defaultValue: "chiphu.jpg",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnThumbnailChanged

      );

        private static void OnThumbnailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnFavouritePage;
            if (view != null && newValue != null)
            {
                view.MyThumbnail.Source = view.Thumbnail;
            }
        }

        public string Thumbnail
        {
            get { return (string)GetValue(ThumbnailProperty); }
            set { SetValue(ThumbnailProperty, value); }
        }

        // contructor
        public ItemOnFavouritePage()
        {
            InitializeComponent();
        }

      

    }
}
