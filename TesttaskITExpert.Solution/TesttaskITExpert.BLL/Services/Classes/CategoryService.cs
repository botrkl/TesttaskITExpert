using AutoMapper;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.BLL.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategoryAsync(AddCategoryModel model)
        {
            var addCategory = _mapper.Map<Category>(model);
            await _categoryRepository.AddAsync(addCategory);
        }
       
        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IList<CategoryModel>?> GetAllCategoriesAsync()
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            return  _mapper.Map<IList<CategoryModel>>(allCategories);
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            var wantedCategory = await _categoryRepository.GetByIdAsync(id);
            return  _mapper.Map<CategoryModel>(wantedCategory);
        }

        public async Task<int> GetFilmCountInCategoryAsync(int categoryId)
        {
            return await _categoryRepository.GetFilmCountInCategoryAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryModel model)
        {
            var tempCategory = await _categoryRepository.GetByIdAsync(model.Id);

            if (model.parent_category_id.HasValue)
            {
                var parentCategory = await _categoryRepository.GetByIdAsync(model.parent_category_id.Value);
                if (parentCategory != null && IsAncestor(parentCategory, model.Id))
                {
                    throw new Exception("Looping categories!");
                }
            }

            _mapper.Map(model, tempCategory);
            await _categoryRepository.UpdateAsync(tempCategory);
        }

        public async Task<int> GetNestedLevelAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return -1;
            }
            int level = 0;
            while (category.ParentCategory != null)
            {
                category = category.ParentCategory;
                level++;
            }
            return level;
        }

        public async Task<IList<CategoryViewModel>> GetCategoriesInfoAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            List<CategoryViewModel> categoriesWithInfo = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                int filmCount = await _categoryRepository.GetFilmCountInCategoryAsync(category.Id);
                int nestedLevel = await GetNestedLevelAsync(category.Id);
                CategoryViewModel categoryInfo = new CategoryViewModel
                {
                    Name = category.name,
                    FilmCount = filmCount,
                    NestedLevel = nestedLevel
                };
                categoriesWithInfo.Add(categoryInfo);
            }
            return categoriesWithInfo;
        }

        private bool IsAncestor(Category category, int Id)
        {
            if (category == null)
            {
                return false;
            }
            else if (category.Id == Id)
            {
                return true;
            }
            else if (category.ParentCategory != null)
            {
                return IsAncestor(category.ParentCategory, Id);
            }
            return false;
        }
    }
}
