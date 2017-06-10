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

            WebClient webClient = new WebClient();

            string PathAudio = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    e.NewElement.ID.ToString());

            e.NewElement.PathAudio = PathAudio;

            // when clicking a download button
            e.NewElement.ClickedDownloadbtn += (se, lesson) =>
            {

                //downloading audio file to local with link download
                webClient.DownloadFileAsync(new Uri(e.NewElement.LinkDownload),
                   e.NewElement.PathAudio);
                //
                webClient.DownloadProgressChanged += (s, t) =>
                {
                    e.NewElement.PerCent = t.ProgressPercentage;
                };
                //
                webClient.DownloadFileCompleted += (s, t) =>
                {
                    e.NewElement.IsVisibleProgressBar = false;

                };
            };
        }
    }
}