
using Microsoft.AspNetCore.Identity;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> role)
        {
            User defaultUser = new();
            defaultUser.UserName = "superadminuser";
            defaultUser.Email = "superadminuser@email.com";
            defaultUser.FirstName = "John";
            defaultUser.LastName = "Doe";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;
            defaultUser.Cedula = "12345678";

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!!");
                    await userManager.AddToRoleAsync(defaultUser, EnumRoles.Administrador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, EnumRoles.Mesero.ToString());
                }
            }

        }
    }
}
