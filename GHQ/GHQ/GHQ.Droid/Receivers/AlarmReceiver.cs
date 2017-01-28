using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Graphics;
using Xamarin.Forms;
using Service.Recorder;
using System;
using Enums;
using Microsoft.Practices.ServiceLocation;
using GHQ.Logic.Service.Lookup;

namespace GHQ.Droid.Receivers
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        //https://nnish.com/tag/xamarin/
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");
            var medicin = intent.GetStringExtra("medicinId");
            var medicinId = int.Parse(medicin);
            var soundPath = intent.GetStringExtra("soundPath");
            DateTime endDate = DateTime.Parse(intent.GetStringExtra("endDate"));
            var reminderId = intent.GetStringExtra("reminderOptionId");
            var reminder = int.Parse(reminderId);
            ReminderRepeatOptions reminderRepeatOptions = (ReminderRepeatOptions)reminder;
            var notIntent = new Intent(context, typeof(MainActivity));
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManagerCompat.From(context);

            var style = new NotificationCompat.BigTextStyle();
            style.BigText(message);

            int resourceId = Resource.Drawable.abc_tab_indicator_mtrl_alpha;


            var wearableExtender = new NotificationCompat.WearableExtender().SetBackground(BitmapFactory.DecodeResource(context.Resources, resourceId));

            //Generate a notification with just short text and small icon
            var builder = new NotificationCompat.Builder(context)
                            .SetContentIntent(contentIntent)
                            .SetSmallIcon(Resource.Drawable.logo)
                            .SetContentTitle(title)
                            .SetContentText(message)
                            .SetStyle(style)
                            .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                            .SetAutoCancel(true)
                            .Extend(wearableExtender);

            var notification = builder.Build();
            manager.Notify(0, notification);

            var medecinService = ServiceLocator.Current.GetInstance<IMedicineService>();
            medecinService.UpdateNextMedicin(medicinId, reminderRepeatOptions);

            DependencyService.Get<IRecorderService>().Play(soundPath);
        }
    }
}