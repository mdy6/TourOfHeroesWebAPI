﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOfHeroesCore.Model;
using TourOfHeroesCore.Model.DTO;

namespace TourOfHeroesCore.Interfaces.Repository
{
    public interface IHeroRepository
    {
        Task<HeroDto> GetHeroById(IdDto id);
        Task<IdDto> AddOrUpdateHero(HeroDto heroDao);
        Task<PaperDto[]> GetHeroPapers(IdDto heroId);
        Task DeleteHero(IdDto idDao);
        Task<HeroDto[]> GetHeroes();
    }
}
