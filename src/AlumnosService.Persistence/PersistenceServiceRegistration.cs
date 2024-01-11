

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlumnosService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<GloboTicketDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("GloboTicketTicketManagementConnectionString")));

            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            return services;

        }
    }
}
