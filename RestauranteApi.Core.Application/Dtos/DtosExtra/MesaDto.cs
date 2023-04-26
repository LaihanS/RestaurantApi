using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Dtos.DtosExtra
{
    public class MesaDto
    {
        public int id { get; set; }
        public int Cantidad { get; set; }

        public string Descipcion { get; set; }

        public string Estado { get; set; }

        public ICollection<OrdenDto> Ordenes { get; set; }

    }
}
