using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class OperacionProveedor : BaseEntity
    {

        [DataNames("tipo_operacion")]
        public TipoOperacion tipoOperacion { get; set; }

        [DataNames("proveedor")]
        public Proveedor proveedor { get; set; }

        [DataNames("fecha")]
        public DateTime Fecha { get; set; }

    }
}
