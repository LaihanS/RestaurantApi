using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.ViewModels.Ingrediente
{
    public class SaveIngredienteViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public int PlatoID { get; set; }


    }
}
