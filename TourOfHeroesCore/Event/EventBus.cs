using System;

namespace TourOfHeroesCore.Event
{
    public class EventBus : IEventBus
    {
        private readonly Queue<Event> queue = new Queue<Event>();
        private readonly List<IEventHandler> eventHandlers = new List<IEventHandler>();

        public async Task Publish(Event evToPub)
        {
            queue.Enqueue(evToPub);
            Console.WriteLine($"Event publish {evToPub.ToString()}");
            if(eventHandlers.Count== 0)
                Console.WriteLine("no one subscribed");
            foreach (var e in eventHandlers)
            {
                Console.WriteLine($"Event publish {evToPub.ToString()} to {e.GetType().FullName} ");
                await e.HandleEvent(evToPub);
            }
            return;
        }

        public Task Subscribe(IEventHandler eventHandler)
        {
            eventHandlers.Add(eventHandler);
            Console.WriteLine($"{eventHandler.GetType().FullName} subscribed to bus");
            return Task.CompletedTask;
        }

        public Task Unsubscribe(IEventHandler eventHandler)
        {
            eventHandlers.Where(e => e.GetType() == eventHandler.GetType()).ToList().ForEach(e => eventHandlers.Remove(e));
            return Task.CompletedTask;
        }
    }

}