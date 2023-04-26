using AutoMapper;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Mesa;
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
    public class MesaService : GenericAppService<MesaViewModel, SaveMesaViewModel, Mesa>, IMesaService
    {
       
        private readonly IMesaRepository mesaReposit;
        private readonly IOrdenRepository ordenRepository;
        private readonly IMapper imapper;
        public MesaService(IOrdenRepository ordenRepository, IMesaRepository mesaReposit, IMapper imapper) : base(imapper, mesaReposit)
        {
            this.imapper = imapper;
            this.ordenRepository = ordenRepository;
            this.mesaReposit = mesaReposit;
        }

        public async Task<List<OrdenViewModel>> GetOrdersAsync(int idmesa)
        {
            List<OrdenViewModel> orders = imapper.Map<List<OrdenViewModel>>(await ordenRepository.GetAsyncWithJoin(new List<string> { "Mesa", "Platos"}));
            List<OrdenViewModel> mesaorders = new();
            if (orders != null)
            {
               mesaorders = orders.Where(o => o.MesaID == idmesa).ToList();
            }

            return mesaorders;
        }

        public async Task<SaveMesaDto> ChangeStatus(int idmesa, string newStatus)
        {
            SaveMesaDto mesa = imapper.Map<SaveMesaDto>(await mesaReposit.GetByidAsync(idmesa));

            if (mesa != null)
            {
                mesa.Estado = newStatus;
                await mesaReposit.EditAsync(imapper.Map<Mesa>(mesa), mesa.id);
            }

            return mesa;
        }

    }
}
