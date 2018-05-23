using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Compras
{
    public partial class FormCompras : Form
    {
        DataTable dataTableCompras;

        public FormCompras()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void Cargar()
        {
            dataTableCompras = FuncionesCompras.GetCompras();

            dataGridCompras.DataSource = dataTableCompras;
            dataGridCompras.AllowUserToAddRows = false;
            dataGridCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridCompras.Columns.Count; i++)
            {
                string name = dataGridCompras.Columns[i].Name;
                if (name.Equals("id") || name.Equals("usuario") || name.Equals("fecha_baja"))
                {
                    dataGridCompras.Columns[i].Visible = false;
                    continue;
                }

                dataGridCompras.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            ApplicationLookAndFeel.ApplyTheme(dataGridCompras);
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComprasPorProveedor(DataGridView dataGridVentas, string proveedor)
        {
            //(dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;


            // Aplicar filtro a data grid por texto en PLU
            if (!proveedor.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(proveedor)))
                {
                    filter.Append("Proveedor Like '%" + proveedor + "%'");
                    (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void ComprasPorDescripcion(DataGridView datagrid, string descrip)
        {
            //(dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

            // Aplicar filtro a data grid por texto en PLU
            if (!descrip.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(descrip)))
                {
                    filter.Append("descripcion Like '%" + descrip + "%'");
                    (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void CompraEntreMontos(DataGridView datagrid, decimal montoDesde, decimal montoHasta)
        {
            // Aplicar filtro a data grid por texto en PLU
            (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            StringBuilder filter = new StringBuilder();
            filter.Append(" Total >= " + montoDesde + " AND Total <= " + montoHasta);
            (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();

        }

        private void CompraEntreFechas(DataGridView datagrid, DateTime fechaDesde, DateTime fechaHasta)
        {
            // Aplicar filtro a data grid por texto en PLU
            (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            StringBuilder filter = new StringBuilder();

            string fDesde = fechaDesde.ToString("yyyy-MM-dd");
            string fHasta = fechaHasta.ToString("yyyy-MM-dd");

            filter.Append(" Fecha  >=  #" + fDesde + "# AND Fecha<=#" + fHasta + "#");

            (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
            else
                ComprasPorDescripcion(dataGridCompras, text);
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            // Termino de seleccionar la fecha
            // Ahora validar que la fecha de dtp2 sea mayor a dtp1
            // Luego buscar por filtro

            DateTime fDesde = DateTime.Parse(dtp1.Value.ToString("yyyy-MM-dd"));
            DateTime fHasta = DateTime.Parse(dtp2.Value.ToString("yyyy-MM-dd"));

            if (fDesde > fHasta)
            {
                MyTextTimer.TStartFade("La fecha desde no puede ser mayor a la fecha hasta: FechaDesde: " + fDesde.ToString() + " - FechHasta: " + fHasta.ToString(), this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                return;
            }

            CompraEntreFechas(dataGridCompras, fDesde, fHasta.AddDays(1));

        }

        private void textMontoHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                decimal montoDesde, montoHasta = decimal.Zero;

                if (!decimal.TryParse(textMontoDesde.Text, out montoDesde) || montoDesde < 0)
                {
                    MyTextTimer.TStartFade("El monto inicial indicado es incorrecto, intente nuevamente.", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                    return;
                }

                if (!decimal.TryParse(textMontoHasta.Text, out montoHasta) || montoHasta < 0)
                {
                    MyTextTimer.TStartFade("El monto final indicado es incorrecto, intente nuevamente.", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                    return;
                }


                CompraEntreMontos(dataGridCompras, montoDesde, montoHasta);
            }
        }

        private void limpiarFiltros()
        {
            textMontoDesde.Text = string.Empty;
            textMontoHasta.Text = string.Empty;
            (dataGridCompras.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        private void textBoxProveedorFilter_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
            else
                ComprasPorProveedor(dataGridCompras, text);

        }

        private void textMontoDesde_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
        }

        private void textMontoHasta_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
        }
    }
}
