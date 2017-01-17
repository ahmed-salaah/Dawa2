using Xamarin.Forms;
using GHQ.iOS.Services;
using System;
using Service.ILocalNotifications;
using System.IO;
using UIKit;

[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.iOS.Services
{
    public class LocalNotifications : ILocalNotifications
    {
  
		public void showNotification(string title, string body, DateTime date, string sound)
		{
			// create the notification
			var notification = new UILocalNotification();

			// set the fire date (the date time in which it will fire)
			notification.FireDate = (Foundation.NSDate)date;

			// configure the alert

			notification.AlertAction = title;
			notification.AlertBody = body;

			// modify the badge
			notification.ApplicationIconBadgeNumber = 1;

			// set the sound to be the default sound
			notification.so

			// schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification(notification);
		}
	}
}