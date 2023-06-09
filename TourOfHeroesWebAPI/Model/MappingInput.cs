using TourOfHeroesCore.Model;
using TourOfHeroesWebAPI.Model.OutputModel;

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

        public static Paper ToDomain(this InputPaper inputPaper) 
        {
            return new Paper()
            {
                Id = IdInt.Create(inputPaper.PaperId),
                Description = inputPaper.Description,
                Hero = new Hero() { Id = IdInt.Create(inputPaper.HeroId) },
                IDontLikeCount = new DontLike(inputPaper.IDontLikeCount),
                ILikeCount = new Like(inputPaper.ILikeCount),
                Content = new PaperContent(inputPaper.Content),
                Author = new Author() { Id = IdInt.Create(inputPaper.AuthorId) },
                Title = inputPaper.Title
            };
        
        }

        public static PaperOutput ToOutput(this Paper paper)
        {
            return new PaperOutput()
            {
                HeroId = paper.Hero.Id.Value,
                AuthorId = paper.Author.Id.Value,
                Content = paper.Content.Value,
                Description = paper.Description,
                ILikeCount = paper.ILikeCount.Value,
                IDontLikeCount = paper.IDontLikeCount.Value,
                PaperId = paper.Id.Value,
                PublicationDate = paper.PublicationDate,
                Title = paper.Title
            };
        }
        public static HeroOutput ToOutput(this Hero hero)
        {
            return new HeroOutput()
            {
                HeroId = hero.Id.Value,
                LastUpdate = hero.LastUpdate,
                Name = hero.Name,
                Populairty = hero.Popularity.Value,
                Strength = hero.Strength.Value
            };
        
        }
    }
}
