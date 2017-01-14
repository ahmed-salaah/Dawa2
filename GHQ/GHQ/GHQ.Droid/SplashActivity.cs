using Android.App;
using Android.Content.PM;
using Android.OS;

namespace GHQ.Droid
{
    [Activity(Label = "Dawaya", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestedOrientation = ScreenOrientation.Portrait;
            StartActivity(typeof(MainActivity));
        }
    }
}