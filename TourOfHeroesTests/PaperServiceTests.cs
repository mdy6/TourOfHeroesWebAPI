using FluentAssertions;
using Moq;
using TourOfHeroesCore;
using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;
using static TourOfHeroesTests.HeroServiceTests;

namespace TourOfHeroesTests
{
    public class PaperServiceTests
    {
        private IPaperRepository _paperRepository;
        private IPaperService _paperService;
        private Mock<IReaderNotifier<PaperEventArgs>> _readerNotifier;
        public PaperServiceTests()
        {
            _readerNotifier = new Mock<IReaderNotifier<PaperEventArgs>>();

            EventBus eventBus = new EventBus();
            _paperRepository = new FakePaperRepository();
            _paperService = new PaperService(_paperRepository, eventBus);

            PaperEventHandlers paperEventHandlers = new PaperEventHandlers(_readerNotifier.Object,_paperService);
            eventBus.Subscribe(paperEventHandlers);
        }

        [Fact]
        public async Task when_paper_is_published_then_reader_are_notified()
        {
            var newPaper = new Paper()
            {
                Author = new Author(),
                Hero = new Hero()
            };

            await _paperService.Publish(newPaper);
            (await _paperRepository.GetPapers()).Length.Should().Be(1);
            _readerNotifier.Verify(m => m.NotifyReaders(It.IsAny<Notification<PaperEventArgs>>()), Times.Once());
        }

        [Fact]
        public async Task when_paper_is_updated_then_reader_are_notified()
        {
            PaperDto paperInsert = new PaperDto(3, "hero2article", string.Empty, string.Empty, DateTimeOffset.MinValue, 0, 2, 3, 1);
            await _paperRepository.AddPapers(paperInsert);

            Paper existingPaper = await _paperService.GetPaperById(IdInt.Create(3));

            string newContentValue = "new content";
            existingPaper.Content = new PaperContent(newContentValue);
            Author newAuthor = new Author() { Id = IdInt.Create(3) };
            existingPaper.Author = newAuthor;
            string newTitle = " new title";
            existingPaper.Title = newTitle;
            await _paperService.UpdatePaper(existingPaper);


            PaperDto[] paperDaos = await _paperRepository.GetPapers();
            paperDaos.Length.Should().Be(1);
            paperDaos[0].Content.Should().Be(newContentValue);
            paperDaos[0].Title.Should().Be(newTitle);
            paperDaos[0].AuthorId.Should().Be(3);

            _readerNotifier.Verify(m => m.NotifyReaders(It.IsAny<Notification<PaperEventArgs>>()), Times.Once());
        }
    }
}