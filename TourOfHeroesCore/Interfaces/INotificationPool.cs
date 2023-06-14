namespace TourOfHeroesCore.Interfaces
{
    public interface INotificationPool
    {
        IEnumerable<string> GetNotifications();
        void PoolNotification(INotification notification); 
    }
}