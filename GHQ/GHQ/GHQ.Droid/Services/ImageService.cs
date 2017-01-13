using Android.Content;
using Android.Net;
using GHQ.Droid.Services;
using Java.IO;
using Service.Media;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]

namespace GHQ.Droid.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SavePictureToDisk(string filename, byte[] imageData)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
            string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
                return filePath;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
                return "";
            }
        }
    }
}
