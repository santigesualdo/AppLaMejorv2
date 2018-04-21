using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.formularios.Util;

// Se pueden incluir en VentaMayorista todos los productos que son de tipo VENTA MAYORISTA 
// y se encuentran en salon de ventas. De lo contrario no se podran seleccionar.

namespace AppLaMejor.formularios.Caja
{
    public partial class FormAgregarManual : Form
    {
        public Producto selectedProducto;
        public decimal cantidad;
        public decimal precioFinal;
        public string codigomanual;

        DataTable tableProductos;
        List<Producto> listProds = new List<Producto>();
        public FormAgregarManual(List<VentaDetalle> listVentaDetalle)
        {
            selectedProducto = null;
            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            cargar(listVentaDetalle);
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {
            if (selectedProducto != null)
            {
                TextBox t = (TextBox)sender;
                string cantidadStr = t.Text;
                decimal.TryParse(cantidadStr, out cantidad);
                tbPrecio.Text = (selectedProducto.Precio * cantidad).ToString();
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            decimal precioFinalTextBox;
            
            if (!decimal.TryParse(tbPrecioFinal.Text, out precioFinalTextBox))
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("El precio ingresado no es correcto.");
                tbPrecioFinal.Focus();
                return;
            }

            precioFinal = precioFinalTextBox;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        void cargar(List<VentaDetalle> listVentaDetalle)
        {
            tableProductos = FuncionesProductos.fillProductosVentaMayoristaDeposito();
            listProds = FuncionesProductos.listProductos(tableProductos);

            if (listVentaDetalle.Count > 0)
            {
                List<Producto> listProdRemover = new List<Producto>();
                foreach (VentaDetalle vd in listVentaDetalle)
                {
                    foreach (Producto p in listProds)
                    {
                        if (p.Id.Equals(vd.Producto.Id))
                        {
                            p.Cantidad -= vd.Peso;
                            if (p.Cantidad.Equals(0))
                            {
                                listProdRemover.Add(p);
                            }
                        }
                    }
                }

                if (listProdRemover.Count > 0)
                {
                    for (int i = listProds.Count - 1; i >= 0; i--)
                    {
                        foreach (Producto rem in listProdRemover)
                        {
                            if (rem.Id.Equals(listProds[i].Id))
                                listProds.RemoveAt(i);
                        }
                    }
                }
            }

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
                selectedProducto = (Producto)combo.SelectedValue;
                tbPrecio.Text = selectedProducto.Precio.ToString();
                lCantidadMaxima.Text = "(Cantidad Maxima: " + selectedProducto.Cantidad.ToString() + ")";
                tbCantidad.Focus();
            }
        }

        private void tbCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPrecioFinal.Focus();
            }
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbPrecioFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            decimal cantidad;
            decimal.TryParse(text.Text, out cantidad);
            if (cantidad > selectedProducto.Cantidad)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowConfirmationDialog("La cantidad ingresada supera a la cantidad permitida.");
                tbCantidad.Focus();
            }
        }
    }
}