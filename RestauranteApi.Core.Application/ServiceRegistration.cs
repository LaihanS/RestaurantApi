
using Microsoft.Extensions.DependencyInjection;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            #region ServicesDependency
            services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            services.AddTransient(typeof(IGenericAppService<,,>), typeof(GenericAppService<,,>));
            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IMesaService, MesaService>();
            services.AddTransient<IOrdenService, OrdenService>();
            services.AddTransient<IPlatoService, PlatoService>();

            #endregion
        }
    }
}
