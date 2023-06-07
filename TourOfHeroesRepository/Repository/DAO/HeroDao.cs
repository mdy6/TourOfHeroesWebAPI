using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesRepository.Repository.DAO
{
    public class HeroDao
    {
        public int HeroId { get;set; }
        public string Name { get;set;}
        public int PowerTypeId { get; set; }
        public int Popularity { get; set; }
        public int Strength { get; set; }
        public DateTimeOffset LastUpdate { get; set; }


        public HeroDto ToDto() => new HeroDto(HeroId, Name, PowerTypeId,  Strength, Popularity,LastUpdate);
    }

}
