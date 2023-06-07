using TourOfHeroesCore.Model;

namespace TourOfHeroesWebAPI.Model.InputModel
{
    public static class MappingModel

    {
        public static Hero ToDomain(this InputHero inputHero)
        {
            return new Hero()
            {
                Id = IdInt.Create(inputHero.HeroId),
                Name = inputHero.Name,
                Popularity = new Popularity() { Value = inputHero.Popularity },
                PowerType = new PowerType() { Id = IdInt.Create(inputHero.PowerTypeId) },
                Strength = new Strength() { Value = inputHero.Strength },
            };
        }
    }
}
