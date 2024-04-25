using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Services.Interfaces;

namespace TesttaskITExpert.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [Route("/addFilm")]
        [HttpGet]
        public IActionResult CreateFilm()
        {
            return View();
        }
        [Route("/addFilm")]
        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromForm] AddFilmModel addFilmModel)
        {
            await _filmService.AddFilmAsync(addFilmModel);
            return RedirectToAction("CreateFilm");
        }
    }
}
