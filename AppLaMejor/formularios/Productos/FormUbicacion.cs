using AppLaMejor.controlmanager;
using AppLaMejor.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Productos
{
    public partial class FormUbicacion : Form
    {
        public FormUbicacion()
        {
            InitializeComponent();
        }

        private void bMoverProducto_Click(object sender, EventArgs e)
        {
            FormMoverProductos formMoverProductos = new FormMoverProductos(FormMoverProductos.MODO_MOVERMERCADERIA, null, null);
            formMoverProductos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Garron> listGarron = new List<Garron>();
            listGarron.Add(FuncionesGarron.GetGarron(26));
            listGarron.Add(FuncionesGarron.GetGarron(27));
            listGarron.Add(FuncionesGarron.GetGarron(28));

            FormMoverProductos formMoverProductos = new FormMoverProductos(FormMoverProductos.MODO_UBICARMERCADERIACOMPRA, null, listGarron);
            formMoverProductos.ShowDialog();
        }
    }
}
