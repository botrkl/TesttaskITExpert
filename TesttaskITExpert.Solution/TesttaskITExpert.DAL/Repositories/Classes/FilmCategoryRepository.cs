using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class FilmCategoryRepository : BaseRepository<FilmCategory>
    {
        private CinematicCatalogDbContext _dbContext;
        public FilmCategoryRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}   
