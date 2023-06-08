using TourOfHeroesCore.Model;
using TourOfHeroesCore;

namespace TourOfHeroesWebAPI.Model.InputModel
{
    public class InputPaper
    {
        public int PaperId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTimeOffset PublicationDate { get; set; }
        public int ILikeCount { get; set; } 
        public int IDontLikeCount { get; set; }
        public int HeroId { get; set; }
        public int AuthorId { get; set; }
    }
}