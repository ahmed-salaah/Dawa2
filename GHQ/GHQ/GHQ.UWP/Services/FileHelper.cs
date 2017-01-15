using GHQ.UWP.Services;
using Service.FileHelper;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using System;
using Windows.Storage.Streams;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.UWP.Services
{
    public class FileHelper : IFileHelper
    {
        public static async Task<byte[]> GetBytesAsync(StorageFile file)
        {
            byte[] fileBytes = null;
            if (file == null) return null;
            using (var stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }
            return fileBytes;
        }

        public async Task<byte[]> GetByteArray(string filePath)
        {
            var file = await StorageFile.GetFileFromPathAsync(filePath);
            return await GetBytesAsync(file);
        }

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

        public Task<string> SaveImageToDisk(string filename, byte[] imageData, string folderName = "")
        {
            return SaveByteArrayToDisk(filename, imageData, folderName);
        }
    }
}

