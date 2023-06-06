using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;

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

    public class PaperNotification : Notification<PaperEventArgs>
    {
        public PaperNotification(PaperEventArgs notificationArgs) : base(notificationArgs)
        {
        }
    }
}