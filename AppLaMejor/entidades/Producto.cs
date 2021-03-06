﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppLaMejor.entidades
{
    public class Producto : BaseEntity
    {
        [Required(ErrorMessage = "TipoProducto es informacion obligatoria. ")]
        [DataNames("TipoProducto")]
        public TipoProducto TipoProducto { get; set; }

        [Required(ErrorMessage = "CodigoBarra es informacion obligatoria. ")]
        [DataNames("CodigoBarra")]
        public string CodigoBarra{ get; set; }

        [Required(ErrorMessage = "Precio es informacion obligatoria. ")]
        [DataNames("Precio")]   
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "DescripcionBreve es informacion obligatoria. ")]
        [DataNames("DescripcionBreve")]
        public string DescripcionBreve { get; set; }

        [DataNames("Cantidad")]
        public decimal Cantidad { get; set; }

        // Peso entregado (solo se usa para Compras)
        public decimal CantidadEntregada { get; set; }

    }
}
