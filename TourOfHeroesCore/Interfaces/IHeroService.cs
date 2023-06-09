using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Interfaces
{
    public interface IHeroService
    {
        Task<Id<int>> CreateOrUpdateHero(Hero hero);
        Task<Hero[]> GetHeroes();
        Task ComputeHeroLikeCount(Id<int> id);
        Task<Hero> GetHeroById(Id<int> id);
        Task DeleteHero(Id<int> id);
    }
}