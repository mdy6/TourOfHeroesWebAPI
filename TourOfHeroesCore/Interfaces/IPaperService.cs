using TourOfHeroesCore.Model;

namespace TourOfHeroesCore.Interfaces
{
    public interface IPaperService
    {
        Task<Paper> GetPaperById(Id<int> idInt);
        Task<IdInt> Publish(Paper paper);
        Task<IdInt> UpdatePaper(Paper existingPaper);
    }
}