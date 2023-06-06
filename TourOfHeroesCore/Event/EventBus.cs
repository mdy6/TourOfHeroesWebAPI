namespace TourOfHeroesCore.Event
{
    public class EventBus : IEventBus
    {
        private readonly Queue<Event> queue = new Queue<Event>();
        private readonly List<IEventHandler> eventHandlers = new List<IEventHandler>();

        public Task Publish(Event evToPub)
        {
            queue.Enqueue(evToPub);
            foreach(var e in eventHandlers)
                e.HandleEvent(evToPub);
            return Task.CompletedTask;
        }

        public Task Subscribe(IEventHandler eventHandler)
        {
            eventHandlers.Add(eventHandler);
            return Task.CompletedTask;
        }

        public Task Unsubscribe(IEventHandler eventHandler)
        {
            eventHandlers.Where(e => e.GetType() == eventHandler.GetType()).ToList().ForEach(e => eventHandlers.Remove(e));
            return Task.CompletedTask;
        }
    }

}