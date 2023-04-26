using RestauranteApi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Domain.Entities
{
    public class Plato: AuditableBaseEntity
    {
        public string? Nombre { get; set; }

        public int? Precio { get; set; }

        public int? Cantidad { get; set; }

        public int? OrdenID { get; set; }

        public Orden? Orden { get; set; }

        public ICollection<Ingrediente>? Ingredientes { get; set; }

        public string? Categoría { get; set; }

    }
}
