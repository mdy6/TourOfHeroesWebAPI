using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesCore.Interfaces.Repository
{
    public interface IPaperRepository
    {
        Task<PaperDto[]> GetPapers();
        Task<PaperDto> GetPaperById(IdDto id);
        Task<IdDto> AddPapers(PaperDto paper);
        Task<IdDto> Update(PaperDto paperDao);
        Task DeleteByHeroId(IdDto idDao);
    }
}
