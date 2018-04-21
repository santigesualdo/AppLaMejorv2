using AppLaMejor.datamanager;
using System;

namespace AppLaMejor.entidades
{
    public class GarronDeposte : BaseEntity
    {
        [DataNames("peso")]
        public decimal Peso { get; set; }

        [DataNames("fecha")]
        public DateTime Fecha { get; set; }

        [DataNames("id_producto")]
        public Producto Producto { get; set; }

        [DataNames("id_garron")]
        public Garron Garron { get; set; }

        // Utilizado para deposte
        public Ubicacion Destino { get; set; }

        public bool yaDepostado { get; set; }

        public decimal Precio { get; set; }
    }
}
