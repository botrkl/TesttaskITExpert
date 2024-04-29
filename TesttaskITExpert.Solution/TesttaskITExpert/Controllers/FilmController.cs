using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.Controllers
{
    [Route("[controller]")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ICategoryService _categoryService;
        public FilmController(IFilmService filmService, ICategoryService categoryService)
        {
            _filmService = filmService;
            _categoryService = categoryService;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddFilmModel addFilmModel)
        {
            await _filmService.AddFilmAsync(addFilmModel);
            return RedirectToAction("All");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> All(string? category, string? director)
        {
            var filmList = await _filmService.GetAllFilms();
            for(int i=0;i<filmList.Count();i++)
            {
                filmList[i] = await _filmService.GetFilmByIdWithCategoriesAsync(filmList[i].Id);
                
            }
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories.Select(x=>new {Id = x.Id, name = x.name });

            if (!string.IsNullOrEmpty(category) && int.TryParse(category, out int categoryId))
            {
                filmList = filmList?.Where(film => film.Categories != null && film.Categories.Any(cat => cat.Id == categoryId)).ToList();
            }

            if (!string.IsNullOrEmpty(director))
            {
                filmList = filmList?.Where(x => x.director == director).ToList();
            }

            ViewBag.Directors = filmList?.Select(x => x.director).Distinct().ToList();

            return View(filmList);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int filmId)
        {
            await _filmService.DeleteFilmAsync(filmId);
            return RedirectToAction("All");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? filmId)
        {
            if (filmId == null)
            {
                return RedirectToAction("All");
            }
            var filModel = await _filmService.GetFilmModelByIdAsync(filmId.Value);
            return View(filModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateFilmModel filmModel)
        {
            await _filmService.UpdateFilmAsync(filmModel);
            return RedirectToAction("All");
        }

        [Route("[action]/{filmId:int}")]
        [HttpGet]
        public async Task<IActionResult> Check(int? filmId)
        {
            if(filmId == null)
            {
                return RedirectToAction("All");
            }
            //var filmModel = await _filmService.GetFilmModelByIdAsync(filmId.Value);
            var filmModel = await _filmService.GetFilmByIdWithCategoriesAsync(filmId.Value);
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View(filmModel);
        }

        [Route("[action]/{filmId:int}")]
        [HttpPost]
        public async Task<IActionResult> AddCategoryToFilm(int filmId,[FromBody] IList<int> categoryList)
        {
            await _filmService.AddCategoryToFilmAsync(filmId, categoryList);
            FilmModel c= await _filmService.GetFilmByIdWithCategoriesAsync(filmId);

            return RedirectToAction("Check", new { filmId = filmId });
        }
    }
}
