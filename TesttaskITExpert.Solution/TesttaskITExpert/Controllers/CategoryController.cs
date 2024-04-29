using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;

namespace TesttaskITExpert.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddCategoryModel addCategoryModel)
        {
            await _categoryService.AddCategoryAsync(addCategoryModel);
            return RedirectToAction("Add");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categoryList = await _categoryService.GetAllCategories();
            return View(categoryList);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return RedirectToAction("All");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? categoryId)
        {
            if (categoryId == null)
            {
                return RedirectToAction("All");
            }
            var categoryModel = await _categoryService.GetCategoryByIdAsync(categoryId.Value);
            return View(categoryModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateCategoryModel categoryModel)
        {
            await _categoryService.UpdateCategoryAsync(categoryModel);
            return RedirectToAction("All");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Info()
        {
           var categoriesWithInfo = await _categoryService.GetCategoriesWithInfoAsync();
            return View(categoriesWithInfo);
        }
    }
}
