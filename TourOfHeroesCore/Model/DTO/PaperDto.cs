namespace TourOfHeroesCore.Model.DTO
{
    public record PaperDto(int PaperId, string Title, string Description, string Content, DateTimeOffset PublicationDate, int Like, int DontLike, int HeroId, int AuthorId);

}
