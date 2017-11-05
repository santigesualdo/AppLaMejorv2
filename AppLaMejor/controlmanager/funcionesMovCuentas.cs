﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;

namespace AppLaMejor.formularios.MovimientoCuentas
{
    public class FuncionesMovCuentas
    {
        public static DataTable fillMovCuentas()
        {
            string consulta = QueryManager.Instance().GetMovCuentas(); //QueryManager.Instance().GetMovCuentas();
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }
        public static DataTable fillPagina(int lastClient, int ini, int reg)
        {
            string consulta = QueryManager.Instance().GetMovCuentas(lastClient, ini, reg);
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }

        public static DataTable fillPaginaBetweenDates(int lastClient, int ini, int reg, string fdesde, string fhasta)
        {
            string consulta = QueryManager.Instance().GetMovCuentasBetweenDates(lastClient, ini, reg, fdesde, fhasta);
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }

        public static int contarRegistros(int idCliente)
        {
            string consulta = QueryManager.Instance().GetMovCuentasContar(idCliente);
            DataTable dtTotalRegistros = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            //cuento cuantos movCuentas tiene el cliente
            return Convert.ToInt32(dtTotalRegistros.Rows[0][0].ToString());
        }

        public static int contarRegistrosBetweenDates(int idCliente, string fdesde, string fhasta)
        {
            string consulta = QueryManager.Instance().GetMovCuentasContarBetweenDates(idCliente, fdesde, fhasta);
            DataTable dtTotalRegistros = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            //cuento cuantos movCuentas tiene el cliente
            return Convert.ToInt32(dtTotalRegistros.Rows[0][0].ToString());
        }

        public static void insertarMovimiento(MovimientoCuenta movCuenta1)
        {
            string consulta = QueryManager.Instance().InsertMovCuenta(movCuenta1);
            QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            consulta = QueryManager.Instance().ActualizaSaldo(movCuenta1.Cuenta);
            QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }

    }
}
