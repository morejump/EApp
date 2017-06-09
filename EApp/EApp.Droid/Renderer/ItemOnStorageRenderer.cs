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

        protected override void OnElementChanged(ElementChangedEventArgs<ItemOnStoragePage> e)
        {
            base.OnElementChanged(e);

            var destination = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    "music");
           
            WebClient webClient = new WebClient();

            // when clicking a download button
            e.NewElement.ClickedDownloadbtn += (se, lesson) =>
            {
                
                //downloading audio file
                webClient.DownloadFileAsync(new Uri("http://zmp3-mp3-s1-te-zmp3-fpthn-1.zadn.vn/11779c713b35d26b8b24/992888775050630550?key=OjXHFJiBmcGwZBc11U_3rQ&expires=1497004684"),
                   destination);
                //
                webClient.DownloadProgressChanged += (s, t) =>
                {
                    e.NewElement.PerCent = t.ProgressPercentage;
                };
                //
                webClient.DownloadFileCompleted += (s, t) =>
                {
                    e.NewElement.PathDownload = "";

                };
            };
        }
    }
}