using Microsoft.AspNetCore.Mvc;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Model;
using TourOfHeroesWebAPI.Model.InputModel;

namespace TourOfHeroesWebAPI.Controllers
{
    public class PapersController : RootController
    {
        private readonly IPaperService paperService;

        public PapersController(IPaperService paperService)
        {
            this.paperService = paperService;
        }


        [HttpGet(Name = "GetPapers")]
        public async Task<IActionResult> GetPapers()
        {
            var papers = await paperService.GetPapers();
            return papers == null ? NotFound() : Ok(papers.Select(p => p.ToOutput()));
        }

        [HttpGet("{paperId}",Name = "GetPaperById")]
        public async Task<IActionResult> GetPaperById(int paperId)
        {
            var paper = await paperService.GetPaperById(IdInt.Create(paperId));
            return paper == null ? NotFound() : Ok(paper.ToOutput());
        }

        [HttpPost("publish",Name = "PublishPaper")]
        public async Task<IActionResult> PublishPaper(InputPaper inputPaper)
        {
            if (inputPaper.PaperId > 0)
            {
                return Ok(await paperService.UpdatePaper(inputPaper.ToDomain()));
            }
            return Ok(await paperService.Publish(inputPaper.ToDomain()));
        }


    }
}