using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnStoragePage : ContentView
    {


        public static BindableProperty PerCentProperty = BindableProperty.Create(
          propertyName: "PerCent",
          returnType: typeof(double),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: 60.0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnPercentChanged
      );

        private static void OnPercentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyPercent.Text = view.PerCent.ToString();
            }
        }

        public double PerCent
        {
            get { return (double)GetValue(PerCentProperty); }
            set { SetValue(PerCentProperty, value); }
        }



        public static BindableProperty CompletedDownloadProperty = BindableProperty.Create(
          propertyName: "CompletedDownload",
          returnType: typeof(double),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: 0.7,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnCompletedDownloadChanged
      );

        private static void OnCompletedDownloadChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyProgressBar.Progress = view.CompletedDownload;
            }
        }

        public double CompletedDownload
        {
            get { return (double)GetValue(CompletedDownloadProperty); }
            set { SetValue(CompletedDownloadProperty, value); }
        }


        public static BindableProperty TitleProperty = BindableProperty.Create(
          propertyName: "Title",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "No Title",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnTitleChanged
      );

        private static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if(view!=null && newValue != null)
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
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "No Author",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnAuthorChanged
      );

        private static void OnAuthorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyAuthor.Text = view.Author;
            }
        }

        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }



        public static BindableProperty DescriptionProperty = BindableProperty.Create(
          propertyName: "Description",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "No Description",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnDescriptionChanged
      );

        private static void OnDescriptionChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var view = bindable as ItemOnStoragePage;
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



        public static BindableProperty DownloadProperty = BindableProperty.Create(
          propertyName: "Download",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "0",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnDownloadChanged
      );

        private static void OnDownloadChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyDownload.Text = view.Download;
            }
        }

        public string Download
        {
            get { return (string)GetValue(DownloadProperty); }
            set { SetValue(DownloadProperty, value); }
        }



        public static BindableProperty ThumbnailProperty = BindableProperty.Create(
          propertyName: "Thumbnail",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "avatar.png",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged:OnThumbnailChanged
      );

        private static void OnThumbnailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
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

        public ItemOnStoragePage()
        {
            InitializeComponent();
        }

        private void TapDownloadImage(object sender, EventArgs e)
        {
            // do something here :))
            MyImageDownload.IsVisible = false;
            MyProgressBar.IsVisible = true;
            MyTotal.IsVisible = true;

        }
    }
}
