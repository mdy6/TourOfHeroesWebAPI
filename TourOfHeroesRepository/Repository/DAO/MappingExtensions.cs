using System.Xml.Linq;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesRepository.Repository.DAO
{
    public static class MappingExtensions
    {
        public static UserDto ToDto(this UserDao entity) => new UserDto(entity.UserId, entity.UserName);
        public static UserDao ToDao(this UserDto entity) => new UserDao(entity.UserId, entity.UserName);
        public static PaperDao ToDao(this PaperDto entity) => new PaperDao(entity.PaperId, entity.Title, entity.Description, entity.Content, entity.Like, entity.DontLike, entity.HeroId, entity.AuthorId, entity.PublicationDate);
        public static PaperDto ToDto(this PaperDao entity) => new PaperDto(entity.PaperId, entity.Title, entity.Description, entity.Content, entity.PublicationDate, entity.Like, entity.DontLike, entity.HeroId, entity.AuthorId);
        public static HeroDto ToDto(this HeroDao entity) => new HeroDto(entity.HeroId, entity.Name, entity.PowerTypeId, entity.Strength, entity.Popularity, entity.LastUpdate);
        public static HeroDao ToDao(this HeroDto entity) => new HeroDao(entity.HeroId, entity.Name, entity.PowerTypeId, entity.Strength, entity.Popularity, entity.LastUpdate);

    }
}
