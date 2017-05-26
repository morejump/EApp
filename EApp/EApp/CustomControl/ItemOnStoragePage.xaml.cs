using EApp.Models;
using EApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EApp.CustomControl
{
    public partial class ItemOnStoragePage : ContentView
    {
        public event EventHandler<Lesson> ClickedDownloadbtn;

        // this property is used to set value for  "text "+ % and a progress bar
        // in range 1 to 100
        // used int type
        public static BindableProperty PerCentProperty = BindableProperty.Create(
          propertyName: "PerCent",
          returnType: typeof(int),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: 0,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnPercentChanged
      );

        private static void OnPercentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyPercent.Text = view.PerCent.ToString() + "%";
                view.MyProgressBar.Progress = (double)view.PerCent / 100; // becuase a value of progress bar from 0 to 1
            }
        }

        public int PerCent
        {
            get { return (int)GetValue(PerCentProperty); }
            set { SetValue(PerCentProperty, value); }
        }
        // this property is used to set level of lessen including: easy, normal, hard
        public static BindableProperty LevelProperty = BindableProperty.Create(
          propertyName: "Level",
          returnType: typeof(int),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: -1,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: OnLevelChanged
      );

        private static void OnLevelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                if (view.Level == 0)
                {
                    view.MyLevel.BackgroundColor = Color.Blue;

                }
                if (view.Level == 1)
                {
                    view.MyLevel.BackgroundColor = Color.Purple;

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

        // this property is used to set title of a lesson
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

        // set an author
        public static BindableProperty AuthorProperty = BindableProperty.Create(
          propertyName: "Author",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "No Author",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnAuthorChanged
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


        // set a description
        public static BindableProperty DescriptionProperty = BindableProperty.Create(
          propertyName: "Description",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "No Description",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnDescriptionChanged
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


        // set how many user downloaded this lesson
        public static BindableProperty DownloadCountProperty = BindableProperty.Create(
          propertyName: "DownloadCount",
          returnType: typeof(int),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: 40,
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnDownloadChanged
      );

        private static void OnDownloadChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ItemOnStoragePage;
            if (view != null && newValue != null)
            {
                view.MyDownload.Text = view.DownloadCount.ToString();
            }
        }

        public int DownloadCount
        {
            get { return (int)GetValue(DownloadCountProperty); }
            set { SetValue(DownloadCountProperty, value); }
        }


        // set a thumbnail
        public static BindableProperty ThumbnailProperty = BindableProperty.Create(
          propertyName: "Thumbnail",
          returnType: typeof(string),
          declaringType: typeof(ItemOnStoragePage),
          defaultValue: "avatar.png",
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged: OnThumbnailChanged
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
        // constructor here
        public ItemOnStoragePage()
        {
            InitializeComponent();
        }

        // when user tap a download image
        // manuplating with download process here
        private void TapDownloadImage(object sender, EventArgs e)
        {
            ClickedDownloadbtn(this, (Lesson)BindingContext);
            MyImageDownload.IsVisible = false;
            MyProgressBar.IsVisible = true;
            MyPercent.IsVisible = true;


        }

    }
}
