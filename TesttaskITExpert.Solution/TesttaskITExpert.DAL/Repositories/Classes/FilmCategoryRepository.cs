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
    }
}   
