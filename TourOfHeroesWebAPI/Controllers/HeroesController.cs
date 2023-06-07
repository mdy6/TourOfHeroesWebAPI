using Microsoft.AspNetCore.Mvc;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;
using TourOfHeroesWebAPI.Model.InputModel;

namespace TourOfHeroesWebAPI.Controllers
{
    public class HeroesController : RootController
    {
        private readonly IHeroService heroService;

        public HeroesController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        [HttpGet(Name ="GetAllHeroes")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await heroService.GetHeroes();
            return heroes == null ? NotFound() : Ok(heroes);
        }

        [HttpPost(Name = "CreateHero")]
        public async Task<IActionResult> CreateHero(InputHero inputHero)
        {
            var inputId = await heroService.CreateHero(inputHero.ToDomain());
            return Ok(inputId);
        }

        [HttpDelete("{heroId}", Name = "DeleteHero")]
        public async Task<IActionResult> DeleteHero(int heroId)
        {
            await heroService.DeleteHero(IdInt.Create(heroId));
            return Ok();
        }
    }
}