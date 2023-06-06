using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.HeroEvent
{

    public class HeroPopularityIncreaseEvent : Event<HeroEventArgs>
    {
        public HeroPopularityIncreaseEvent(Hero hero): base(new HeroEventArgs(hero))
        {
            
        }
        public HeroPopularityIncreaseEvent(HeroEventArgs obj) : base(obj)
        {
        }
    }
}
