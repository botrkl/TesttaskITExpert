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

        public async Task<ICollection<CategoryModel>?> GetAllCategories()
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<ICollection<CategoryModel>>(allCategories);
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            var wantedCategory = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryModel>(wantedCategory);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryModel model)
        {
            var tempCategory = await _categoryRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, tempCategory);
            await _categoryRepository.UpdateAsync(tempCategory);
        }
    }
}
