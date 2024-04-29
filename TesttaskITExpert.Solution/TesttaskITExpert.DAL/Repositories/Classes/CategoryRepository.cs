using Microsoft.EntityFrameworkCore;
using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private CinematicCatalogDbContext _dbContext;
        public CategoryRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetFilmCountInCategoryAsync(int categoryId)
        {
            return await _dbContext.FilmCategories
                .Where(x => x.category_id == categoryId)
                .CountAsync();
        }
    }
}   
