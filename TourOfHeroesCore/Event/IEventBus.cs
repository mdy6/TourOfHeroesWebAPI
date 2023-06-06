namespace TourOfHeroesCore.Event
{
    public interface IEventBus
    {
        Task Subscribe(IEventHandler eventHandler);
        Task Unsubscribe(IEventHandler eventHandler);
        Task Publish(Event evToPub);
    }

}