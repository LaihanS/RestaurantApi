
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RestauranteApi.Infrastructure.Persistence.Contexts;
using RestauranteApi.Infrastructure.Persistence.Repositories;
using RestauranteApi.Infrastructure.Persistence.Mappings;
using RestauranteApi.Infrastructure.Shared.Services;

namespace RestauranteApi.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            #region contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase("CItasDB"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("ConnectionDefault");
                services.AddDbContext<ApplicationContext>(options =>
                {

                    options.UseSqlServer(connectionString, m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                    options.EnableSensitiveDataLogging();
                });
            }
            #endregion

            services.AddAutoMapper(typeof(PersistenceProfile).Assembly);


            #region repositories
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient(typeof(IGenericAppRepository<>), typeof(GenericAppRepository<>));
            services.AddTransient<IPlatoRepository, PlatoRepository>();
            services.AddTransient<IMesaRepository, MesaReposiory>();
            services.AddTransient<IOrdenRepository, OrdenRepository>();
            services.AddTransient<IIngredienteRepository, IngredienteRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }

}
