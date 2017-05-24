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
using EApp.Renderers;
using Xamarin.Forms;
using EApp.Droid.Renderer;
using EApp.CustomControl;
using System.Net;
using System.IO;

[assembly: ExportRenderer(typeof(ItemOnStoragePage), typeof(ItemOnStorageRenderer))]
namespace EApp.Droid.Renderer
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
                    //System.Diagnostics.Debug.WriteLine(t.ProgressPercentage);
                    System.Diagnostics.Debug.WriteLine("thaohandsome: "+t.ProgressPercentage);
                };
                //
                webClient.DownloadFileCompleted += (s, t) =>
                {

                    //progressBar.Visible = false;
                    //// any other code to process the file
                };
                //
                var destination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    "thao.mp3");

                webClient.DownloadFileAsync(new Uri("http://phim14.to/tamsinh/thachthien_3b_17p.flv"),
                    destination);
                
            };
        }
    }
}