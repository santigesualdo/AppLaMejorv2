using System;
using AppLaMejor.datamanager;
using System.ComponentModel.DataAnnotations;

namespace AppLaMejor.entidades
{
    public class Cuenta : BaseEntity
    {
        [Required(ErrorMessage = "CBU es informacion obligatoria. ")]
        [DataNames("cbu")]
        public string Cbu { get; set; }

        [DataNames("descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Banco es informacion obligatoria. ")]
        [DataNames("banco")]
        public Banco Banco { get; set; }


        private Nullable<DateTime> fechaUltimaActualizacion;
        [DataNames("fecha_updated")] 
        public Nullable<DateTime> FechaUltimaActualizacion
        {
            get
            {
                return fechaUltimaActualizacion.HasValue ? (DateTime?)fechaUltimaActualizacion : null;
            }
            set { fechaUltimaActualizacion = value; }
        }
    }
}
