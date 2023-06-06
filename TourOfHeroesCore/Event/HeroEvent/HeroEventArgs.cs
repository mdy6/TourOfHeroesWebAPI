using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Event.HeroEvent
{
    public class HeroEventArgs
    {
        public int Id { get; set; }

        public HeroEventArgs(int id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public int Popularity { get; set; }
        public HeroEventArgs(Hero hero)
        {
            Id = hero.Id.Value;
            Name = hero.Name;
            Popularity = hero.Popularity.Value;
        }
    }
}
