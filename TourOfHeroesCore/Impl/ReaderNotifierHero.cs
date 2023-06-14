using System.Text.Json;
using TourOfHeroesCore.Event.HeroEvent;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Impl
{
    public class ReaderNotifierHero : IReaderNotifier<HeroEventArgs>
    {
        private readonly INotificationPool notifcationPool;

        public ReaderNotifierHero(INotificationPool notifcationPool)
        {
            this.notifcationPool = notifcationPool;
        }
        public Task NotifyReaders(Notification<HeroEventArgs> notification)
        {
            notifcationPool.PoolNotification(notification);
            return Task.CompletedTask;
        }
    }
}