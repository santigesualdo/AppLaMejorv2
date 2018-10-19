using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using AppLaMejor.entidades;
using AppLaMejor.datamanager;
using AppLaMejor.stylemanager;
using AppLaMejor.controlmanager;

namespace AppLaMejor.formularios.Reports
{
    public partial class FormModalReportes : Form
    {
        // TODO: Validar que todos los botones tengan la info que requieren cuando se les hace click.
        public Producto product = new Producto();
        public decimal cantidad;
        public decimal precioFinal;
        public string codigomanual;

        string tipo;

        public int idCliente;
        public int idProveedor;
        public int idOperacion;
        public int idVenta;
        public int idCompra;

        DataTable tableOperaciones;
        List<Operacion> listOps = new List<Operacion>();
        List<OperacionProveedor> listOpsPro = new List<OperacionProveedor>();
        public FormModalReportes(string type)
        {
            tipo = type;
            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            cargar();
        }



        private void ProcesarBarra(string text)
        {
            // Obtenemos producto por plu
            product = controlmanager.FuncionesVentas.GetProductoByCode(text);

            // Sino encuentra producto, sale
            if (product == null)
            {
                MessageBox.Show("No se encontro PLU de Producto. Verificar codigo de barra.");
                return;
            }
            tbNombre.Focus();
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!tbNombre.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(tbNombre.Text)))
                {
                    filter.Append("razon_social Like '%" + tbNombre.Text + "%'");
                    (dgvOperaciones.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dgvOperaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            //if (tbCantidad.Text.Length > 0)
            //{
            //    precioFinal = Convert.ToDecimal(tbCantidad.Text) * product.Precio;
            //    tbPrecio.Text = precioFinal.ToString("00.00");
            //    cantidad = Convert.ToDecimal(tbCantidad.Text);
            //    tbPrecio.Focus();
            //}
        }

        private void tbPrecio_Leave(object sender, EventArgs e)
        {
            if (tbPrecio.Text.Length > 0)
            {
                tbPrecioFinal.Text = tbPrecio.Text;
                precioFinal = Convert.ToDecimal(tbPrecioFinal.Text);
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            seleccionar();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        void cargar()
        {
            if (tipo.Equals("Resumen") 
                || tipo.Equals("MovClientes")
                || tipo.Equals("Detallado")
                || tipo.Equals("Detallado2")
                || tipo.Equals("MovProveedores"))
            {
                controlsPanel.Visible = false;
                controlsModalResumen.Visible = true;
                controlsModalResumen.Dock = DockStyle.Fill;
            }
            else

            {
                if (tipo.Equals("Cliente"))
                {
                    tableOperaciones = FuncionesOperaciones.fillOperaciones();
                    listOps = FuncionesOperaciones.listOperaciones(tableOperaciones);
                }
                else
                {
                    tableOperaciones = FuncionesOperaciones.fillOperacionesProveedores();
                    listOpsPro = FuncionesOperaciones.listOperacionesProveedores(tableOperaciones);
                }
            
            controlsModalResumen.Visible = false;
            controlsPanel.Visible = true;
            controlsPanel.Dock = DockStyle.Fill;

            
            dgvOperaciones.DataSource = tableOperaciones;
            dgvOperaciones.Columns[0].Visible = false;
            dgvOperaciones.Columns[2].Visible = false;
            dgvOperaciones.AutoResizeColumns();
            }

        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex != -1)
            {
                Producto prod = (Producto)combo.SelectedValue;
                product = prod;
                tbPrecio.Text = prod.Precio.ToString();
                tbNombre.Focus();
            }
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //    // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbProductos_Leave(object sender, EventArgs e)
        {

        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            tbPrecioFinal.Text = tbPrecio.Text;
        }



        void seleccionar()
        {
            if (tipo.Equals("Cliente"))
            {
                int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dgvOperaciones);
                Operacion opSelected = listOps.First(s => s.Id == i);
                idOperacion = opSelected.Id;
               // idVenta = 9;

                int j = FuncionesGlobales.obtenerIndexClienteDeListFromGrid(dgvOperaciones);
                idCliente = j;

                int k = FuncionesGlobales.obtenerIndexVentaDeListFromGrid(dgvOperaciones);
                idVenta = k;
            }
            else

            {
                int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dgvOperaciones);
                OperacionProveedor opSelected = listOpsPro.First(s => s.Id == i);
                idOperacion = opSelected.Id;
                //idCompra= 9;

                int j = FuncionesGlobales.obtenerIndexProveedorDeListFromGrid(dgvOperaciones);
                idProveedor = j;

                int k = FuncionesGlobales.obtenerIndexCompraDeListFromGrid(dgvOperaciones);
                idCompra= k;

            }

        }

        private void dgvOperaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOperaciones.Rows.Count > 1)
            {
                seleccionar();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("No hay remitos");
        }

        private void tbNombre_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }


        //BOTONES DEL MODAL RESUMEN
        private void btFiltroFecha_Click(object sender, EventArgs e)
        {
            string d = dtpDesde.Value.ToString("yyyy-MM-dd");
            string h = dtpHasta.Value.ToString("yyyy-MM-dd");

            if (tipo.Equals("Resumen"))
                FuncionesReportes.informeListadoVentas(d, h);
            else if (tipo.Equals("MovClientes"))
                FuncionesReportes.informeListadoMovCuentas(d, h);
            else if (tipo.Equals("Detallado"))
                FuncionesReportes.informeListadoVentaDetalle(d, h);
            else if (tipo.Equals("Detallado2"))
            {
                FuncionesReportes.informeListadoVentaDetalle(d, h);
                FuncionesReportes.informeVistaVentaDetalleConMovimientos(d, h);
                
            }
            else if (tipo.Equals("MovProveedores"))
                FuncionesReportes.informeListadoMovCuentasProveedores(d, h);
            DialogResult = DialogResult.OK;
                this.Close();
        }
    }
}