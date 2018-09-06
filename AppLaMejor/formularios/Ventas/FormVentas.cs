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
using AppLaMejor.formularios.Util;

namespace AppLaMejor.formularios
{
    public partial class FormVentas : Form
    {
        DataTable dataTableVentas, dataTableDatosCliente, dataTableVentaParaDetalle;
        //List<Venta> listVentas;
        List<VentaDetalle> listDetalleVentas;
        int index;
        decimal cantidad, precio;
        string tipo;
        public int idCliente;
       // public int idProveedor;
      //  public int idOperacion;
        public int idVenta;
       // public int idCompra;
       // List<Venta> listVentas = new List<Venta>();

        public FormVentas()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            ApplicationLookAndFeel.ApplyThemeToChild(button3);
        }

        public void Cargar()
        {
            dataTableVentas = FuncionesVentas.GetVentas();
            //listVentas = FuncionesVentas.FillVentas(dataTableVentas);

            dataGridVentas.DataSource = dataTableVentas;
            dataGridVentas.AllowUserToAddRows = false;
            dataGridVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridVentas.Columns.Count; i++)
            {
                string name = dataGridVentas.Columns[i].Name;
                if (name.Equals("id") || name.Equals("usuario")  || name.Equals("fecha_baja"))
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
            filter.Append(" MontoTotal >= " + montoDesde + " AND MontoTotal <= " + montoHasta );
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

        private void textDescripcion_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
            else
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

        private void textBoxPluFilter_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text.Equals("") || text.Equals(string.Empty))
                limpiarFiltros();
            else
                VentasPorPlu(dataGridVentas, text);

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

