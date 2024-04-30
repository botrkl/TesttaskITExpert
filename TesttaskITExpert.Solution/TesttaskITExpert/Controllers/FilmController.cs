using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DTOs.Add;

namespace TesttaskITExpert.Controllers
{
    [Route("[controller]")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public FilmController(IFilmService filmService, ICategoryService categoryService, IMapper mapper)
        {
            _filmService = filmService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddFilm addFilm)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                ViewBag.Errors = errors;
                return View();
            }
            else
            {
                var addFilmModel = _mapper.Map<AddFilmModel>(addFilm);
                await _filmService.AddFilmAsync(addFilmModel);
                return RedirectToAction("All");
            } 
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> All(string? category, string? director)
        {
            var filmList = await _filmService.GetAllFilmsAsync();
            for (int i = 0; i < filmList.Count(); i++)
            {
                filmList[i] = await _filmService.GetFilmWithCategoriesByFilmIdAsync(filmList[i].Id);

            }
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(x => new { Id = x.Id, name = x.name });

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
            var filModel = await _filmService.GetFilmByIdAsync(filmId.Value);
            return View(filModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateFilmModel updateFilm)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                ViewBag.Errors = errors;
                var filmModel = await _filmService.GetFilmByIdAsync(updateFilm.Id);
                return View(filmModel);
            }
            else
            {
                var updateFilmModel = _mapper.Map<UpdateFilmModel>(updateFilm);
                await _filmService.UpdateFilmAsync(updateFilmModel);
                return RedirectToAction("All");
            }
        }

        [Route("[action]/{filmId:int}")]
        [HttpGet]
        public async Task<IActionResult> Info(int? filmId)
        {
            if (filmId == null)
            {
                return RedirectToAction("All");
            }
            var filmModel = await _filmService.GetFilmWithCategoriesByFilmIdAsync(filmId.Value);
            var allCategories = await _categoryService.GetAllCategoriesAsync();
            var categories = allCategories?.Where(c => filmModel.Categories.All(fc => fc.Id != c.Id)).ToList();
            ViewBag.Categories = categories;
            return View(filmModel);
        }

        [Route("[action]/{filmId:int}")]
        [HttpPost]
        public async Task<IActionResult> AddCategoryToFilm(int filmId, [FromBody] IList<int>? categoryList)
        {
            await _filmService.AddCategoriesToFilmAsync(filmId, categoryList);
            return RedirectToAction("All");
        }
    }
}
