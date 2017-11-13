using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class MovimientoCuenta : BaseEntity
    {        
        [DataNames("vob")]
        public char Vob { get; set; }

        //se deja id_cliente_cuenta para que no se rompa en el sql y para usar la misma clase en el proyecto
        [DataNames("ïd_cuenta")]
        public Cuenta Cuenta { get; set; }

        [DataNames("id_movimiento_tipo")]
        public TipoMovimiento TipoMovimiento { get; set; }

        [DataNames("monto")]
        public decimal Monto { get; set; }

        private DateTime fecha;
        [DataNames("fecha")]
        public DateTime Fecha 
        {
            get { return fecha ; }
            set { fecha = value; }
        }

        [DataNames("cobrado")]
        public char Cobrado { get; set; }
                
    }
}
