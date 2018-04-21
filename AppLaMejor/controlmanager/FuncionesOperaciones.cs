﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;

namespace AppLaMejor.controlmanager
{
    public class FuncionesOperaciones
    {
        //venta


        //movimiento cuentas

        public static Operacion operacionEnCurso(int idTipoOperacion)
        {

            Operacion newOperacion = new Operacion();
            TipoOperacion to = new TipoOperacion();

            to.Id = idTipoOperacion;
            VariablesGlobales.idOperacion = FuncionesVentas.GetNextIdOperacion();

            newOperacion.Id = VariablesGlobales.idOperacion;

            newOperacion.tipoOperacion = to;

            return newOperacion;

        }

        //reportes
        public static DataTable fillOperaciones()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetOperacionesData());
        }

        public static DataTable fillOperacionesProveedores()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetOperacionesProveedoresData());
        }

        public static List<Operacion> listOperaciones(DataTable table)
        {
            DataNamesMapper<Operacion> mapper = new DataNamesMapper<Operacion>();
            return mapper.Map(table).ToList();
        }

        public static List<OperacionProveedor> listOperacionesProveedores(DataTable table)
        {
            DataNamesMapper<OperacionProveedor> mapper = new DataNamesMapper<OperacionProveedor>();
            return mapper.Map(table).ToList();
        }
        public static int GetNextIdOperacion()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextOperacionId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (result.Rows[0][0].ToString().Length == 0)
                return 1;
            else return Int32.Parse(result.Rows[0][0].ToString());
        }

        public static int GetNextIdOperacionProveedor()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetNextOperacionProveedorId();
            DataTable result = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);

            if (result.Rows[0][0].ToString().Length == 0)
                return 1;
            else return Int32.Parse(result.Rows[0][0].ToString());
        }

    }
}