        private void dataGridVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridVentas.Rows.Count > 1)
            {
              //  if (tipo.Equals("Cliente"))
                {
                    //int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridVentas);
                    //Venta ventaSelected = listVentas.First(s => s.Id == i);
                    //idOperacion = opSelected.Id;
                    // idVenta = 9;

                    //int j = FuncionesGlobales.obtenerIndexClienteDeListFromGrid(dataGridVentas);
                    //idCliente = j;

                    int k = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridVentas);
                    idVenta = k;

                    CargarVentaParaDetalle(k);
                }

                //

                panel1.Visible = true;
            }
            else MessageBox.Show("No hay ventas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //modificar venta

            FormMessageBox dialog = new FormMessageBox();
            if (ValidarModificacion())
            {
                if (dialog.ShowConfirmationDialog("¿Desea Modificar la venta?"))
                {
                    if (ConfirmarModificacion())
                    {
                        MyTextTimer.TStartFade("Modificación confirmada. ", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                        limpiar();
                        panel1.Visible = false;
                        Cargar();
                    }
                    else
                    {
                        MyTextTimer.TStartFade("No se confirmo la modificación. Intente nuevamente.", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                    }
                }
            }


            //anular venta \r\n 
            //FormMessageBox dialog = new FormMessageBox();
            //if (ValidarAnulacion())
            //{
            //    if (dialog.ShowConfirmationDialog("¿Desea Anular la venta?"))
            //    {
            //        if (ConfirmarAnulacion())
            //        {
            //            MyTextTimer.TStartFade("Anulación confirmada. ", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
            //            Cargar();
            //        }
            //        else
            //        {
            //            MyTextTimer.TStartFade("No se confirmo la Anulación. Intente nuevamente.", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
            //        }
            //    }
            //}

            limpiar();
        }

        private bool ValidarModificacion()
        {

            listDetalleVentas = new List<VentaDetalle>();
            
            for (int i = 0; i < dgvVentaParaDetalle.Rows.Count; i++)
            {
                VentaDetalle vd = new VentaDetalle();
                vd.Id = (int)dgvVentaParaDetalle[11, i].Value;
                vd.Peso = (decimal)dgvVentaParaDetalle[8, i].Value;
                vd.Monto = (decimal)dgvVentaParaDetalle[10, i].Value;
                listDetalleVentas.Add(vd);
            }
            return true;
        }

        private bool ConfirmarModificacion()
        {
            if (FuncionesVentas.AlterVentaMayorista(listDetalleVentas, idVenta))
            {
                //crRemito scr = new crRemito();
                //FormReportes fr = new FormReportes(scr);
                //fr.ShowDialog();

                MyTextTimer.TStartFade("Se modificó venta  correctamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);

                listDetalleVentas.Clear();
                Cargar();
            }
            else
            {
                MyTextTimer.TStartFade("Fallo la nueva venta. Intente nuevamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
            }

            return true;
        }

        private bool ValidarAnulacion()
        {
            return true;
        }

        private bool ConfirmarAnulacion()
        {
            return true;
        }

        private void dgvVentaParaDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //qqq

            plModificaVenta.Visible = true;

            index = dgvVentaParaDetalle.CurrentRow.Index;
            
            tbPeso.Text = dgvVentaParaDetalle[8, index].Value.ToString();
            tbPrecio.Text = dgvVentaParaDetalle[9, index].Value.ToString();
            tbMonto.Text = dgvVentaParaDetalle[10, index].Value.ToString();

            lblDescripcionProducto.Text = dgvVentaParaDetalle[7, index].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            plModificaVenta.Visible = false;
            lblDescripcionProducto.Text = "";
            tbPeso.Clear();
            tbPrecio.Clear();
            tbMonto.Clear();
        }

        private void dgvVentaParaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPrecio.Focus();
            }
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbMonto.Focus();
            }
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button2.Focus();
            }
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbPeso_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbPeso_Leave(object sender, EventArgs e)
        {
            if (tbPeso != null)
            {
                TextBox t = (TextBox)sender;
                string cantidadStr = t.Text;
                decimal.TryParse(cantidadStr, out cantidad);
                tbMonto.Text = Math.Round((Convert.ToDecimal(tbPrecio.Text) * cantidad), 2).ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvVentaParaDetalle[8, index].Value = tbPeso.Text;

            dgvVentaParaDetalle[9, index].Value = tbPrecio.Text;

            dgvVentaParaDetalle[10, index].Value = tbMonto.Text;

      
            limpiar();
        }

        private void tbPrecio_Leave(object sender, EventArgs e)
        {
            if (tbPrecio != null)
            {

                TextBox t = (TextBox)sender;
                string precioStr = t.Text;
                decimal.TryParse(precioStr, out precio);
                tbMonto.Text = Math.Round(precio * (Convert.ToDecimal(tbPeso.Text)), 2).ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            limpiar();
        }




        public void CargarVentaParaDetalle(int id)
        {
            dataTableDatosCliente = FuncionesVentas.GetVentas(id);
            dgvDatosCliente.DataSource = dataTableDatosCliente;
            dgvDatosCliente.AllowUserToAddRows = false;
            dgvDatosCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dgvDatosCliente.Columns.Count; i++)
            {
               // lblDatosCliente.Text += dataTableVentaParaDetalle.Columns[5].ToString() + " ";

                string name = dgvDatosCliente.Columns[i].Name;
                if (name.Equals("id") || 
                    name.Equals("usuario") || 
                    name.Equals("Descripcion") ||
                    name.Equals("Fecha") ||
                    name.Equals("MontoTotal") ||
                    name.Equals("fecha_baja"))
                {
                    dgvDatosCliente.Columns[i].Visible = false;
                    continue;
                }

                dgvDatosCliente.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            dataTableVentaParaDetalle = FuncionesVentas.GetVentasDetalle(id);
            dgvVentaParaDetalle.DataSource = dataTableVentaParaDetalle;
            dgvVentaParaDetalle.AllowUserToAddRows = false;
            dgvVentaParaDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dgvVentaParaDetalle.Columns.Count; i++)
            {
                // lblDatosCliente.Text += dataTableVentaParaDetalle.Columns[5].ToString() + " ";

                string name = dgvVentaParaDetalle.Columns[i].Name;
                if (name.Equals("id") ||
                    name.Equals("TipoVenta") ||
                    name.Equals("MontoTotal") ||
                    name.Equals("Fecha") ||
                    name.Equals("usuario") ||
                    name.Equals("id_vd") ||
                    name.Equals("fecha_baja"))
                {
                    dgvVentaParaDetalle.Columns[i].Visible = false;
                    continue;
                }

                dgvVentaParaDetalle.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }



        }
    }
}
