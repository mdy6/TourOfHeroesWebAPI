using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOfHeroesCore.Model.DTO
{

    public record HeroDto(int HeroId, string Name, int PowerTypeId, int Strength, int Popularity, DateTimeOffset LastUpdate);

}
