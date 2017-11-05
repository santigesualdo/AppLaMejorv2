using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Producto : BaseEntity
    {
        [DataNames("TipoProducto")]
        public TipoProducto TipoProducto { get; set; }

        [DataNames("CodigoBarra")]
        public string CodigoBarra{ get; set; }

        [DataNames("Precio")]
        public decimal Precio { get; set; }

        [DataNames("DescripcionBreve")]
        public string DescripcionBreve { get; set; }

        [DataNames("DescripcionLarga")]
        public string DescripcionLarga { get; set; }

        [DataNames("Cantidad")]
        public double Cantidad { get; set; }

    }
}
