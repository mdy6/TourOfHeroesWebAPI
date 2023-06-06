using TourOfHeroesCore.Event;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperEventHandlers : IEventHandler
    {
        private readonly IReaderNotifier<PaperEventArgs> readerNotifier;

        public PaperEventHandlers(IReaderNotifier<PaperEventArgs> readerNotifier)
        {
            this.readerNotifier = readerNotifier;
        }

        public Task HandleEvent(object ev)
        {
            if(ev is PaperPublishedEvent)
            {
                var publishedEvent = ev as PaperPublishedEvent;
                return readerNotifier.NotifyReaders(new PaperNotification(publishedEvent?.EventArgs));
            }
            if(ev is PaperUpdatedEvent)
            {
                var updatedEvent = ev as PaperUpdatedEvent;
                return readerNotifier.NotifyReaders(new PaperNotification(updatedEvent?.EventArgs));
            }
            return Task.CompletedTask;
        }
    }
}