using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.ViewModels.Plato
{
    public class SavePlatoViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public int Precio { get; set; }

        public int Cantidad { get; set; }

        public int? OrdenID { get; set; }

        public string Categoría { get; set; }

    }
}
