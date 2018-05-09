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
    public partial class FormAgregarGarronManual : Form
    {
        public Garron selectedGarron;
        public decimal precioFinal;
        List<VentaDetalle> listVentaDetalle;


        public FormAgregarGarronManual(List<VentaDetalle> list)
        {
            listVentaDetalle = list;
            Size actualSize = this.Size;
            this.Size = new Size(actualSize.Width, Screen.PrimaryScreen.Bounds.Height);
            InitializeComponent();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbPrecioFinal.Text, out precioFinal) && selectedGarron != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Debe seleccionar un garron valido con su respectivo precio.");
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Desea descartar los cambios?")){
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void tbPrecioFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void btManual_Click(object sender, EventArgs e)
        {
            FormDeposte frmDeposte = new FormDeposte(FormDeposte.MODO_SELECCIONAR_GARRON, listVentaDetalle);
            frmDeposte.ShowDialog();

            if (frmDeposte.DialogResult.Equals(DialogResult.OK))
            {
                selectedGarron = frmDeposte.garronSelected;
                lGarronSelected.Text = "Garron # " + selectedGarron.Id + " - Numero: " + selectedGarron.Numero + "Peso: " + selectedGarron.Peso + " - Estado: " + selectedGarron.TipoEstadoGarron.Descripcion;
                //tbPrecio.Text = selectedGarron.MontoCompra.ToString();
                tbPrecioFinal.Focus();
            }
        }
    }
}