using AutoMapper;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Services;
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
    public class OrdenService : GenericAppService<OrdenViewModel, SaveOrderViewModel, Orden>, IOrdenService
    {

        private readonly IOrdenRepository ordenRepository;
        private readonly IPlatoRepository platoRepository;
        private readonly IMapper imapper;
        public OrdenService(IPlatoRepository platoRepository, IOrdenRepository ordenRepository, IMapper imapper) : base(imapper, ordenRepository)
        {
            this.imapper = imapper;
            this.platoRepository = platoRepository;
            this.ordenRepository = ordenRepository;
        }


        public async Task EditPlat(string addorquit, int platoid)
        {
            if (addorquit == "add")
            {
                Plato plato = await platoRepository.GetByidAsync(platoid);
                plato.OrdenID = platoid;
                await platoRepository.EditAsync(plato, plato.id);
            }
            else
            {
                Plato plato = await platoRepository.GetByidAsync(platoid);
                plato.OrdenID = null;
                await platoRepository.EditAsync(plato, plato.id);
            }

        }

        public async Task<OrdenViewModel> GetOrderJoin(int orderid)
        {
            List<OrdenViewModel> saveOrder = imapper.Map<List<OrdenViewModel>>(await ordenRepository.GetAsyncWithJoin(new List<string> { "Platos", "Mesa" }));
            OrdenViewModel returnorder = saveOrder.Find(p => p.id == orderid);

            return returnorder;
        }

        public async Task<List<OrdenViewModel>> GetAllJoin()
        {
            List<OrdenViewModel> saveOrder = imapper.Map<List<OrdenViewModel>>(await ordenRepository.GetAsyncWithJoin(new List<string> { "Platos", "Mesa" }));

            return saveOrder;
        }


    }
}
