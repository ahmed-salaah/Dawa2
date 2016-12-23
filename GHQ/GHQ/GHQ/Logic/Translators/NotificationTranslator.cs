using System.Collections.Generic;
using GHQ.Logic.Models.Response;
using Exceptions;
using Newtonsoft.Json;
using GHQ.Logic.Models.Data.Notification;

namespace GHQ
{
    public class NotificationTranslator
    {
        static public List<NotificationData> Translate(List<NotificationResponse> response)
        {
            try
            {
                var translatedNotifications = new List<NotificationData>();

                foreach (var item in response)
                {
                    NotificationData notification = new NotificationData();
                    notification.Description = item.Message;
                    notification.Date = item.CreatedDate;
                    translatedNotifications.Add(notification);
                }

                return translatedNotifications;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translating NotificationData", JsonConvert.SerializeObject(response));
            }
        }
    }
}
