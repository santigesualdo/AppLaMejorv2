using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using AppLaMejor.datamanager;

namespace AppLaMejor.controlmanager
{
    public class FuncionesGlobales
    {
        // En los datagrid cuando se selecciona un item.. es necesaria esta funcion, por que si la grilla esta filtrada, toma cualquier index
        public static int obtenerIndexDeListFromGrid(DataGridView grid)
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            return dr.Field<int>("id");
        }

        // Se detecta si una aplicacion esta abierta.
        public static bool IsProccessOpen(string name)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }

        // Obtiene un parametro desde la bd.
        public static string GetParametro(string name)
        {
            DataTable dt = QueryManager.Instance().GetTableResults(ConnecionBD.Instance().Connection, QueryManager.Instance().GetParametroByName(name));
            return dt.Rows[0].Field<string>("value");
        }
    }
}
