using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesCore.Interfaces.Repository
{
    public interface IPaperRepository
    {
        Task<PaperDao[]> GetPapers();
        Task<PaperDao> GetPaperById(IdDao id);
        Task<IdDao> AddPapers(PaperDao paper);
        Task<IdDao> Update(PaperDao paperDao);
    }
}
