using RestauranteApi.Core.Application.Dtos.Account;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Dtos.Email;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Mesa;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Persistence.Repositories;

namespace RestauranteApi.Infrastructure.Shared.Services
{
    public interface IMesaService: IGenericAppService<MesaViewModel, SaveMesaViewModel, Mesa>
    {
        Task<List<OrdenViewModel>> GetOrdersAsync(int idmesa);
        Task<SaveMesaDto> ChangeStatus(int idmesa, string newStatus);
    }
}