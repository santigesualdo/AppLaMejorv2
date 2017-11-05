using AppLaMejor.datamanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLaMejor.entidades
{
    public class GarronParte
    {
        [DataNames("id")]
        public int Id { get; set; }

        [DataNames("peso")]
        public decimal Peso { get; set; }

        [DataNames("id_producto")]
        public Producto Producto {get;set;}

        [DataNames("id_garron")]
        public Garron Garron { get; set; }

    }
}
