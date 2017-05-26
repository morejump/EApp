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

// Android Renderer
[assembly: ExportRenderer(typeof(ItemOnStoragePage), typeof(ItemOnStorageRenderer))]
namespace EApp.Droid.Renderer
{
    public class ItemOnStorageRenderer : VisualElementRenderer<ItemOnStoragePage>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ItemOnStoragePage> e)
        {
            base.OnElementChanged(e);
            // getting a path of folder this application
            var destination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    "music");
            System.Diagnostics.Debug.Write("thaohandsome"+destination);
            // instantiating webclient
            WebClient webClient = new WebClient();

            // when clicking a download button
            e.NewElement.ClickedDownloadbtn += (se, lesson) =>
            {

                webClient.DownloadFileAsync(new Uri("http://zmp3-mp3-s1-te-zmp3-fpthn-2.zadn.vn/5b345109ca4d23137a5c/6595008708557956551?key=F_gZCdKaHkANVdHDl1cs1Q&expires=1495691626"),
                   destination);
                //
                webClient.DownloadProgressChanged += (s, t) =>
                {
                    e.NewElement.PerCent = t.ProgressPercentage;
                };
                //
                webClient.DownloadFileCompleted += (s, t) =>
                {
                    // dó something later
                };
            };
        }
    }
}