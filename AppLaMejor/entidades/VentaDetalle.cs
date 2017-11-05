using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class VentaDetalle : BaseEntity
    {
        [DataNames("id_producto")]
        public Producto Producto { get; set; }

        [DataNames("id_venta")]
        public Venta Venta{ get; set; }

        [DataNames("monto")]
        public decimal Monto{ get; set; }

        [DataNames("peso")]
        public decimal Peso { get; set; }

        [DataNames("localidad")]
        public string Localidad { get; set; }

    }
}
