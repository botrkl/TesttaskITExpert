using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Services.Interfaces;

namespace TesttaskITExpert.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("/addCategory")]
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [Route("/addCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] AddCategoryModel addCategoryModel)
        {
            await _categoryService.AddCategoryAsync(addCategoryModel);
            return RedirectToAction("CreateCategory");
        }
    }
}
