using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class TipoPrecio
    {
        [DataNames("id")]
        public int Id { get; set; }

        [DataNames("descripcion")]
        public string Descripcion { get; set; }
    }
}
