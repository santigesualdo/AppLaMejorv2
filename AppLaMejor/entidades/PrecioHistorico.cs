using AppLaMejor.datamanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLaMejor.entidades
{
    public class PrecioHistorico : BaseEntity
    {

        [DataNames("Precio")]
        public decimal Precio { get; set; }

        [DataNames("Producto")]
        public Producto Producto { get; set; }

        [DataNames("FechaDesde")]
        public DateTime Desde { get; set; }

        
        private Nullable<DateTime> hasta;

        [DataNames("FechaHasta")]
        public Nullable<DateTime> Hasta
        {
            get
            {
                return hasta.HasValue ? (DateTime?)hasta : null;
            }
            set { hasta = value; }
        }
    }
}
