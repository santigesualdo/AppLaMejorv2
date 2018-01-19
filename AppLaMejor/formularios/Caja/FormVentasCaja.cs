using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    public partial class FormVentasCaja : Form
    {
        DataTable dataTableVentas;
        List<Venta> listVentas;

        public FormVentasCaja()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        public void Cargar()
        {
            dataTableVentas = FuncionesVentas.GetVentas();
            listVentas = FuncionesVentas.FillVentas(dataTableVentas);

            dataGridVentas.DataSource = dataTableVentas;
            dataGridVentas.AllowUserToAddRows = false;
            dataGridVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridVentas.Columns.Count; i++)
            {
                string name = dataGridVentas.Columns[i].Name;
                if (name.Equals("id") || name.Equals("usuario") || name.Equals("fecha_baja"))
                {
                    dataGridVentas.Columns[i].Visible = false;
                    continue;
                }

                dataGridVentas.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            ApplicationLookAndFeel.ApplyTheme(dataGridVentas);
        }

        private void VentasPorPlu(DataGridView dataGridVentas, string plu)
        {
            //(dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;


            // Aplicar filtro a data grid por texto en PLU
            if (!plu.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(plu)))
                {
                    filter.Append("descripcion Like '%" + plu + "%'");
                    (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void VentasDelDia(DataGridView dataGridVentas)
        {

            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            StringBuilder filter = new StringBuilder();

            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string now2 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            filter.Append(" fecha >= #" + now + "# and fecha <= #" + now2 + "# ");
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();         
         
         //   (Date >= #" +
         //Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") +
         //"# And Date <= #" +
         //Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") +
         //"# ) ";
            
        }

        private void VentasPorDescripcion(DataGridView datagrid, string descrip)
        {
            //(dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

            // Aplicar filtro a data grid por texto en PLU
            if (!descrip.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(descrip)))
                {
                    filter.Append("descripcion Like '%" + descrip + "%'");
                    (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void VentasEntreMontos(DataGridView datagrid, decimal montoDesde, decimal montoHasta )
        {
            // Aplicar filtro a data grid por texto en PLU
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            StringBuilder filter = new StringBuilder();
            filter.Append(" monto_total >= '" + montoDesde + "' AND monto_total <= '"+ montoHasta +"'");
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();

        }

        private void VentasEntreFechas(DataGridView datagrid, DateTime fechaDesde, DateTime fechaHasta)
        {
            // Aplicar filtro a data grid por texto en PLU
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            StringBuilder filter = new StringBuilder();

            string fDesde = fechaDesde.ToString("yyyy-MM-dd");
            string fHasta = fechaHasta.ToString("yyyy-MM-dd");

            filter.Append(" fecha  >=  #" + fDesde + "# AND fecha<=#" + fHasta + "#");
            
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
        }

        private void VentasEntreCantidades(DataGridView datagrid, decimal pesoDesde, decimal pesoHasta)
        {
            //// Aplicar filtro a data grid por texto en PLU
            //(dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //StringBuilder filter = new StringBuilder();
            //filter.Append(" monto_total between '" + pesoDesde + "' AND '" + pesoHasta + "'");
            //(dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
        }

        private void bVentaDia_Click(object sender, EventArgs e)
        {
            VentasDelDia(dataGridVentas);
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            VentasPorDescripcion(dataGridVentas, text);
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

            VentasEntreFechas(dataGridVentas, fDesde, fHasta.AddDays(1));

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


                VentasEntreMontos(dataGridVentas, montoDesde, montoHasta);
            }
        }

        private void limpiarFiltros()
        {
            //filterTextBox.Text = string.Empty;
            //textDescripcion.Text = string.Empty;
            textMontoDesde.Text = string.Empty;
            textMontoHasta.Text = string.Empty;
            (dataGridVentas.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
