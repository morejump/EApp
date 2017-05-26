using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using EApp.CustomControl;
using EApp.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
using System.Net;
using System.IO;

[assembly: ExportRenderer(typeof(ItemOnStoragePage), typeof(ItemOnStorageRenderer))]


// IOS Renderer
namespace EApp.iOS.Renderer
{
    public class ItemOnStorageRenderer : VisualElementRenderer<ItemOnStoragePage>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ItemOnStoragePage> e)
        {
            base.OnElementChanged(e);
            // when clicking a download button
            e.NewElement.ClickedDownloadbtn += (se, arg) =>
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
                //
                webClient.DownloadProgressChanged += (s, t) =>
                {
                    e.NewElement.PerCent = t.ProgressPercentage;
                };
                //
                webClient.DownloadFileCompleted += (s, t) =>
                {

                };
                //
                var destination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    "th?o ð?p trai");
                System.Diagnostics.Debug.WriteLine("====" + destination);
                webClient.DownloadFileAsync(new Uri("http://phim14.to/tamsinh/thachthien_3b_17p.flv"),
                    destination);

            };
        }
    }

}