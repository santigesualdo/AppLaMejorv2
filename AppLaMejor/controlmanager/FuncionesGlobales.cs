using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using AppLaMejor.datamanager;
using System.Globalization;
using AppLaMejor.stylemanager;
using AppLaMejor.entidades;

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
        private static bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }
        public static void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!isNumber(e.KeyChar, textbox.Text))
                e.Handled = true;
        }
        public static void KeyPressIntegerTextField(object sender, KeyPressEventArgs e)
        {
            string text = ((TextBox)sender).ToString();
            for (int i = 0; i < text.Length; i++)
            {
                int c = text[i];
                if (c < '0' || c > '9')
                {
                    text = text.Remove(i, 1);
                }
            }
        }
        public static Label StyleLabel(string name)
        {
            Label label = new Label();
            label.Text = name;
            label.Font = StyleManager.Instance().GetCurrentStyle().MainFontSmall;
            label.Dock = DockStyle.Fill;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Margin = new System.Windows.Forms.Padding(0);
            label.Name = name;
            label.Size = new System.Drawing.Size(320, 18);
            label.TabIndex = 1;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }		
		public static int obtenerIndexClienteDeListFromGrid(DataGridView grid)													  
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            return dr.Field<int>("id_cliente");				 
        }
        public static int obtenerIndexVentaDeListFromGrid(DataGridView grid)													  
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            int r = dr.Field<int>("id_venta");
            return r;
        }

        public static int obtenerIndexCompraDeListFromGrid(DataGridView grid)
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            int r = dr.Field<int>("id_compra");
            return r;
        }
        public static int obtenerIndexProveedorDeListFromGrid(DataGridView grid)
        {
            // para que funcione la query tiene que tener un campo "id"
            BindingManagerBase bm = grid.BindingContext[grid.DataSource, grid.DataMember];
            DataRow dr = ((DataRowView)bm.Current).Row;
            return dr.Field<int>("id_proveedor");
        }



        public static void TextBoxLeaveOnEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("{TAB}");
            } 
        }

        public static Ubicacion ObtenerUbicacionEntrada()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetUbicacionEntrada();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Ubicacion> dtnm = new DataNamesMapper<Ubicacion>();
            return dtnm.Map(table).ToList().First();
        }

        public static Ubicacion ObtenerUbicacionSalida()
        {
            QueryManager manager = QueryManager.Instance();
            string consulta = manager.GetUbicacionSalida();
            DataTable table = manager.GetTableResults(ConnecionBD.Instance().Connection, consulta);
            DataNamesMapper<Ubicacion> dtnm = new DataNamesMapper<Ubicacion>();
            return dtnm.Map(table).ToList().First();
        }
    }
}
