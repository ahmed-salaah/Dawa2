using GHQ.UWP.Services;
using Service.FileHelper;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.UWP.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

        public async Task<string> SaveByteArrayToDisk(string filename, byte[] imageData, string folderName = "")
        {
            StorageFolder local = null;
            try
            {
                local = await ApplicationData.Current.LocalFolder.GetFolderAsync(folderName);
            }
            catch
            {
            }

            if (local == null)
            {
                local = await ApplicationData.Current.LocalFolder.CreateFolderAsync(folderName);

            }
            var storageFile = await local.CreateFileAsync(filename);
            await FileIO.WriteBytesAsync(storageFile, imageData);
            return storageFile.Path;
        }
    }
}

