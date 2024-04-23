using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.Repositories.Interfaces;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        private CinematicCatalogDbContext _dbContext;
        public FilmRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}   
