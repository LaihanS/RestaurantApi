using RestauranteApi.Core.Application.Dtos.Account;
using RestauranteApi.Core.Application.Dtos.Email;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Persistence.Repositories;

namespace RestauranteApi.Infrastructure.Shared.Services
{
    public interface IMesaRepository: IGenericAppRepository<Mesa>
    {
    }
}