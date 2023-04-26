﻿using RestauranteApi.Core.Application.ViewModels.Mesa;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Dtos.DtosExtra
{
    public class SaveOrderDto
    {
        public int id { get; set; }
        public int Subtotal { get; set; }

        public int? MesaID { get; set; }

        public string Estado { get; set; }

    }
}
