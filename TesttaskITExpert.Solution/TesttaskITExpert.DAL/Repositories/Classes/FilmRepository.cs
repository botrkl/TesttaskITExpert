using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class FilmRepository : BaseRepository<Film>
    {
        private CinematicCatalogDbContext _dbContext;
        public FilmRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}   
