using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.HeroEvent;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperEventHandlers : IEventHandler
    {
        private readonly IReaderNotifier<PaperEventArgs> readerNotifier;
        private readonly IPaperService paperService;

        public PaperEventHandlers(IReaderNotifier<PaperEventArgs> readerNotifier, IPaperService paperService)
        {
            this.readerNotifier = readerNotifier;
            this.paperService = paperService;
        }

        public Task HandleEvent(object ev)
        {
            if(ev is PaperPublishedEvent)
            {
                var publishedEvent = ev as PaperPublishedEvent;
                return readerNotifier.NotifyReaders(new PaperNotification(publishedEvent?.EventArgs, "pusblished"));
            }
            if(ev is PaperUpdatedEvent)
            {
                var updatedEvent = ev as PaperUpdatedEvent;
                return readerNotifier.NotifyReaders(new PaperNotification(updatedEvent?.EventArgs, "updated"));
            }
            if(ev is HeroDeletedEvent)
            {
                var deletedHeroEvent = ev as HeroDeletedEvent;
                paperService.DeletePaperByHeroId(IdInt.Create(deletedHeroEvent.EventArgs.Id));
            }
            return Task.CompletedTask;
        }
    }
}