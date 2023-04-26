using AutoMapper;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.Mesa;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Mappings
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile() {

            #region Ingredient-IngredientVms
            CreateMap<Ingrediente, IngredienteViewModel>()
              .ReverseMap()
                .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());

            CreateMap<Ingrediente, SaveIngredienteViewModel>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());



            CreateMap<IngredienteViewModel, SaveIngredienteViewModel>()
                .ReverseMap()
                    .ForMember(saveuser => saveuser.Plato, action => action.Ignore());


            CreateMap<Ingrediente, SaveIngredientDto>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());


            CreateMap<SaveIngredienteViewModel, SaveIngredientDto>()
                .ReverseMap();

            #endregion

            #region Mesa-MesaVms
            CreateMap<Mesa, MesaViewModel>()
              .ReverseMap()
                .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());

            CreateMap<Mesa, SaveMesaViewModel>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore())
                .ForMember(user => user.Ordenes, action => action.Ignore());


            CreateMap<MesaViewModel, SaveMesaViewModel>()
                .ReverseMap()
                    .ForMember(saveuser => saveuser.Ordenes, action => action.Ignore());


            CreateMap<Mesa, SaveMesaDto>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore())
                     .ForMember(user => user.Ordenes, action => action.Ignore());


            CreateMap<SaveMesaViewModel, SaveMesaDto>()
                .ReverseMap();

    

            #endregion

            #region Orden-OrdenVms
            CreateMap<Orden, OrdenViewModel>()
              .ReverseMap()
                .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());

            CreateMap<Orden, SaveOrderViewModel>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore())
                .ForMember(user => user.Mesa, action => action.Ignore())
                 .ForMember(user => user.Platos, action => action.Ignore());


            CreateMap<OrdenViewModel, SaveOrderViewModel>()
                .ReverseMap()
                     .ForMember(user => user.Mesa, action => action.Ignore())
                 .ForMember(user => user.Platos, action => action.Ignore());


            CreateMap<Orden, SaveOrderDto>()
                .ReverseMap()
                  .ForMember(user => user.created, action => action.Ignore())
                   .ForMember(user => user.createdBy, action => action.Ignore())
                    .ForMember(user => user.modifiedBy, action => action.Ignore())
                     .ForMember(user => user.modifiedAt, action => action.Ignore());


            CreateMap<SaveOrderViewModel, SaveOrderDto>()
                .ReverseMap();

            #endregion

            #region Plato-Platovms
            CreateMap<Plato, PlatoViewModel>()
              .ReverseMap()
                .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore());

            CreateMap<Plato, SavePlatoViewModel>()
                 .ReverseMap()
                 .ForMember(user => user.created, action => action.Ignore())
                 .ForMember(user => user.createdBy, action => action.Ignore())
                  .ForMember(user => user.modifiedBy, action => action.Ignore())
                   .ForMember(user => user.modifiedAt, action => action.Ignore())
                .ForMember(user => user.Orden, action => action.Ignore())
                 .ForMember(user => user.Ingredientes, action => action.Ignore());


            CreateMap<PlatoViewModel, SavePlatoViewModel>()
                .ReverseMap()
                .ForMember(user => user.Orden, action => action.Ignore())
                 .ForMember(user => user.Ingredientes, action => action.Ignore());


            CreateMap<Plato, SavePlatoDto>()
                .ReverseMap()
                  .ForMember(user => user.created, action => action.Ignore())
                   .ForMember(user => user.createdBy, action => action.Ignore())
                    .ForMember(user => user.modifiedBy, action => action.Ignore())
                     .ForMember(user => user.modifiedAt, action => action.Ignore());

            CreateMap<SavePlatoViewModel, SavePlatoDto>()
                 //   .ForMember(user => user.Orden, action => action.Ignore())
                 //.ForMember(user => user.Ingredientes, action => action.Ignore())
                .ReverseMap();


            #endregion


        }

    }
}
