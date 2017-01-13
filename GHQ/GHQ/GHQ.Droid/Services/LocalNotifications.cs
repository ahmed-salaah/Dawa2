using GHQ.Droid.Services;
using Service.FileHelper;
using System;
using System.IO;
using Xamarin.Forms;
using Service.ILocalNotifications;
using Android.OS;
using Android.Content;
using Android.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Android.Support.V4.App;
[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.Droid.Services
{
    public class LocalNotifications : ILocalNotifications

    {
		private static Context Context
		{
			get { return Xamarin.Forms.Forms.Context ?? Android.App.Application.Context; }
		}
  private static readonly int ButtonClickNotificationId = 1000;
		public void showNotification(string title, string body, DateTime date, string sound)
		{
			// Pass the current button press count value to the next activity:
			Bundle valuesForActivity = new Bundle();
			valuesForActivity.PutInt("count", 1);

			// When the user clicks the notification, SecondActivity will start up.
			Intent resultIntent = new Intent(this, typeof(SecondActivity));

			// Pass some values to SecondActivity:
			resultIntent.PutExtras(valuesForActivity);

			// Construct a back stack for cross-task navigation:
			TaskStackBuilder stackBuilder = TaskStackBuilder.Create(Context);
			stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SecondActivity)));
			stackBuilder.AddNextIntent(resultIntent);

			// Create the PendingIntent with the back stack:            
			PendingIntent resultPendingIntent =
				stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

			// Build the notification:
			NotificationCompat.Builder builder = new NotificationCompat.Builder(Context)
				.SetAutoCancel(true)                    // Dismiss from the notif. area when clicked
				.SetContentIntent(resultPendingIntent)  // Start 2nd activity when the intent is clicked.
				.SetContentTitle(title)      // Set its title
				.SetNumber(1)                       // Display the count in the Content Info
				.SetContentText(body); // The message to display.

			// Finally, publish the notification:
			NotificationManager notificationManager =
				(NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify(ButtonClickNotificationId, builder.Build());

			// Increment the button press count:

		}
	}
}
