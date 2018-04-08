using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;

namespace AppLaMejor.formularios
{
    public class FuncionesOperaciones
    {

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

    }
}
