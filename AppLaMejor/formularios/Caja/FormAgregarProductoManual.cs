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
    public partial class FormAgregarProductoManual : Form
    {
        public Producto selectedProducto;
        public decimal cantidad;
        public decimal precioFinal;
        public string codigomanual;

        bool selectable; //flag para ver si el item se puede comprar o no

        DataTable tableProductos;
        List<Producto> listProds = new List<Producto>();
        public FormAgregarProductoManual(List<VentaDetalle> listVentaDetalle)
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
                tbPrecio.Text = Math.Round((selectedProducto.Precio * cantidad),2).ToString();
                tbPrecioModificable.Text = selectedProducto.Precio.ToString();
            }
            //twoDec = Math.Round(val, 2)
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
            tableProductos = FuncionesProductos.fillProductosVentaMayoristaSinTraba();
            listProds = FuncionesProductos.listProductos(tableProductos);

            if (listVentaDetalle.Count > 0)
            {
                List<Producto> listProdRemover = new List<Producto>();
                foreach (VentaDetalle vd in listVentaDetalle)
                {
                    if (vd.Producto == null) continue;
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
                combo.Text = selectedProducto.DescripcionBreve;
                tbPrecio.Text = selectedProducto.Precio.ToString();
                lCantidadMaxima.Text = "(Cantidad Maxima: " + selectedProducto.Cantidad.ToString() + ")";
                tbCantidad.Focus();
            }
        }

        private void tbCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //tbPrecioFinal.Focus();
                tbPrecioModificable.Focus();
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

        private void tbPrecioModificable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPrecioFinal.Text = Math.Round((Convert.ToDecimal(tbPrecioModificable.Text) * cantidad),2).ToString();
                
                tbPrecioFinal.Focus();
               
            }
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void tbPrecioModificable_Leave(object sender, EventArgs e)
        {
            //TB PARA MODIFICAR EL PRECIO UNITARIO
            tbPrecioFinal.Text = Math.Round((Convert.ToDecimal(tbPrecioModificable.Text) * cantidad),2).ToString();

            tbPrecioFinal.Focus();
        }

        private void cmbProductos_DrawItem(object sender, DrawItemEventArgs e)
        {
            //En el caso de que quiera usar en un futuro el DrawItem, tengo que cambiar el control de drawItem.Normal a OwnerAlgoFixed

            // Dibujo el fondo
            e.DrawBackground();

            // Obtengo el texto del item  
            string text = listProds[e.Index].DescripcionBreve;

            // Veo si en la descripción dice Comprar, pongo color ROJO, si está en negativo, pongo en ANARANJADO 
            Brush brush;
            if (listProds[e.Index].DescripcionBreve.Contains("COMPRAR"))
            {
                brush = Brushes.Red;


            }
            else if (listProds[e.Index].DescripcionBreve.Contains("-"))  
            {
                brush = Brushes.Orange;
                
            }
            else
            {
                brush = Brushes.White;
            }

            // Dibujo el texto
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.Text.Contains("COMPRAR"))
                
            {
                combo.SelectedIndex = -1;
                tbPrecio.Clear();
                MessageBox.Show("No se puede seleccionar, hace falta comprar este producto");
                combo.DroppedDown = true;
            }
        }
    }
}