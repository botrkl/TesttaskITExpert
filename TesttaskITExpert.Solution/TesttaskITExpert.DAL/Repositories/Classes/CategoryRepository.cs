using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private CinematicCatalogDbContext _dbContext;
        public CategoryRepository(CinematicCatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}   
