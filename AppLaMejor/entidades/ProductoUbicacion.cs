using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class ProductoUbicacion : BaseEntity
    {

        [DataNames("id_producto")]
        Producto Producto { get; set; }

        [DataNames("id_ubicacion")]
        public Ubicacion Ubicacion { get; set; }

        [DataNames("id_garron")]
        public Garron garron{ get; set; }

        [DataNames("peso")]
        public decimal peso{ get; set; }

        [DataNames("fecha_egreso")]
        public Nullable<DateTime> Fecha_Egreso { get; set; }

        [DataNames("fecha_ingreso")]
        public DateTime Fecha_ingreso { get; set; }

    }
}
