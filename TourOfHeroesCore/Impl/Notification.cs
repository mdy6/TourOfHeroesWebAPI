using System.Text.Json.Serialization;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Impl
{
    public abstract class Notification<T> : INotification
    {
        public Notification(T notificationArgs)
        {
            NotificationArgs = notificationArgs;
        }

        public T NotificationArgs { get; }

        public virtual string GetNotificationContent()
        {
            return System.Text.Json.JsonSerializer.Serialize(NotificationArgs);
        }
    }


}