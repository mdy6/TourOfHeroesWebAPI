using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesCore.Interfaces.Repository
{
    public interface IPaperRepository
    {
        Task<PaperDao[]> GetPapers();
        Task<IdDao> AddPapers(PaperDao paper);
    }
}
