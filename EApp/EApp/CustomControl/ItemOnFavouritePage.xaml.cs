using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnFavouritePage : ContentView
    {
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
               view.MyAuthor.Text  = "by " + view.Author;
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
        public ItemOnFavouritePage()
        {
            InitializeComponent();
        }
    }
}
