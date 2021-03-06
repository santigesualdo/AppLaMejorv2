﻿using System;
using System.Data;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;

namespace AppLaMejor.controlmanager
{
    public class FuncionesMovCuentas
    {
        //clientes
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
        public static DataTable fillCuentasByCliente(int idCliente)
        {
            string consulta = QueryManager.Instance().GetCuentas(idCliente); 
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
        public static bool insertarMovimiento(MovimientoCuenta movCuenta1)
        {
            string consulta = QueryManager.Instance().InsertMovCuenta(movCuenta1);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }

        public static int GetNextIdMovCuenta()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextMovCuentaId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            return Int32.Parse(result.Rows[0][0].ToString());
        }

        //proveedores
        public static DataTable fillMovCuentasProveedores()
        {
            string consulta = QueryManager.Instance().GetMovCuentasProveedores(); //QueryManager.Instance().GetMovCuentas();
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }
        public static DataTable fillPaginaProveedores(int lastProv, int ini, int reg)
        {
            string consulta = QueryManager.Instance().GetMovCuentasProveedor(lastProv, ini, reg);
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }
        public static DataTable fillPaginaProveedoresBetweenDates(int lastProv, int ini, int reg, string fdesde, string fhasta)
        {
            string consulta = QueryManager.Instance().GetMovCuentasProveedorBetweenDates(lastProv, ini, reg, fdesde, fhasta);
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }
        public static DataTable fillCuentasByProveedor(int idProveedor)
        {
            string consulta = QueryManager.Instance().GetCuentasProveedores(idProveedor);
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
        }
        public static int contarRegistrosProveedores(int idProveedor)
        {
            string consulta = QueryManager.Instance().GetMovCuentasProveedorContar(idProveedor);
            DataTable dtTotalRegistros = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            //cuento cuantos movCuentas tiene el cliente
            return Convert.ToInt32(dtTotalRegistros.Rows[0][0].ToString());
        }
        public static int contarRegistrosProveedoresBetweenDates(int idProveedor, string fdesde, string fhasta)
        {
            string consulta = QueryManager.Instance().GetMovCuentasProveedoresContarBetweenDates(idProveedor, fdesde, fhasta);
            DataTable dtTotalRegistros = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);

            //cuento cuantos movCuentas tiene el cliente
            return Convert.ToInt32(dtTotalRegistros.Rows[0][0].ToString());
        }
        public static bool insertarMovimientoProveedor(MovimientoCuenta movCuenta1)
        {
            string consulta = QueryManager.Instance().InsertMovCuentaProveedor(movCuenta1);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
        public static bool insertarMovimientoProveedor(MovimientoCuentaProveedor movCuenta)
        {
            string consulta = QueryManager.Instance().InsertMovCuentaProveedor(movCuenta);
            return QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consulta);
        }
    }
}
