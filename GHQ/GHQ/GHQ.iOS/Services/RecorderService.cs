using Xamarin.Forms;
using GHQ.iOS.Services;
using System;
using System.IO;
using Service.Recorder;
using AVFoundation;
using Foundation;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FileHelper))]

namespace GHQ.iOS.Services
{
    public class RecorderService : IRecorderService
    {
        AVAudioRecorder recorder;
        NSError error;
        NSUrl url;
        NSDictionary settings;
        string path;
        public void Record()
        {
            var audioSession = AVAudioSession.SharedInstance();
            var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            if (err != null)
            {
                Console.WriteLine("audioSession: {0}", err);
                return;
            }
            err = audioSession.SetActive(true);
            if (err != null)
            {
                Console.WriteLine("audioSession: {0}", err);
                return;
            }

            //Declare string for application temp path and tack on the file extension
            string fileName = string.Format("Myfile{0}.wav", DateTime.Now.ToString("yyyyMMddHHmmss"));
            path = Path.Combine(Path.GetTempPath(), fileName);

            Console.WriteLine("Audio File Path: " + path);

            url = NSUrl.FromFilename(path);
            //set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
            NSObject[] values = new NSObject[]
            {
    NSNumber.FromFloat (44100.0f), //Sample Rate
    NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM), //AVFormat
    NSNumber.FromInt32 (2), //Channels
    NSNumber.FromInt32 (16), //PCMBitDepth
    NSNumber.FromBoolean (false), //IsBigEndianKey
    NSNumber.FromBoolean (false) //IsFloatKey
            };

            //Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
            NSObject[] keys = new NSObject[]
            {
    AVAudioSettings.AVSampleRateKey,
    AVAudioSettings.AVFormatIDKey,
    AVAudioSettings.AVNumberOfChannelsKey,
    AVAudioSettings.AVLinearPCMBitDepthKey,
    AVAudioSettings.AVLinearPCMIsBigEndianKey,
    AVAudioSettings.AVLinearPCMIsFloatKey
            };

            //Set Settings with the Values and Keys to create the NSDictionary
            settings = NSDictionary.FromObjectsAndKeys(values, keys);

            //Set recorder parameters
            recorder = AVAudioRecorder.Create(url, new AudioSettings(settings), out error);

            //Set Recorder to Prepare To Record
            recorder.PrepareToRecord();

            //Set Recorder to Prepare To Record
            recorder.PrepareToRecord();

            recorder.Record();

        }

        public void Play()
        {
            //recorder.p();
        }



        public async Task<byte[]> Stop()
        {
            recorder.Stop();
            using (var streamReader = new StreamReader(path))
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
    }
}