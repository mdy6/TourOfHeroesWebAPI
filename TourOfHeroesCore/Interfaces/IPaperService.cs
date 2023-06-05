using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.Extensions;

namespace TourOfHeroesCore.Interfaces
{
    public interface IPaperService
    {
        Task Publish(Paper paper);
    }

    public class PaperService : IPaperService
    {
        private readonly IPaperRepository paperRepository;
        private readonly IReaderNotifier<Paper> readerNotifier;

        public PaperService(IPaperRepository paperRepository, IReaderNotifier<Paper> readerNotifier)
        {
            this.paperRepository = paperRepository;
            this.readerNotifier = readerNotifier;
        }
        public Task Publish(Paper paper)
        {
            paperRepository.AddPapers(paper.ToDao());
            readerNotifier.NotifyReaders(new PaperNotification());
            return Task.CompletedTask;
        }

        public class PaperNotification : INotification<Paper> { }
    }
}