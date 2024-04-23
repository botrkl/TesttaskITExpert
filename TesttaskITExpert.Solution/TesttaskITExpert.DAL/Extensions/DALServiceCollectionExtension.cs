using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesttaskITExpert.DAL.Context;
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
        }
    }
}
