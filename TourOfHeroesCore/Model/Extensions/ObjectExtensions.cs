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
                Title = paperDao.Title
            };
        }

        public static IdDao ToDao(this Id<int> id) 
        {
            return new IdDao(id.Value);
        }
    }
}
