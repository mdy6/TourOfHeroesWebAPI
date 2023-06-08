using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroEventHandlers : IEventHandler
    {
        private readonly IHeroService _heroService;
        private readonly IReaderNotifier<HeroEventArgs> _notifier;

        public HeroEventHandlers(IHeroService heroService,IReaderNotifier<HeroEventArgs> notifier)
        {
            this._heroService = heroService;
            _notifier = notifier;
        }


        public Task HandleEvent(object ev)
        {
            Console.WriteLine($"Event received {ev.ToString()}");
            if (ev is PaperUpdatedEvent)
            {
                var updatedEvent = ev as PaperUpdatedEvent;
                return _heroService.ComputeHeroLikeCount(IdInt.Create(updatedEvent.EventArgs.HeroId));
            }
            if (ev is HeroPopularityIncreaseEvent)
            {
                var heroPopularityIncrease = ev as HeroPopularityIncreaseEvent;
                return _notifier.NotifyReaders(new HeroNotification(heroPopularityIncrease.EventArgs));
            }
            return Task.CompletedTask;
        }
    }
}
