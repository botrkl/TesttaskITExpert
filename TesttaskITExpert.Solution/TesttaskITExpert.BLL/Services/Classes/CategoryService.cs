using AutoMapper;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.BLL.Services.Interfaces;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Classes;
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

        public async Task<IList<CategoryModel>?> GetAllCategories()
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
            _mapper.Map(model, tempCategory);
            await _categoryRepository.UpdateAsync(tempCategory);
        }
        public async Task<int> GetNestedLevelAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                // Категория с указанным идентификатором не найдена
                return -1; // Или другое значение, указывающее на ошибку
            }

            int level = 0;
            while (category.ParentCategory != null)
            {
                // Переходим к родительской категории и увеличиваем уровень вложенности
                category = category.ParentCategory;
                level++;
            }

            return level;
        }
        public async Task<IList<CategoryViewModel>> GetCategoriesWithInfoAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            List<CategoryViewModel> categoriesWithInfo = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                // Получение количества фильмов в текущей категории
                int filmCount = await _categoryRepository.GetFilmCountInCategoryAsync(category.Id);

                // Получение уровня вложенности текущей категории
                int nestedLevel = await GetNestedLevelAsync(category.Id);

                // Создание объекта CategoryViewModel с информацией о категории
                CategoryViewModel categoryInfo = new CategoryViewModel
                {
                    Name = category.name,
                    FilmCount = filmCount,
                    NestedLevel = nestedLevel
                };

                // Добавление объекта CategoryViewModel в список
                categoriesWithInfo.Add(categoryInfo);
            }

            return categoriesWithInfo;
        }

    }
}
