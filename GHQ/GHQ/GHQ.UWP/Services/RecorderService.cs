using GHQ.UWP.Services;
using Service.Recorder;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(RecorderService))]

namespace GHQ.UWP.Services
{
    public class RecorderService : IRecorderService
    {
        MediaCapture capture;
        InMemoryRandomAccessStream buffer;
        bool record;
        string filename;
        StorageFile storageFile;
        string audioFile = ".MP3";
        private async Task<bool> RecordProcess()
        {
            if (buffer != null)
            {
                buffer.Dispose();
            }
            buffer = new InMemoryRandomAccessStream();
            if (capture != null)
            {
                capture.Dispose();
            }
            try
            {
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Audio
                };
                capture = new MediaCapture();
                await capture.InitializeAsync(settings);
                capture.RecordLimitationExceeded += (MediaCapture sender) =>
                {
                    //Stop  
                    // await capture.StopRecordAsync();  
                    record = false;
                    throw new Exception("Record Limitation Exceeded ");
                };
                capture.Failed += (MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs) =>
                {
                    record = false;
                    throw new Exception(string.Format("Code: {0}. {1}", errorEventArgs.Code, errorEventArgs.Message));
                };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(UnauthorizedAccessException))
                {
                    throw ex.InnerException;
                }
                throw;
            }
            return true;
        }

        public async void Record()
        {
            if (record)
            {
                //already recored process  
            }
            else
            {
                await RecordProcess();
                await capture.StartRecordToStreamAsync(MediaEncodingProfile.CreateMp3(AudioEncodingQuality.Auto), buffer);
                if (record)
                {
                    throw new InvalidOperationException();
                }
                record = true;
            }
        }

        public async void Play(string path)
        {
            MediaElement playback = new MediaElement();
            IRandomAccessStream audio = buffer.CloneStream();

            if (audio == null)
                throw new ArgumentNullException("buffer");
            StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            if (!string.IsNullOrEmpty(filename))
            {
                StorageFile original = await storageFolder.GetFileAsync(filename);
                await original.DeleteAsync();
            }

            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
             {
                 storageFile = await storageFolder.CreateFileAsync(audioFile, CreationCollisionOption.GenerateUniqueName);

                 filename = storageFile.Name;
                 using (IRandomAccessStream fileStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                 {
                     await RandomAccessStream.CopyAndCloseAsync(audio.GetInputStreamAt(0), fileStream.GetOutputStreamAt(0));
                     await audio.FlushAsync();
                     audio.Dispose();
                 }
                 IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read);
                 playback.SetSource(stream, storageFile.FileType);
                 playback.Play();
             });
        }

        public async Task<byte[]> Stop()
        {
            await capture.StopRecordAsync();
            record = false;


            byte[] result;
            using (Stream stream = await storageFile.OpenStreamForReadAsync())
            {
                using (var memoryStream = new MemoryStream())
                {

                    stream.CopyTo(memoryStream);
                    result = memoryStream.ToArray();
                    return result;
                }
            }
        }
    }
}

