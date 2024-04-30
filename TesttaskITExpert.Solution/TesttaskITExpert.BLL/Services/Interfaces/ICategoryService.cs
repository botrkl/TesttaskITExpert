﻿using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;

namespace TesttaskITExpert.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryModel?> GetCategoryByIdAsync(int id);
        public Task DeleteCategoryAsync(int id);
        public Task AddCategoryAsync(AddCategoryModel model);
        public Task UpdateCategoryAsync(UpdateCategoryModel model);
        public Task<IList<CategoryModel>?> GetAllCategoriesAsync();
        public Task<int> GetFilmCountInCategoryAsync(int categoryId);
        public Task<int> GetNestedLevelAsync(int categoryId);
        public Task<IList<CategoryViewModel>> GetCategoriesInfoAsync();
    }
}
