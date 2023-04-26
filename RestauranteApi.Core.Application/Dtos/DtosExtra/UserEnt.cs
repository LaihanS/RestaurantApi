using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Dtos.DtosExtra
{
    public class UserEnt : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        
    }
}
