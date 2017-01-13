using GHQ.UWP.Services;
using Service.Media;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using System;
[assembly: Dependency(typeof(ImageService))]

namespace GHQ.UWP.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SavePictureToDisk(string filename, byte[] imageData)
        {
            StorageFolder local = null;
            try
            {
                local = await ApplicationData.Current.LocalFolder.GetFolderAsync("MedicineImages");
            }
            catch
            {
            }

            if (local == null)
            {
                local = await ApplicationData.Current.LocalFolder.CreateFolderAsync("MedicineImages");

            }
            var storageFile = await local.CreateFileAsync(filename);
            await FileIO.WriteBytesAsync(storageFile, imageData);
            return storageFile.Path;
        }
    }
}
