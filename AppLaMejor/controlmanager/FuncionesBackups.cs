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
    public class FuncionesBackups
    {
        public static DataTable fillBackups()
        {
            return QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetBackupsData());
        }
        public static List<Backup> listBackups(DataTable table)
        {
            DataNamesMapper<Backup> mapper = new DataNamesMapper<Backup>();
            return mapper.Map(table).ToList();
        }
    }
        
}
