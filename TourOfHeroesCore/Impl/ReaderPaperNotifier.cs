using System.Text.Json;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Impl
{
    public class ReaderPaperNotifier : IReaderNotifier<PaperEventArgs>
    {
        private readonly INotificationPool notifcationPool;

        public ReaderPaperNotifier(INotificationPool notifcationPool)
        {
            this.notifcationPool = notifcationPool;
        }

        public Task NotifyReaders(Notification<PaperEventArgs> notification)
        {
            notifcationPool.PoolNotification(notification);
            return Task.CompletedTask;
        }
    }
}