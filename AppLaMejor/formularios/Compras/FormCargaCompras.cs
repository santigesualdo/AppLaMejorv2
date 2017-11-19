using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.stylemanager;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Data;
using System.Collections.Generic;

namespace AppLaMejor.formularios.Compras
{
    public partial class FormCargaCompras : Form
    {
        List<Garron> listGarron;
        List<Producto> listProducto;

        DataTable currentCompraDetalleGarron;
        DataTable currentCompraDetalleProducto;

        Producto lastProdSelected = null;

        public FormCargaCompras()
        {
            InitializeComponent();

            ApplicationLookAndFeel.ApplyThemeToAll(this);
            LoadAutoCompleteTextBox();
            LoadGrids();
            LoadLists();



        }

        private void LoadLists()
        {
            listProducto = new List<Producto>();
            listGarron = new List<Garron>();
        }

        private void LoadGrids()
        {
            currentCompraDetalleGarron = GetTableGarron();

            gridGarron.ColumnHeadersVisible = false;
            gridGarron.AllowUserToAddRows = false;
            gridGarron.Columns.Add(new DataGridViewImageColumn() { Image = Properties.Resources.x_icon_30x30, Width = 30 });
            gridGarron.DataSource = currentCompraDetalleGarron;
            gridGarron.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridGarron.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            currentCompraDetalleProducto = GetTableProducto();
            gridProductos.ColumnHeadersVisible = false;
            gridProductos.AllowUserToAddRows = false;
            gridProductos.Columns.Add(new DataGridViewImageColumn() { Image = Properties.Resources.x_icon_30x30, Width = 30 });
            gridProductos.DataSource = currentCompraDetalleProducto;
            gridProductos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridProductos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProductos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProductos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private static DataTable GetTableGarron()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Numero", typeof(string));
            table.Columns.Add("Monto", typeof(string));
            table.Columns.Add("Peso", typeof(string));
            table.Columns.Add("TipoGarron", typeof(string));
            table.Rows.Clear();

            return table;
        }

        private static DataTable GetTableProducto()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Producto", typeof(string));
            table.Columns.Add("Monto", typeof(string));
            table.Columns.Add("Peso", typeof(string));
            table.Rows.Clear();

            return table;
        }

        private void LoadAutoCompleteTextBox()
        {
            LoadTextBoxProveedor();
            LoadTextBoxPlu();
            LoadTextBoxDescripProd();

        }

        private void LoadTextBoxProveedor()
        {
            string consulta = QueryManager.Instance().GetProveedoresData();
            AutoCompleteStringCollection collection = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 1);
            if (collection != null)
            {
                textBoxProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxProveedor.AutoCompleteCustomSource = collection;
            }
        }

        private void LoadTextBoxPlu()
        {
            string consulta = QueryManager.Instance().GetProductosSearchData();
            AutoCompleteStringCollection collection = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 1);
            if (collection != null)
            {
                textBoxPLU.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxPLU.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxPLU.AutoCompleteCustomSource = collection;
            }
        }

        private void LoadTextBoxDescripProd()
        {
            string consulta = QueryManager.Instance().GetProductosSearchData();
            AutoCompleteStringCollection  collection = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 2);
            if (collection != null)
            {
                textBoxDescrip.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxDescrip.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxDescrip.AutoCompleteCustomSource = collection;
            }
        }

        private void textBoxPLU_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                lastProdSelected = FuncionesProductos.GetProductoByPlu(text);
                labelProdSelec.Text = lastProdSelected.DescripcionLarga;
                textBoxDescrip.Text = string.Empty;
            } 
        }

        private void textBoxDescrip_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                lastProdSelected = FuncionesProductos.GetProductoByDescrip(text);
                labelProdSelec.Text = lastProdSelected.DescripcionLarga;
                textBoxPLU.Text = string.Empty;
            }
        }

        private void textBoxProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                Proveedor provSelec= FuncionesProveedores.GetProveedorByName(text);
                labelProveedorSeleccionado.Text = provSelec.RazonSocial;

            }
        }
        private void panelPaint(object sender, PaintEventArgs e, Panel panel, int _thickness)
        {
            int thickness = _thickness;//it's up to you
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(StyleManager.Instance().GetCurrentStyle().TextColor, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                            halfThickness,
                                                            panel.ClientSize.Width - thickness,
                                                            panel.ClientSize.Height - thickness));
            }
        }

        private void panelFinalizarCompra_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelFinalizarCompra,2);
        }

        private void panelProducto_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelProducto, 2);
        }

        private void panelGarron_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelGarron, 2);
        }

        private void panelNuevaCompra_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelNuevaCompra, 2);
        }

        private void panelSelecProv_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelSelecProv, 2);
        }

        private void textBoxEmptyOn_Click(object sender, System.EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void panelSelecProducto_Paint(object sender, PaintEventArgs e)
        {
            panelPaint(sender, e, panelSelecProducto, 1);
        }

        private void bAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor newProv = FuncionesProveedores.AgregarProveedor("Agregar Proveedor");
            if (newProv != null)
            {
                MyTextTimer.TStartFade("Se guardo Proveedor " + newProv.RazonSocial.ToUpper() + ".", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                LoadTextBoxProveedor();
                labelProveedorSeleccionado.Text = newProv.RazonSocial;
            }
            else
            {
                MyTextTimer.TStartFade("No se guardo el Proveedor. Ocurrio un error.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
            }
        }

        private void bAgregarGarron_Click(object sender, EventArgs e)
        {
            Garron newGarron = FuncionesGarron.AgregarGarronSinBD("Agregar Garron");
            if (newGarron != null)
            {
                // TODO: textbox para ingresar monto de Garron, ya que la entidad garron no posee monto
                AgregarGarronToGrid(newGarron, "152.25");
            }
        }

        private void AgregarGarronToGrid(Garron newGarron, string monto)
        {
            // Agregamos a la lista y mostramos en grid
            listGarron.Add(newGarron);
            currentCompraDetalleGarron.Rows.Add(newGarron.Numero, "$ " + monto, newGarron.Peso.ToString() + " kg.", newGarron.TipoGarron.Descripcion);
            if (!gridGarron.ColumnHeadersVisible)
                gridGarron.ColumnHeadersVisible = true;
        }
        private void bAgregarProducto_Click(object sender, EventArgs e)
        {
            if (lastProdSelected != null)
            {
                // TODO: textbox para ingresar monto de producto, ya que la entidad garron no posee monto
                AgregarProductoToGrid(lastProdSelected, "152.25");
            }
        }

        private void AgregarProductoToGrid(Producto producto, string v)
        {
            listProducto.Add(producto);
            currentCompraDetalleProducto.Rows.Add(producto.DescripcionLarga, "$ " + textBoxMonto.Text, textBoxPeso.Text + " kg.");
            if (!gridProductos.ColumnHeadersVisible)
                gridProductos.ColumnHeadersVisible = true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
