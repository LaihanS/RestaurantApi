using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestauranteApi.Infrastructure.Persistence.Contexts;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Shared.Services;

namespace RestauranteApi.Infrastructure.Persistence.Repositories
{
    public class OrdenRepository : GenericAppRepository<Orden>, IOrdenRepository
    {
        public readonly ApplicationContext applicationContext;

        private readonly IMapper mapper;

        public OrdenRepository(IMapper mapper, ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
            this.mapper = mapper;
        }
    }
}
