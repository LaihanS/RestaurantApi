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
    public class IngredienteService : GenericAppService<IngredienteViewModel, SaveIngredienteViewModel, Ingrediente>, IIngredienteService
    {
       
        private readonly IIngredienteRepository ingredienteRepository;
        private readonly IMapper imapper;
        public IngredienteService(IIngredienteRepository ingredienteRepository, IMapper imapper) : base(imapper, ingredienteRepository)
        {

            this.ingredienteRepository = ingredienteRepository;
        }

    }
}
