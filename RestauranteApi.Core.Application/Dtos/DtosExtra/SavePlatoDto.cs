using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Dtos.DtosExtra
{
    public class SavePlatoDto
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public int Precio { get; set; }

        public int Cantidad { get; set; }

        public int? OrdenID { get; set; }

        public string Categoría { get; set; }

    }
}
