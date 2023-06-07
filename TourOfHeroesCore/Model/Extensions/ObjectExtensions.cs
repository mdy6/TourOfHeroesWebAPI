using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesCore.Model.Extensions
{
    public static class ObjectExtensions
    {
        public static Paper ToDomain(this PaperDto paperDao)
        {
            return new Paper()
            {
                Id = IdInt.Create(paperDao.PaperId),
                Content = new PaperContent(paperDao.Content),
                Description = paperDao.Description,
                IDontLikeCount = new DontLike() { Value = paperDao.DontLike },
                ILikeCount = new Like() { Value = paperDao.Like },
                PublicationDate = paperDao.PublicationDate,
                Title = paperDao.Title,
                Hero = new Hero() { Id = IdInt.Create(paperDao.HeroId)  },
                Author = new Author() { Id = IdInt.Create(paperDao.AuthorId) }
            };
        }

        public static PaperDto ToDto(this Paper paper)
        {
            return new PaperDto(paper.Id.Value,
                                paper.Title,
                                paper.Description,
                                paper.Content.Value,
                                paper.PublicationDate,
                                paper.ILikeCount.Value,
                                paper.IDontLikeCount.Value,
                                paper.Hero.Id.Value,
                                paper.Author.Id.Value);
        }

        public static IdDto ToDto(this Id<int> id) 
        {
            return new IdDto(id.Value);
        }
        public static IdInt ToDomain(this IdDto id) 
        {
            return IdInt.Create(id.IdValue);
        }

        public static Hero ToDomain(this HeroDto heroDao)
        {
            return new Hero()
            {
                Id = IdInt.Create(heroDao.HeroId),
                LastUpdate= heroDao.LastUpdate,
                Name = heroDao.Name,
                Popularity = new Popularity() { Value = heroDao.Popularity },
                PowerType = new PowerType() { Id = IdInt.Create(heroDao.PowerTypeId) },
                Strength = new Strength() { Value = heroDao.Strength },
            };
        }

        public static HeroDto ToDto(this Hero hero) 
        {
            return new HeroDto(hero.Id.Value, hero.Name, hero.PowerType.Id.Value, hero.Strength.Value, hero.Popularity.Value, hero.LastUpdate);
        }
    }
}
