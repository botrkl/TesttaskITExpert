using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesttaskITExpert.DAL.Context;
using TesttaskITExpert.DAL.Repositories.Classes;
using TesttaskITExpert.DAL.Repositories.Interfaces;
namespace TesttaskITExpert.DAL.Extensions
{
    public static class DALServiceCollectionExtension
    {
        public static void InjectDALServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CinematicCatalogDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFilmCategoryRepository, FilmCategoryRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
        }
    }
}
