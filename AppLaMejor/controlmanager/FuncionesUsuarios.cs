using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLaMejor.entidades;
using AppLaMejor.datamanager;
using System.Data;

namespace AppLaMejor.controlmanager
{
    public class FuncionesUsuarios
    {
        public static List<Modulo> ObtenerModulosPorUsuario(int idUsuarioSelected)
        {
            string consulta = QueryManager.Instance().GetModulosPorUsuario(idUsuarioSelected);
            DataTable tableModulos = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Modulo> dnmU = new DataNamesMapper<Modulo>();
            return dnmU.Map(tableModulos).ToList();
        }

        public static List<Modulo> ObtenerModulosFaltantesPorUsuario(int idUsuarioSelected)
        {
            string consulta = QueryManager.Instance().GetModulosFaltantesPorUsuario(idUsuarioSelected);
            DataTable tableModulos = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Modulo> dnmU = new DataNamesMapper<Modulo>();
            return dnmU.Map(tableModulos).ToList();
        }

        public static Usuario ObtenerUsuario(int idUsuarioSelected)
        {
            string consulta = QueryManager.Instance().GetUsuario(idUsuarioSelected);
            DataTable tableUsuario = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Usuario> dnmU = new DataNamesMapper<Usuario>();
            return dnmU.Map(tableUsuario).ToList().First();
        }
    }
}
