using Android.Content;
using GHQ.Droid.Services;
using Service.FileHelper;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        public async Task<string> SaveByteArrayToDisk(string filename, byte[] imageData, string folderName = "")
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
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(filePath)));
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
