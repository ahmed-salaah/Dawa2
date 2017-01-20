using Xamarin.Forms;
using GHQ.Droid.Services;
using System;
using Service.ILocalNotifications;
using Enums;
using Android.Content;
using Android.App;
using Android.OS;
using GHQ.Droid.Receivers;

[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.Droid.Services
{
    public class LocalNotifications : ILocalNotifications
    {
		public void ShowNotification(string title, string body, DateTime startDate, DateTime endDate, string soundPath, ReminderRepeatOptions reminderRepeatOptions)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", body);
            alarmIntent.PutExtra("title", title);
            alarmIntent.PutExtra("soundPath", soundPath);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

            //TODO: For demo set after 5 seconds.
			alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + startDate.Millisecond, pendingIntent);

            //alarmManager.SetRepeating(AlarmType.ElapsedRealtime,;

        }

	
	}
}