namespace TourOfHeroesCore.Model
{
    public class Paper : IObjectId<int>
    {
        public Id<int> Id { get; set; }
        public string Title { get;set; }
        public string Description { get;set; }
        public PaperContent Content { get;set; }
        public DateTimeOffset PublicationDate { get;set; }
        public Like ILikeCount { get;set; }
        public DontLike IDontLikeCount { get;set; }
        public Hero Hero { get;set; }
        public Author Author { get;set; }

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
        public string Value { get; set; }
    }
}