using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Backup
    {
        [DataNames("id")]
        public int Id { get; set; }
        [DataNames("descripcion")]
        public string Descripcion { get; set; }

        [DataNames("ubicacion")]
        public string ubicacion { get; set; }

        [DataNames("fecha")]
        public DateTime Fecha { get; set; }
    }
}
