using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DTOs.Add;
using TesttaskITExpert.DTOs.Update;

namespace TesttaskITExpert.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddCategory addCategory)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                ViewBag.Errors = errors;
                var categories = await _categoryService.GetAllCategoriesAsync();
                ViewBag.Categories = categories;
                return View();
            }
            else
            {
                var addCategoryModel = _mapper.Map<AddCategoryModel>(addCategory);
                await _categoryService.AddCategoryAsync(addCategoryModel);
                return RedirectToAction("Add");
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categoryList = await _categoryService.GetAllCategoriesAsync();
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
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;
            return View(categoryModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UpdateCategory updateCategory)
        {
           
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                ViewBag.Errors = errors;
                var categoryModel = await _categoryService.GetCategoryByIdAsync(updateCategory.Id);
                return View(categoryModel);
            }
            else
            {
                var updateCategoryModel = _mapper.Map<UpdateCategoryModel>(updateCategory);
                await _categoryService.UpdateCategoryAsync(updateCategoryModel);
                return RedirectToAction("All");
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> AllInfo()
        {
           var categoriesWithInfo = await _categoryService.GetCategoriesInfoAsync();
            return View(categoriesWithInfo);
        }
    }
}
