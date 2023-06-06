using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOfHeroesCore.Model.DAO
{
    public record IdDao(int IdValue);

    public record UserDao(int UserId,string UserName);

    public record RoleDao(int RoleId, string Label);
    public record UserRoleDao(int RoleId, int UserId);

    public record HeroDao(int HeroId, string Name, int PowerTypeId, int Strenght, int Popularity, DateTimeOffset LastUpdate);

    public record PaperDao(int PaperId, string Title, string Description, string Content, DateTimeOffset PublicationDate, int Like, int DontLike, int HeroId, int AuthorId);

}
