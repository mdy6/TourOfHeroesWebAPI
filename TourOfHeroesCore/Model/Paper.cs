namespace TourOfHeroesCore.Model
{
    public class Paper : IObjectId<int>
    {
        public Id<int> Id { get; set; } = new IdInt(0);
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PaperContent Content { get; set; } = new PaperContent();
        public DateTimeOffset PublicationDate { get; set; }
        public Like ILikeCount { get; set; } = new Like();
        public DontLike IDontLikeCount { get; set; } = new DontLike();
        public Hero Hero { get; set; } = new Hero();
        public Author Author { get; set; } = new Author();

        public int GetPaperPopularityValue()
        {
            if (ILikeCount.Value == IDontLikeCount.Value)
                return 0;
            return ILikeCount.Value > IDontLikeCount.Value ? 1 : -1;
        }
    }
}

namespace TourOfHeroesCore
{
    public struct PaperContent
    {
        public string Value { get; private set; } = string.Empty;
        public PaperContent(string content)
        {
            Value = content;
        }
        public void SetContent(string value)
        {
            Value = value;
        }
    }
}