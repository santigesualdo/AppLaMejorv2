using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Medida
    {
        [DataNames("Id")]
        public int Id { get; set; }

        [DataNames("Descripcion")]
        public string Descripcion { get; set; }
    }
}
