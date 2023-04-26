using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.ViewModels.Mesa
{
    public class MesaViewModel
    {
        public int id { get; set; }
        public int Cantidad { get; set; }

        public string Descipcion { get; set; }

        public string Estado { get; set; }

        public ICollection<OrdenViewModel> Ordenes { get; set; }

    }
}
