using GHQ.Logic.Models.Data.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Notification
{
    public interface INotificationService
    {
        NotificationData SelectedNotification { get; set; }

        Task<List<NotificationData>> GetNotificationsAsync();

        Task<bool> RegisterUserDevice(string deviceId);

        Task<bool> UnRegisterUserDevice(string deviceId);
    }
}
