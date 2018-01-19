
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using System.Data;
using System.Windows.Forms;


namespace AppLaMejor.controlmanager
{
    public class FuncionesPrecios
    {
        public static DataTable fillHistoricos()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetPrecioHistoricoData());
        }

        public static List<PrecioHistorico> listHistoricos(DataTable tableHistorico)
        {
            DataNamesMapper<PrecioHistorico> mapper = new DataNamesMapper<PrecioHistorico>();
            return mapper.Map(tableHistorico).ToList();
        }

        public static List<PrecioHistorico> fillHistoricoByIdProducto(int idProducto)
        {
            DataTable dt = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetPrecioHistoricoByProducto(idProducto));
            DataNamesMapper<PrecioHistorico> mapper = new DataNamesMapper<PrecioHistorico>();
            return mapper.Map(dt).ToList();
        }

        public static DataTable GetPreciosToExport()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetPreciosToExport());
        }
    }
}