﻿using System;
using System.Collections.Generic;
using System.Text;
using AppLaMejor.datamanager;

namespace AppLaMejor.entidades
{
    public class Cliente : BaseEntity
    {
        [DataNames("RazonSocial")]
        public string RazonSocial { get; set; }

        [DataNames("Domicilio")]
        public string Domicilio { get; set; }

        [DataNames("Localidad")]
        public string Localidad { get; set; }

        [DataNames("TipoCliente")]
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
