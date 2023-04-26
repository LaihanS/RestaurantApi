using RestauranteApi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Domain.Entities
{
    public class Mesa: AuditableBaseEntity
    {
        public int? Cantidad { get; set; }

        public string? Descipcion { get; set; }

        public string? Estado { get; set; }

        public ICollection<Orden>? Ordenes { get; set; }

       
    }
}
