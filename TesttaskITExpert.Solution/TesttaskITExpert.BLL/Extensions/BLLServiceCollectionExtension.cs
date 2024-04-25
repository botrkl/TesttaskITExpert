using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesttaskITExpert.BLL.Mapping;
using TesttaskITExpert.BLL.Services.Classes;
using TesttaskITExpert.BLL.Services.Interfaces;

namespace TesttaskITExpert.BLL.Extensions
{
    public static class BLLServiceCollectionExtension
    {
        public static void InjectBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(CategoryMapperProfile));
            services.AddAutoMapper(typeof(FilmMapperProfile));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFilmService, FilmService>();
        }
    }
}
