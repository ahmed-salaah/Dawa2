using GHQ.Droid.Services;
using Service;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace GHQ.Droid.Services
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
