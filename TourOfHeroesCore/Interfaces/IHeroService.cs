using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Interfaces
{
    public interface IHeroService
    {
        Task ComputeHeroLikeCount(Id<int> id);
        Task<Hero> GetHeroById(Id<int> id);
    }
}