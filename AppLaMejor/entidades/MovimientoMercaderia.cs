using AppLaMejor.datamanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLaMejor.entidades
{
    public class MovimientoMercaderia : BaseEntity
    {
        [DataNames("fecha")]
        public DateTime fecha{ get; set; }

        [DataNames("id_ubicacion_origen")]
        public Ubicacion origen{ get; set; }

        [DataNames("id_ubicacion_destino")]
        public Ubicacion destino { get; set; }

        [DataNames("peso")]
        public decimal peso { get; set; }

        [DataNames("id_producto")]
        public Producto producto { get; set; }

        [DataNames("id_garron")]
        public Garron garron { get; set; }

        public bool confirmado { get; set; }
    }
}
