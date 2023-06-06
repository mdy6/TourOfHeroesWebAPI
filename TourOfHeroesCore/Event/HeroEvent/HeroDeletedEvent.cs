using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroDeletedEvent : Event<HeroEventArgs>
    {
        public HeroDeletedEvent(Hero hero): base(new HeroEventArgs(hero))
        {
            
        }
        public HeroDeletedEvent(HeroEventArgs obj) : base(obj)
        {
        }
    }
}
