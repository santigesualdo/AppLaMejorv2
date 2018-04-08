using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Operacion : BaseEntity
    {

        [DataNames("tipo_operacion")]
        public TipoOperacion tipoOperacion { get; set; }

        //[DataNames("venta")]
        //public Venta venta { get; set; }

        //se deja id_cliente_cuenta para que no se rompa en el sql y para usar la misma clase en el proyecto
        [DataNames("cliente")]
        public Cliente cliente { get; set; }

        //[DataNames("mov_cuenta")]
        //public MovimientoCuenta movCuenta { get; set; }

        [DataNames("fecha")]
        public DateTime Fecha { get; set; }

    }
}
