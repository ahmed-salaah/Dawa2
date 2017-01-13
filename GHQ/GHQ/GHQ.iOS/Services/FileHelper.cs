using Xamarin.Forms;
using GHQ.iOS.Services;
using System;
using Service.FileHelper;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}