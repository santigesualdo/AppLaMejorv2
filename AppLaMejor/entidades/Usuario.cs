using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Usuario
    {
        [DataNames("id")]
        public int Id { get; set; }
        [DataNames("username")]
        public string UserName {get;set;}
        [DataNames("pass")]
        public string Pass { get; set; }
        [DataNames("nombre")]
        public string Nombre{ get; set;}
    }
}
