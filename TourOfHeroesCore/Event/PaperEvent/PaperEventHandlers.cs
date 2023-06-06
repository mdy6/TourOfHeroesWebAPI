using TourOfHeroesCore.Event;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperEventHandlers : IEventHandler
    {
        private readonly IReaderNotifier<Paper> readerNotifier;

        public PaperEventHandlers(IReaderNotifier<Paper> readerNotifier)
        {
            this.readerNotifier = readerNotifier;
        }

        public Task HandleEvent(object ev)
        {
            if(ev is PaperPublishedEvent)
                return readerNotifier.NotifyReaders(new PaperNotification());
            if(ev is PaperUpdatedEvent)
                return readerNotifier.NotifyReaders(new PaperNotification());
            return Task.CompletedTask;
        }
    }
}