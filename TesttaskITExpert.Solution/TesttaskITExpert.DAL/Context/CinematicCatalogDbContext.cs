using Microsoft.EntityFrameworkCore;
using TesttaskITExpert.DAL.Entities;
using TesttaskITExpert.DAL.EntitiesConfiguration;

namespace TesttaskITExpert.DAL.Context
{
    public class CinematicCatalogDbContext : DbContext
    {
        public CinematicCatalogDbContext(DbContextOptions options):base(options) { }
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration()); ;
            modelBuilder.ApplyConfiguration(new FilmCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
