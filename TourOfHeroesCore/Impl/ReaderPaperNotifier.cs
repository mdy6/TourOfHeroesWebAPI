using System.Text.Json;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Impl
{
    public class ReaderPaperNotifier : IReaderNotifier<PaperEventArgs>
    {
        public Task NotifyReaders(Notification<PaperEventArgs> notification)
        {
            Console.WriteLine(JsonSerializer.Serialize(notification.NotificationArgs));
            return Task.CompletedTask;
        }
    }
}