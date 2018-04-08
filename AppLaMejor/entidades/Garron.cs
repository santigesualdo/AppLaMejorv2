using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Garron : BaseEntity
    {
        [DataNames("numero")]
        public string Numero { get; set; }

        [DataNames("id_tipo_garron")]
        public TipoGarron TipoGarron { get; set; }

        [DataNames("id_tipo_estado")]
        public TipoEstadoGarron TipoEstadoGarron { get; set; }

        [DataNames("fecha_entrada")]
        public DateTime FechaEntrada { get; set; }

        [DataNames("peso")]
        public decimal Peso { get; set; }

        [DataNames("mes")]
        public string Mes { get; set; }

        [DataNames("observacion")]
        public string Observacion { get; set; }

        // Se usa solo para guardar el monto de la compra del garron.

        [DataNames("montocompra")]
        public decimal MontoCompra { get; set; }


    }
}