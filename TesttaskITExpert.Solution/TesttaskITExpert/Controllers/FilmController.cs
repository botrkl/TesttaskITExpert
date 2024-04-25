using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
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
        [Route("/film/add")]
        [HttpGet]
        public IActionResult CreateFilm()
        {
            return View();
        }
        [Route("/film/add")]
        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromForm] AddFilmModel addFilmModel)
        {
            await _filmService.AddFilmAsync(addFilmModel);
            return RedirectToAction("CreateFilm");
        }

        [Route("/film/all")]
        [HttpGet]
        public async Task<IActionResult> AllFilms()
        {
            var filmList = await _filmService.GetAllFilms();
            return View(filmList);
        }
        [Route("/film/delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteFilm([FromForm] int filmId)
        {
            await _filmService.DeleteFilmAsync(filmId);
            return RedirectToAction("AllFilms");
        }
        [Route("/film/edit")]
        [HttpGet]
        public async Task<IActionResult> EditFilm(int? filmId)
        {
            if (filmId == null)
            {
                return RedirectToAction("AllFilms");
            }
            var filModel = await _filmService.GetFilmModelByIdAsync(filmId.Value);
            return View(filModel);
        }
        [Route("/film/edit")]
        [HttpPost]
        public async Task<IActionResult> EditFilm([FromForm] UpdateFilmModel filmModel)
        {
            await _filmService.UpdateFilmAsync(filmModel);
            return RedirectToAction("AllFilms");
        }
    }
}
