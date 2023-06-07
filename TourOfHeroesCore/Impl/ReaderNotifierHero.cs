using System.Text.Json;
using TourOfHeroesCore.Event.HeroEvent;
using TourOfHeroesCore.Impl;

namespace TourOfHeroesCore.Interfaces
{
    public class ReaderNotifierHero : IReaderNotifier<HeroEventArgs>
    {
        public Task NotifyReaders(Notification<HeroEventArgs> notification)
        {
            Console.WriteLine(JsonSerializer.Serialize(notification.NotificationArgs));
            return Task.CompletedTask;
        }
    }
}