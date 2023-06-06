using System.Text.Json;

namespace TourOfHeroesCore.Event
{
    public class Event<T> : Event
    {
        public T EventArgs { get; }

        public Event(T obj) : base()
        {
            this.EventArgs = obj;
        }
    }

    public abstract class Event
    {
        public DateTimeOffset EventCreatedDate { get; }

        protected Event()
        {
            EventCreatedDate = DateTimeOffset.UtcNow;
        }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, JsonSerializerOptions.Default);
        }
    }

}