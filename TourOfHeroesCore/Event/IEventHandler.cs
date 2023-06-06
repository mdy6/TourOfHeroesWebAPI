namespace TourOfHeroesCore.Event
{
    public interface IEventHandler
    {
        Task HandleEvent(object ev);
    }

    public interface IEventHandler<T> where T: Event
    {

    }

    public class EventResult<T>
    {
        public T Result { get; set; }
    }
}
