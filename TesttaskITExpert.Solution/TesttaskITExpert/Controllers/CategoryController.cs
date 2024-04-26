using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("/category/add")]
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [Route("/category/add")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] AddCategoryModel addCategoryModel)
        {
            await _categoryService.AddCategoryAsync(addCategoryModel);
            return RedirectToAction("CreateCategory");
        }
        [Route("/category/all")]
        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var categoryList = await _categoryService.GetAllCategories();
            return View(categoryList);
        }
        [Route("/category/delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromForm] int categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return RedirectToAction("AllCategories");
        }
        [Route("/category/edit")]
        [HttpGet]
        public async Task<IActionResult> EditCategory(int? categoryId)
        {
            if (categoryId == null)
            {
                return RedirectToAction("AllCategories");
            }
            var categoryModel = await _categoryService.GetCategoryByIdAsync(categoryId.Value);
            return View(categoryModel);
        }
        [Route("/category/edit")]
        [HttpPost]
        public async Task<IActionResult> EditCategory([FromForm] UpdateCategoryModel categoryModel)
        {
            await _categoryService.UpdateCategoryAsync(categoryModel);
            return RedirectToAction("AllCategories");
        }

        [Route("/category/all/info")]
        [HttpGet]
        public async Task<IActionResult> InfoCategories()
        {
           var categoriesWithInfo = await _categoryService.GetCategoriesWithInfoAsync();
            return View(categoriesWithInfo);
        }
    }
}
