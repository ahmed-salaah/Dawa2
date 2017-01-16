using Xamarin.Forms;
using GHQ.iOS.Services;
using System;
using Service.FileHelper;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using Foundation;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.iOS.Services
{
    public class FileHelper : IFileHelper
    {
		public async Task<byte[]> GetByteArray(string filePath)
        {
			using (var streamReader = new StreamReader(filePath))
			{
				var bytes = default(byte[]);
				using (var memstream = new MemoryStream())
				{
					streamReader.BaseStream.CopyTo(memstream);
					bytes = memstream.ToArray();
					return bytes;
				}
			}
        }

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


        public async Task<string> SaveByteArrayToDisk(string filename, byte[] imageData, string folderName = "")
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(documents, filename);
            File.WriteAllBytes(filePath, imageData);
            return filePath;
        }

        public async Task<string> SaveImageToDisk(string filename, byte[] imageData, string folderName = "")
        {
           
			return await SaveByteArrayToDisk(filename, imageData, folderName);
        }
    }
}