﻿using AppLaMejor.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLaMejor.controlmanager
{
    static class VariablesGlobales
    {
        public static bool FormMovCuentas_activo = false;
        public static bool FormMovCuentas_comboCargado = false;
        public static int userIdLogueado;

        //operacion
        public static int idMovCuenta_VentaMay = 0;
        public static Cuenta Cuenta_VentaMay = new Cuenta();
    }
}
