using Microsoft.AspNetCore.Mvc;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesWebAPI.Controllers
{
    public class HeroController : RootController
    {
        private readonly IHeroService heroService;

        public HeroController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        [HttpGet("heroes",Name ="GetAllHeroes")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await heroService.GetHeroes();
            return heroes == null ? NotFound() : Ok(heroes);
        }
    }
}