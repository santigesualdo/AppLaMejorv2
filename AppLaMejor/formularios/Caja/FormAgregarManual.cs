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
        public Producto product = new Producto();
        public string codigomanual;
        public FormAgregarManual()
        {
            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();         
            ApplicationLookAndFeel.ApplyThemeToAll(this);
            
            tbCodigo.Focus();
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            if (tbCodigo.Text.Length == 6)
            {
                ProcesarBarra(tbCodigo.Text);

            }
        }

        private void ProcesarBarra(string text)
        {
           

            // Obtenemos producto por plu
            product = controlmanager.FuncionesVentas.GetProductoByCode(text);

            // Sino encuentra producto, sale
            if (product == null)
            {
                MessageBox.Show("No se encontro PLU de Producto. Verificar codigo de barra.");
                //MyTextTimer.TStart("No se encontro PLU de Producto. Verificar codigo de barra.", statusStrip1, tsslMensaje);
                return;
            }

            
            // Nueva sub-venta, ventadetalle
            //VentaDetalle vd = new VentaDetalle();
            //vd.Monto = montoTicket;
            //vd.Peso = FuncionesProductos.GetPesoProductoPrecio(montoTicket, product);
            //vd.idUsuario = 1;
            //vd.Producto = product;

            // Agregamos a la lista y mostramos en grid
            //listDetalleVentas.Add(vd);

            //currentVentasDetalle.Rows.Add(vd.Producto.DescripcionLarga, "$ " + vd.Monto, vd.Peso.ToString() + " kg.");
            lblDescripcion.Text = product.DescripcionLarga;
            tbCantidad.Focus();
            //tbPrecio.Text = vd.Monto;

            //labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCantidad_Leave(object sender, EventArgs e)
        {
            if (tbCantidad.Text.Length > 0)
            {
                lblCantidad.Text = tbCantidad.Text + " kg.";
                tbPrecio.Text = (Convert.ToDecimal(tbCantidad.Text) * product.Precio).ToString("00.00");
                tbPrecio.Focus();
            }
        }

        private void tbPrecio_Leave(object sender, EventArgs e)
        {
            if (tbPrecio.Text.Length > 0)
            {
                if (Convert.ToDecimal(tbPrecio.Text) < 1000)
                    lblPrecio.Text = "$ " + tbPrecio.Text;
                else { MessageBox.Show("Consultar como operar aquí");
                        tbPrecio.Text = "0.00";
                    tbPrecio.Focus();
                        }
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string entero = "000";
            string decimales = "00";
            if (Convert.ToDecimal(tbPrecio.Text) < 1000 && Convert.ToDecimal(tbPrecio.Text) > 99)
            {
                entero = tbPrecio.Text.Substring(0, 3);
                decimales = tbPrecio.Text.Substring(4, 2);
            }
            else if (Convert.ToDecimal(tbPrecio.Text) < 100 && Convert.ToDecimal(tbPrecio.Text) > 9)
            {
                entero = "0" + tbPrecio.Text.Substring(0, 2);
                decimales = tbPrecio.Text.Substring(3, 2);
            }
            // Monto entero 3 posiciones desde posicion 7
            else if (Convert.ToDecimal(tbPrecio.Text) < 10)
            {
                entero = "00" + tbPrecio.Text.Substring(0, 1);
                decimales = tbPrecio.Text.Substring(2, 2);
            }
            // Monto entero 3 posiciones desde posicion 10
           
            // Monto concatenado en string y operatoria para obtener decimal de 3 posiciones
            string monto = entero + decimales + "0";


            codigomanual = "2" + tbCodigo.Text + monto;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    }