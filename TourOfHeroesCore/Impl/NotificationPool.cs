using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Impl
{
    public class NotificationPool : INotificationPool
    {
        private readonly Queue<INotification> _notificationQueue = new Queue<INotification>();

        public IEnumerable<string> GetNotifications()
        {
            while (_notificationQueue.Count > 0)
            {
                yield return _notificationQueue.Dequeue().GetNotificationContent();
            }
            

        }

        public void PoolNotification(INotification notification)
        {
            _notificationQueue.Enqueue(notification);
        }
    }
}