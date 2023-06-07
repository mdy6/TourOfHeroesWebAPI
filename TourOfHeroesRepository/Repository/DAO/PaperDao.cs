namespace TourOfHeroesRepository.Repository.DAO
{
    public class PaperDao
    {
        public int PaperId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DontLike { get; set; }
        public int HeroId { get; set; }
        public int AuthorId { get; set; }
        public DateTimeOffset PublicationDate { get; set; }

        public PaperDao()
        { }

        public PaperDao(int paperId, string title, string description, string content, int like, int dontLike, int heroId, int authorId, DateTimeOffset publicationDate)
        {
            PaperId = paperId;
            Title = title;
            Description = description;
            Content = content;
            Like = like;
            DontLike = dontLike;
            HeroId = heroId;
            AuthorId = authorId;
            PublicationDate = publicationDate;
        }
    }
}
