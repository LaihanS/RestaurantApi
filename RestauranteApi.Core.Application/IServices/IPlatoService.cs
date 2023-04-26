using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Persistence.Repositories;

namespace RestauranteApi.Infrastructure.Shared.Services
{
    public interface IPlatoService: IGenericAppService<PlatoViewModel, SavePlatoViewModel, Plato>
    {
        Task<List<PlatoViewModel>> JoinPlatos();
        Task<PlatoViewModel> GetByidJoin(int id);
        Task<PlatoViewModel> EditPlat(SavePlatoViewModel plato, string addorquit, int platoid, int ingredienteid);
    }
}