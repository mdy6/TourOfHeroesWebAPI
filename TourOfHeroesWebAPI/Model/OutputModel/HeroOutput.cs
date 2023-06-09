namespace TourOfHeroesWebAPI.Model.OutputModel
{
    public class HeroOutput
    {
        public int HeroId { get; set; }
        public string Name { get; set; }
        public int Populairty { get;set; }
        public int Strength { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
    }
}
