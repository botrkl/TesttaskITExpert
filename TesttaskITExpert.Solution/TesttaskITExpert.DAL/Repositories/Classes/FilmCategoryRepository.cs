using Microsoft.EntityFrameworkCore;
using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class FilmCategoryRepository : BaseRepository<FilmCategory>, IFilmCategoryRepository
    {
        private CinematicCatalogDbContext _dbContext;
        public FilmCategoryRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>?> GetCategoriesByFilmIdAsync(int filmId)
        {
            var categoryIds = await _dbContext.FilmCategories
                .Where(fc => fc.film_id == filmId)
                .Select(fc => fc.category_id)
                .ToListAsync();

            var categories = await _dbContext.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();

            return  categories;
        }
    }
}   
