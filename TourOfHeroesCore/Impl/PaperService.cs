using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;
using TourOfHeroesCore.Model.Extensions;

namespace TourOfHeroesCore.Impl
{
    public partial class PaperService : IPaperService
    {
        private readonly IPaperRepository paperRepository;
        private readonly IEventBus eventBus;

        public PaperService(IPaperRepository paperRepository, IEventBus eventBus)
        {
            this.paperRepository = paperRepository;
            this.eventBus = eventBus;
        }

        public Task DeletePaperByHeroId(Id<int> heroId)
        {
            return paperRepository.DeleteByHeroId(new IdDto(heroId.Value));
        }

        public async Task<Paper> GetPaperById(Id<int> idInt)
        {
            var paper = await paperRepository.GetPaperById(idInt.ToDto());
            return paper.ToDomain();
        }

        public async Task<Paper[]> GetPapers()
        {
            return (await paperRepository.GetPapers()).Select(p => p.ToDomain()).ToArray();
        }

        public async Task<Paper[]> GetPapersByHeroId(Id<int> heroId)
        {
            return (await paperRepository.GetPapers()).Where(h => h.HeroId == heroId.Value).Select(p => p.ToDomain()).ToArray();
        }

        public async Task<IdInt> Publish(Paper paper)
        {
            var result = await paperRepository.AddPapers(paper.ToDto());
            await eventBus.Publish(new PaperPublishedEvent(new PaperEventArgs(paper)));

            return result.ToDomain();
        }

        public async Task<IdInt> UpdatePaper(Paper updatedPaper)
        {
            var paperDao = updatedPaper.ToDto();
            var updateId = await paperRepository.Update(paperDao);
            await eventBus.Publish(new PaperUpdatedEvent(new PaperEventArgs(updatedPaper)));
            return updateId.ToDomain();
        }
    }
}