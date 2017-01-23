using Foundation;
using UIKit;
using Xamarin.Forms;
using Plugin.Toasts;
using UserNotifications;
using MonoTouch.FacebookConnect;
using Service.Recorder;

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
		private const string FacebookAppId = "1215800281836993";
		private const string FacebookAppName = "Dawaya";
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();
		   
		
          
			DependencyService.Register<ToastNotification>();
            ToastNotification.Init();
            LoadApplication(new App());

			FBSettings.DefaultAppID = FacebookAppId;
			FBSettings.DefaultDisplayName = FacebookAppName;
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

            return base.FinishedLaunching(app, options);
        }
		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			//base.OpenUrl(application, url, sourceApplication, annotation);
			return FBSession.ActiveSession.HandleOpenURL(url);
		}

		public override void OnActivated(UIApplication application)
		{
			base.OnActivated(application);
			// We need to properly handle activation of the application with regards to SSO
			// (e.g., returning from iOS 6.0 authorization dialog or from fast app switching).
			FBSession.ActiveSession.HandleDidBecomeActive();
		}
		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, System.Action<UIBackgroundFetchResult> completionHandler)
		{
			base.DidReceiveRemoteNotification(application, userInfo, completionHandler);
		}
		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			string soundPath = notification.SoundName;
			DependencyService.Get<IRecorderService>().Play(soundPath);
			//base.ReceivedLocalNotification(application, notification);

		}
		public override void HandleAction(UIApplication application, string actionIdentifier, UILocalNotification localNotification, System.Action completionHandler)
		{
			base.HandleAction(application, actionIdentifier, localNotification, completionHandler);
		}
    }
}
