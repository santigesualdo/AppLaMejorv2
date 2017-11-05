using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace AppLaMejor.controlmanager
{
    public class FuncionesGlobales
    {
        public static int obtenerIndexDeListFromGrid(DataGridView grid)
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            return dr.Field<int>("id");
        }
    }
}
