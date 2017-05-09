using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnList : ContentView
    {
        public bool isFavourite { get; set; }

        public static BindableProperty AuthorProperty = BindableProperty.Create(
          propertyName: "Author",
          returnType: typeof(string),
          declaringType: typeof(ItemOnList),
          defaultValue: "No Author",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnAuthorPropertyChanged
      );

        private static void OnAuthorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnList;
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

        public static BindableProperty hasMoreOptionsProperty = BindableProperty.Create(
          propertyName: "hasMoreOptions",
          returnType: typeof(bool),
          declaringType: typeof(ItemOnList),
          defaultValue: true,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnHasMoreOptionsChanged
      );

        private static void OnHasMoreOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnList;
            if (view != null && newValue != null)
            {
                view.MoreImage.IsVisible = view.hasMoreOptions;
            }
        }

        public bool hasMoreOptions
        {
            get { return (bool)GetValue(hasMoreOptionsProperty); }
            set { SetValue(hasMoreOptionsProperty, value); }
        }


        public static BindableProperty ThumbnailProperty = BindableProperty.Create(
          propertyName: "Thumbnail",
          returnType: typeof(string),
          declaringType: typeof(ItemOnList),
          defaultValue: "avatar.png",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnThumbnailChanged

      );

        private static void OnThumbnailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnList;
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


        public static BindableProperty TitleProperty = BindableProperty.Create(
          propertyName: "Title",
          returnType: typeof(string),
          declaringType: typeof(ItemOnList),
          defaultValue: "No Title",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnTitleChanged

      );

        private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnList;
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
        //


        public static BindableProperty DescriptionProperty = BindableProperty.Create(
          propertyName: "Description",
          returnType: typeof(string),
          declaringType: typeof(ItemOnList),
          defaultValue: "No Descritption",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnDescriptionChanged
      );

        private static void OnDescriptionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnList;
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

        // constructor here
        public ItemOnList()
        {
            InitializeComponent();
            MyThumbnail.CacheDuration = TimeSpan.FromDays(60);
            isFavourite = false;

        }



        public static BindableProperty IsFavouriteCommandProperty = BindableProperty.Create(
          propertyName: "IsFavouriteCommand",
          returnType: typeof(ICommand),
          declaringType: typeof(ItemOnList),
          defaultValue: null,
          defaultBindingMode: BindingMode.TwoWay
      );



        public ICommand IsFavouriteCommand
        {
            get { return (ICommand)GetValue(IsFavouriteCommandProperty); }
            set { SetValue(IsFavouriteCommandProperty, value); }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MyFavourite.Source = isFavourite ? "redheart.png" : "heart.png";
            isFavourite = !isFavourite;

            if (IsFavouriteCommand.CanExecute(BindingContext))
            {
                IsFavouriteCommand.Execute(BindingContext);
            }
        }
    }
}
