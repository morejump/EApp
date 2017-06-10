using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using EApp.Droid.Renderer;
using EApp.CustomControl;
using System.Net;
using System.IO;
using Realms;
using System.Threading.Tasks;
using PCLStorage;

// Android Renderer
[assembly: ExportRenderer(typeof(ItemOnStoragePage), typeof(ItemOnStorageRenderer))]
namespace EApp.Droid.Renderer
{
    public class ItemOnStorageRenderer : VisualElementRenderer<ItemOnStoragePage>
    {
        public ItemOnStorageRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ItemOnStoragePage> e)
        {
            base.OnElementChanged(e);
            //e.NewElement.PathAudio = PathAudio;
            // when clicking a download button
            e.NewElement.ClickedDownloadbtn += (se, lesson) =>
            {
                WebClient webClient = new WebClient();

                string PathAudio = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        lesson.ID.ToString());
                System.Diagnostics.Debug.WriteLine("thaohandsome"+lesson.Author);
                lesson.PathAudio = PathAudio;
                //downloading audio file to local with link download
                webClient.DownloadFileAsync(new Uri(lesson.LinkDownload),
                   lesson.PathAudio);
                //
                webClient.DownloadProgressChanged += (s, t) =>
                {
                    e.NewElement.PerCent = t.ProgressPercentage;
                    if (t.ProgressPercentage == 100)
                    {
                        e.NewElement.IsVisibleProgressBar = false;

                    }
                };
                // checking this event later
                //webClient.DownloadFileCompleted += (s, t) =>
                //{
                //    e.NewElement.IsVisibleProgressBar = false;

                //};
            };
        }
    }
}