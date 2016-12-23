using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Com.OneSignal;
using Plugin.Toasts;
using Service;
using System.Collections.Generic;
using Xamarin.Forms;

//LINK:https://documentation.onesignal.com/docs/xamarin-sdk-setup
//LINK: https://xamarinhelp.com/creating-splash-screen-xamarin-forms/
namespace GHQ.Droid
{
    [Activity(Label = "GHQ", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //Limit to only Portrait orientation
            RequestedOrientation = ScreenOrientation.Portrait;

            base.OnCreate(bundle);

            OneSignal.NotificationReceived exampleNotificationReceivedDelegate = delegate (OSNotification notification)
            {
                try
                {
                    System.Console.WriteLine("OneSignal Notification Received:\nMessage: {0}", notification.payload.body);
                    Dictionary<string, object> additionalData = notification.payload.additionalData;

                    if (additionalData.Count > 0)
                        System.Console.WriteLine("additionalData: {0}", additionalData);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            };

            OneSignal.NotificationOpened exampleNotificationOpenedDelegate = delegate (OSNotificationOpenedResult result)
            {
                try
                {
                    System.Console.WriteLine("OneSignal Notification opened:\nMessage: {0}", result.notification.payload.body);
                    Dictionary<string, object> additionalData = result.notification.payload.additionalData;
                    if (additionalData.Count > 0)
                        System.Console.WriteLine("additionalData: {0}", additionalData);


                    List<Dictionary<string, object>> actionButtons = result.notification.payload.actionButtons;
                    if (actionButtons.Count > 0)
                        System.Console.WriteLine("actionButtons: {0}", actionButtons);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            };
            //ServerKey:AIzaSyAmGUI2x2shf-5662zG36bal2brsQdVi-s

            // Initialize OneSignal
            OneSignal.StartInit("a244c5ac-e8e6-438d-ab32-ad25a30bc67b", "448292476527")
              .HandleNotificationReceived(exampleNotificationReceivedDelegate)
              .HandleNotificationOpened(exampleNotificationOpenedDelegate)
              .EndInit();

            OneSignal.IdsAvailable((playerID, pushToken) =>
            {
                try
                {

                    PushToken.DeviceId = playerID;

                    System.Console.WriteLine("Player ID: " + playerID);
                    if (pushToken != null)
                        System.Console.WriteLine("Push Token: " + pushToken);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            });


            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            DependencyService.Register<ToastNotification>();
            ToastNotification.Init(this, new PlatformOptions() { SmallIconDrawable = Android.Resource.Drawable.IcDialogInfo });

            LoadApplication(new App());
        }


        private async void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
        }
    }
}

