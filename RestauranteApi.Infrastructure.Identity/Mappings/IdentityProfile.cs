using AutoMapper;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.ViewModels.UserVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = RestauranteApi.Infrastructure.Identity.Entities.User;

namespace Banking.Infrastructure.Identity.Mappings
{
    public class IdentityProfile: Profile
    {
        public IdentityProfile() {

            CreateMap<User, UserDTO>()
                .ForMember(loginvm => loginvm.Password, action => action.Ignore())
                .ForMember(loginvm => loginvm.ConfirmPassword, action => action.Ignore())
        .ReverseMap()
          .ForMember(loginvm => loginvm.TwoFactorEnabled, action => action.Ignore())
          .ForMember(loginvm => loginvm.SecurityStamp, action => action.Ignore())
           .ForMember(loginvm => loginvm.PhoneNumber, action => action.Ignore())
            .ForMember(loginvm => loginvm.LockoutEnabled, action => action.Ignore())
             .ForMember(loginvm => loginvm.AccessFailedCount, action => action.Ignore())
              .ForMember(loginvm => loginvm.LockoutEnd, action => action.Ignore())
               .ForMember(loginvm => loginvm.NormalizedEmail, action => action.Ignore())
                .ForMember(loginvm => loginvm.NormalizedUserName, action => action.Ignore())
                .ForMember(loginvm => loginvm.PasswordHash, action => action.Ignore())
          .ForMember(loginvm => loginvm.PhoneNumberConfirmed, action => action.Ignore());

            CreateMap<User, UserViewModel>()
               .ForMember(loginvm => loginvm.Password, action => action.Ignore())
               .ForMember(loginvm => loginvm.ConfirmPassword, action => action.Ignore())
               //.ForMember(uservm => uservm.Roles, action => action.MapFrom(ac => ac.Roles.ToList()))
       .ReverseMap()
       //.ForMember(uservm => uservm.Roles, action => action.MapFrom(ac => ac.Roles.ToList()))
         .ForMember(loginvm => loginvm.TwoFactorEnabled, action => action.Ignore())
         .ForMember(loginvm => loginvm.SecurityStamp, action => action.Ignore())
          .ForMember(loginvm => loginvm.PhoneNumber, action => action.Ignore())
           .ForMember(loginvm => loginvm.LockoutEnabled, action => action.Ignore())
            .ForMember(loginvm => loginvm.AccessFailedCount, action => action.Ignore())
             .ForMember(loginvm => loginvm.LockoutEnd, action => action.Ignore())
              .ForMember(loginvm => loginvm.NormalizedEmail, action => action.Ignore())
               .ForMember(loginvm => loginvm.NormalizedUserName, action => action.Ignore())
               .ForMember(loginvm => loginvm.PasswordHash, action => action.Ignore())
         .ForMember(loginvm => loginvm.PhoneNumberConfirmed, action => action.Ignore());

     //       CreateMap<Products, Product>()
     //  .ReverseMap();

     //       CreateMap<ProductDto, Product>()
     //    .ReverseMap();

     //       CreateMap<ProductDto, Products>()
     //   .ReverseMap();

     //       CreateMap<UserViewModel, User>()
     //.ReverseMap();

        }
    }
}
