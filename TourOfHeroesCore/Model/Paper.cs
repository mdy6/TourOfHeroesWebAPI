namespace TourOfHeroesCore.Model
{
    public class Paper : IObjectId<int>
    {
        public Id<int> Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get;set; }
        public string Description { get;set; }
        public PaperContent Content { get;set; }
        public DateTime PublicationDate { get;set; }
        public Like ILikeCount { get;set; }
        public Like IDontLikeCount { get;set; }
        
    }
}

namespace TourOfHeroesCore
{
    public struct PaperContent
    {
        public string Value { get; set; }
    }
}