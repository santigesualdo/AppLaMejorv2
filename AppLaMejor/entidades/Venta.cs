using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Venta : BaseEntity
    {

        [DataNames("monto_total")]
        public decimal MontoTotal { get; set; }

        [DataNames("fecha")]
        public DateTime Fecha { get; set; }

    }
}
