using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestauranteApi.Infrastructure.Persistence.Contexts;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Shared.Services;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Infrastructure.Identity.Contexts;

namespace RestauranteApi.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<UserDTO, UserEnt>, IUserRepository
    {
        public readonly IdentityContext applicationContext;

        private readonly IMapper mapper;

        public UserRepository(IMapper mapper, IdentityContext applicationContext) : base(mapper, applicationContext)
        {
            this.applicationContext = applicationContext;
            this.mapper = mapper;
        }
    }
}
