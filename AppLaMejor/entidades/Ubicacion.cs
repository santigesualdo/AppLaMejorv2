using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Ubicacion : BaseEntity
    {

        [DataNames("id_ubicacion_tipo")]
        public TipoUbicacion TipoUbicacion { get; set; }

        [DataNames("descripcion")]
        public string Descripcion { get; set; }

    }
}
