using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Dtos.DtosExtra
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
