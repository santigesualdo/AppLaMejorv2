﻿using System;
using System.Collections.Generic;
using AppLaMejor.datamanager;
using System.ComponentModel.DataAnnotations;

namespace AppLaMejor.entidades
{
    public class Cliente : BaseEntity
    {
        [DataNames("CodCliente")]
        [Required(ErrorMessage = "CodCliente es informacion obligatoria. ")]
        public string CodCliente { get; set; }

        [DataNames("RazonSocial")]
        [Required(ErrorMessage = "RazonSocial es informacion obligatoria. ")]
        public string RazonSocial { get; set; }

        [DataNames("Domicilio")]
        public string Domicilio { get; set; }

        [DataNames("Localidad")]
        public string Localidad { get; set; }

        [DataNames("TipoCliente")]
        [Required(ErrorMessage = "TipoCliente es informacion obligatoria. ")]
        public TipoCliente TipoCliente{ get; set; }

        [DataNames("Iva")]
        public string Iva { get; set; }

        [DataNames("Cuit")]
        public string Cuit { get; set; }

        [DataNames("NombreResponsable")]
        public string NombreResponsable { get; set; }

        [DataNames("NombreLocal")]
        public string NombreLocal { get; set; }

        [DataNames("Telefono")]
        public string Telefono { get; set; }

        [DataNames("FechaDesde")]
        public DateTime FechaDesde { get; set; }

        /* No se trae desde la base a menos que haga falta */
        public List<Cuenta> Cuentas { get; set; }
    }

}
