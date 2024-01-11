using Elastic.Apm.NetCoreAll;
using Exodus.BaseAPI.Infrastructure.Extensions;
using HealthChecks.UI.Client;
using AlumnosService.Application;
using AlumnosService.Persistence;
using AlumnosService.Application.Contracts.Persistence.v1;
using AlumnosService.Persistence.Repositories.v1;
using AlumnosService.Application.Contracts.Queries.v1;
using AlumnosService.Application.Queries.v1;
using AlumnosService.Persistence.Context.v1;
using Microsoft.EntityFrameworkCore;

namespace AlumnosService.API
{
    public static class StartupExtensions
    {

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Host.AddSerilog();


            builder.Services.AddApplicationServices();


            builder.Services.AddDbContext<DeusContext>(options =>
                      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
                      {
                          sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
                          sqlOptions.CommandTimeout(120);
                      }));

            builder.Services.AddTransient<IAlumnosRepository, AlumnosRepository>();
            builder.Services.AddTransient<IMateriasRepository, MateriasRepository>();
            builder.Services.AddTransient<IAlumnosQueryService, AlumnosQueryService>();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwagger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? "Title", "Servicio que gestiona información de los alumnos").AddAPIVersioning();
            //





            builder.Services.AddHealthChecks();
            
            return builder.Build();
        }






        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                app.UseSwaggerWithVersioning();
            }

            app.UseAllElasticApm(app.Configuration);


            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                Predicate = (v) => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapGet("/", () => "Running...");


            return app;
        }
    }
}
