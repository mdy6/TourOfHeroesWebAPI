using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
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

        public async Task<Paper> GetPaperById(Id<int> idInt)
        {
            var paper = await paperRepository.GetPaperById(idInt.ToDao());
            return paper.ToDomain();
        }

        public async Task<IdInt> Publish(Paper paper)
        {
            var result = await paperRepository.AddPapers(paper.ToDao());
            await eventBus.Publish(new PaperPublishedEvent(new PaperEventArgs(paper)));

            return result.ToDomain();
        }

        public async Task<IdInt> UpdatePaper(Paper updatedPaper)
        {
            var paperDao = updatedPaper.ToDao();
            var updateId = await paperRepository.Update(paperDao);
            await eventBus.Publish(new PaperUpdatedEvent(new PaperEventArgs(updatedPaper)));
            return updateId.ToDomain();
        }
    }
}