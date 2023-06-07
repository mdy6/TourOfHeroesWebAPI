using System.ComponentModel.DataAnnotations;

namespace TourOfHeroesWebAPI.Model.InputModel
{
    public class InputHero
    {
        public int HeroId { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public int PowerTypeId { get; set; }
        public int Popularity { get; set; }
        public int Strength { get; set; }
    }
}
