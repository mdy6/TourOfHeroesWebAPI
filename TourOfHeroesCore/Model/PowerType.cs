namespace TourOfHeroesCore.Model
{
    public class PowerType: IObjectId<int>
    {
        public Id<int> Id { get; set; }
        public string Label { get; set; }
    }
}