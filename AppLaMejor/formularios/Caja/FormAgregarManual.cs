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

namespace AppLaMejor.formularios.Caja
{
    public partial class FormAgregarManual : Form
    {
        // TODO: VALIDACION que todos los botones tengan la info que requieren cuando se les hace click.
        public Producto product = new Producto();
        public decimal cantidad;
        public decimal precioFinal;
        public string codigomanual;

        DataTable tableProductos;
        List<Producto> listProds = new List<Producto>();
        public FormAgregarManual()
        {
            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            cargar();
            tbCodigo.Focus();
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
            cmbProductos.Text = product.DescripcionLarga;
            tbCantidad.Focus();
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            if (tbCantidad.Text.Length > 0)
            {
                precioFinal = Convert.ToDecimal(tbCantidad.Text) * product.Precio;
                tbPrecio.Text = precioFinal.ToString("00.00");
                cantidad = Convert.ToDecimal(tbCantidad.Text);
                tbPrecio.Focus();
            }
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
            DialogResult = DialogResult.OK;
            this.Close();
        }

        void cargar()
        {
            tableProductos = FuncionesProductos.fillProductos(3);
            listProds = FuncionesProductos.listProductos(tableProductos);
            BindingList<Producto> objects = new BindingList<Producto>(listProds);
            cmbProductos.ValueMember = null;
            cmbProductos.DisplayMember = "DescripcionBreve";
            cmbProductos.DataSource = objects;
            cmbProductos.SelectedIndex = -1;
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
                tbCantidad.Focus();
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

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            tbPrecioFinal.Text = tbPrecio.Text;
        }
    }
}