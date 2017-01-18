using Android.Media;
using GHQ.Droid.Services;
using Service.Recorder;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
[assembly: Dependency(typeof(RecorderService))]

namespace GHQ.Droid.Services
{
    public class RecorderService : IRecorderService
    {
        string path = "/sdcard/test.3gpp";
        MediaRecorder _recorder;
        MediaPlayer _player;

        public RecorderService()
        {
            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
            };
        }
        public void Record()
        {
            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            _recorder.SetOutputFile(path);
            _recorder.Prepare();
            _recorder.Start();
        }

        public void Play(string Path)
        {

            _player.SetDataSource(path);
            _player.Prepare();
            _player.Start();
        }

        public async Task<byte[]> Stop()
        {
            _recorder.Stop();
            _recorder.Reset();

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