using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Cuenta : BaseEntity
    {
        [DataNames("cbu")]
        public string Cbu { get; set; }

        [DataNames("nro_cuenta")]
        public string Numerocuenta { get; set; }

        [DataNames("saldo_actual")]
        public decimal SaldoActual { get; set; }

        private Nullable<DateTime> fechaUltimaActualizacion;

        [DataNames("fecha_updated")] 
        public Nullable<DateTime> FechaUltimaActualizacion
        {
            get { return fechaUltimaActualizacion.HasValue ? (DateTime?)fechaUltimaActualizacion : null; }
            set { fechaUltimaActualizacion = value; }
        }
    }
}
