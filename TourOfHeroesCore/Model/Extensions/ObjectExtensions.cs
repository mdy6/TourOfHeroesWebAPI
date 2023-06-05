using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesCore.Model.Extensions
{
    public static class ObjectExtensions
    {
        public static Paper ToDomain(this PaperDao paperDao)
        {
            return new Paper()
            {
                Id = new IdInt(paperDao.Id),
                Content = new PaperContent() { Value = paperDao.Content },
                Description = paperDao.Description,
                IDontLikeCount = new DontLike() { Value = paperDao.DontLike },
                ILikeCount = new Like() { Value = paperDao.Like },
                PublicationDate = paperDao.PublicationDate,
                Title = paperDao.Title,
                Hero = new Hero() { Id = new IdInt(paperDao.HeroId)  }
            };
        }

        public static IdDao ToDao(this Id<int> id) 
        {
            return new IdDao(id.Value);
        }

        public static Hero ToDomain(this HeroDao heroDao)
        {
            return new Hero()
            {
                Id = new IdInt(heroDao.Id),
                LastUpdate= heroDao.LastUpdate,
                Name = heroDao.Name,
                Popularity = new Popularity() { Value = heroDao.Popularity },
                PowerType = new PowerType() { Id = new IdInt(heroDao.PowerTypeId) },
                Strength = new Strength() { Value = heroDao.Strenght },
            };
        }
    }
}
