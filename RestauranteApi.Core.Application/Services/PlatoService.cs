using AutoMapper;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Services
{
    public class PlatoService : GenericAppService<PlatoViewModel, SavePlatoViewModel,Plato>, IPlatoService
    {
       
        private readonly IPlatoRepository platoRepository;
        private readonly IIngredienteRepository ingredienteRepository;
        private readonly IMapper imapper;
        public PlatoService(IIngredienteRepository ingredienteRepository, IPlatoRepository platoRepository, IMapper imapper) : base(imapper, platoRepository)
        {
            this.ingredienteRepository = ingredienteRepository;
            this.imapper = imapper;
            this.platoRepository = platoRepository;
        }

        public async Task<PlatoViewModel> EditPlat(SavePlatoViewModel plato, string addorquit, int platoid, int ingredienteid)
        {
           await platoRepository.EditAsync(imapper.Map<Plato>(plato), platoid);

            if (addorquit == "add")
            {
                Ingrediente ingrediente = await ingredienteRepository.GetByidAsync(ingredienteid);
                ingrediente.PlatoID = platoid;
                await ingredienteRepository.EditAsync(ingrediente, ingrediente.id);
            }
            else
            {
                Ingrediente ingrediente = await ingredienteRepository.GetByidAsync(ingredienteid);
                ingrediente.PlatoID = null;
                await ingredienteRepository.EditAsync(ingrediente, ingrediente.id);
            }

            List<PlatoViewModel> saveOrder = imapper.Map<List<PlatoViewModel>>(await platoRepository.GetAsyncWithJoin(new List<string> { "Ingredientes" }));

            return saveOrder.Find(o => o.id == platoid);
        }

        public async Task<List<PlatoViewModel>> JoinPlatos()
        {
            List<PlatoViewModel> saveOrder = imapper.Map<List<PlatoViewModel>>(await platoRepository.GetAsyncWithJoin(new List<string> { "Ingredientes" }));

            return saveOrder;
        }

        public async Task<PlatoViewModel> GetByidJoin(int id)
        {
            List<PlatoViewModel> saveOrder = imapper.Map<List<PlatoViewModel>>(await platoRepository.GetAsyncWithJoin(new List<string> { "Ingredientes" }));

            return saveOrder.Find(o => o.id == id);
        }
    }
}
