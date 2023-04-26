
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Persistence.Repositories;

namespace RestauranteApi.Infrastructure.Shared.Services
{
    public interface IOrdenService: IGenericAppService<OrdenViewModel, SaveOrderViewModel, Orden>
    {
        Task EditPlat(string addorquit, int platoid);
        Task<OrdenViewModel> GetOrderJoin(int orderid);


        Task<List<OrdenViewModel>> GetAllJoin();
    }
}