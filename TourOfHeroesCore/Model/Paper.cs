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
        
    }
}

namespace TourOfHeroesCore
{
    public struct PaperContent
    {
        public string Value { get; set; }
    }
}