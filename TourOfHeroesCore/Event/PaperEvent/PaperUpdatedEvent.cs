namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperUpdatedEvent : Event<PaperEventArgs>
    {
        public PaperUpdatedEvent(PaperEventArgs obj) : base(obj)
        {
        }
    }
}
