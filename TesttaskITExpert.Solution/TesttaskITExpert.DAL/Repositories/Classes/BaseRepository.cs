using E_Shop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.DAL.Repositories.Classes
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private CinematicCatalogDbContext _dbContext;
        public BaseRepository(CinematicCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var removeEntity = await _dbContext.Set<TEntity>().FirstAsync(x => x.Id == id);
            _dbContext.Set<TEntity>().Remove(removeEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IList<TEntity>?> GetAllAsync()
        {
            var result = await _dbContext.Set<TEntity>().ToListAsync();
            return result;
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var searchedEntity = await _dbContext.Set<TEntity>().FirstAsync(x => x.Id == id);
            return searchedEntity;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
