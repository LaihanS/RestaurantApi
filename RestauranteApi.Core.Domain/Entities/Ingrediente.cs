using RestauranteApi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Domain.Entities
{
    public class Ingrediente: AuditableBaseEntity
    {
        public string? Nombre { get; set; }

        public int? PlatoID { get; set; }

        public Plato? Plato { get; set; }
    }
}
