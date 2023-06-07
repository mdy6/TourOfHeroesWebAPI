using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroEventHandlers : IEventHandler
    {
        private readonly IReaderNotifier<HeroEventArgs> _notifier;

        public HeroEventHandlers(IReaderNotifier<HeroEventArgs> notifier)
        {
            _notifier = notifier;
        }


        public Task HandleEvent(object ev)
        {
            Console.WriteLine($"Event received {ev.ToString()}");
            if (ev is HeroPopularityIncreaseEvent)
            {
                var heroPopularityIncrease = ev as HeroPopularityIncreaseEvent;
                return _notifier.NotifyReaders(new HeroNotification(heroPopularityIncrease.EventArgs));
            }
            return Task.CompletedTask;
        }
    }
}
