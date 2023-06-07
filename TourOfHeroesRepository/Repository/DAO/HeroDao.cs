using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesRepository.Repository.DAO
{
    public class HeroDao
    {
        public HeroDao(int heroId, string name, int powerTypeId, int popularity, int strength, DateTimeOffset lastUpdate)
        {
            HeroId = heroId;
            Name = name;
            PowerTypeId = powerTypeId;
            Popularity = popularity;
            Strength = strength;
            LastUpdate = lastUpdate;
        }
        public HeroDao()
        { }

        public int HeroId { get;set; }
        public string Name { get;set;}
        public int PowerTypeId { get; set; }
        public int Popularity { get; set; }
        public int Strength { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
    }
}
