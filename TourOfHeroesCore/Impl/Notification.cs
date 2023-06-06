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

        public virtual Task Notify()
        {
            return Task.CompletedTask;
        }
    }
}