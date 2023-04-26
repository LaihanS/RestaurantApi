
using Microsoft.AspNetCore.Identity;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> role)
        {
           await role.CreateAsync(new IdentityRole(EnumRoles.Administrador.ToString()));
           await role.CreateAsync(new IdentityRole(EnumRoles.Mesero.ToString()));
        }

    }
}
