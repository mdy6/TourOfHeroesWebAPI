using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DAO;

namespace TourOfHeroesCore.Interfaces.Repository
{
    public interface IHeroRepository
    {
        Task<HeroDao> GetHeroById(IdDao id);
        Task<IdDao> AddHero(HeroDao heroDao);
        Task<PaperDao[]> GetHeroPapers(IdDao heroId);
        Task UpdateHero(HeroDao heroToUpdate);
        Task DeleteHero(IdDao idDao);
        Task<HeroDao[]> GetHeroes();
    }
}
