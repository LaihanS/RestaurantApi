using RestauranteApi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Domain.Entities
{
    public class Orden: AuditableBaseEntity
    {
        public int? Subtotal { get; set; }

        public int? MesaID { get; set; }

        public string? Estado { get; set; }

        public Mesa? Mesa { get; set; }

        public ICollection<Plato>? Platos { get; set; }

    }
}
