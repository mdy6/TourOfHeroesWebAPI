using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Interfaces
{
    public interface IPaperService
    {
        Task<Paper> GetPaperById(Id<int> idInt);
        Task<Paper[]> GetPapersByHeroId(Id<int> heroId);
        Task<IdInt> Publish(Paper paper);
        Task<IdInt> UpdatePaper(Paper existingPaper);
        Task DeletePaperByHeroId(Id<int> heroId);
    }
}