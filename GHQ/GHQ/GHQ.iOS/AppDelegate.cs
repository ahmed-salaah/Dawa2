using Foundation;
using UIKit;
using Xamarin.Forms;
using Plugin.Toasts;
using UserNotifications;
using Com.OneSignal;
using System.Collections.Generic;

namespace GHQ.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();

            DependencyService.Register<ToastNotification>();
            ToastNotification.Init();
            LoadApplication(new App());


            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Request Permissions
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (granted, error) =>
                {
                    // Do something if needed
                });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                 UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                    );

                app.RegisterUserNotificationSettings(notificationSettings);
            }

            OneSignal.NotificationReceived exampleNotificationReceivedDelegate = delegate (OSNotification notification)
            {
                try
                {
                    System.Console.WriteLine("OneSignal Notification Received: {0}", notification.payload.body);
                    Dictionary<string, object> additionalData = notification.payload.additionalData;

                    if (additionalData.Count > 0)
                        System.Console.WriteLine("additionalData: {0}", additionalData);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            };

            // Notification Opened Delegate
            OneSignal.NotificationOpened exampleNotificationOpenedDelegate = delegate (OSNotificationOpenedResult result)
            {
                try
                {
                    System.Console.WriteLine("OneSignal Notification opened: {0}", result.notification.payload.body);

                    Dictionary<string, object> additionalData = result.notification.payload.additionalData;
                    List<Dictionary<string, object>> actionButtons = result.notification.payload.actionButtons;

                    if (additionalData.Count > 0)
                        System.Console.WriteLine("additionalData: {0}", additionalData);

                    if (actionButtons.Count > 0)
                        System.Console.WriteLine("actionButtons: {0}", actionButtons);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            };

            // Initialize OneSignal
            OneSignal.StartInit("4a698011-683a-4476-9882-f3a3ea948523")
              .HandleNotificationReceived(exampleNotificationReceivedDelegate)
              .HandleNotificationOpened(exampleNotificationOpenedDelegate)
              .EndInit();

            return base.FinishedLaunching(app, options);
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // Local Notifications are received here
        }
    }
}
