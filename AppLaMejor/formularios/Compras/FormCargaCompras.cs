using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.stylemanager;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Data;
using System.Collections.Generic;
using AppLaMejor.formularios.Util;
using AppLaMejor.formularios.Productos;

namespace AppLaMejor.formularios.Compras
{ 
     public partial class FormCargaCompras : Form
    {
        // TODO : CargaCompras - No debe poder ingresar dos veces el mismo producto.
        List<Garron> listGarron;
        List<Producto> listProducto;

        DataTable currentCompraDetalleGarron;
        DataTable currentCompraDetalleProducto;

        Producto lastProdSelected = null;
        Proveedor provSelec = null;
        int currentIdCuentaProveedor;

        decimal currentMontoCompra;
        decimal currentPagoParcial;

        bool proveedorSeleccionado;

        int currentModoPeso;
        int MODO_KG = 1;
        int MODO_UNIDAD = 2;

        public FormCargaCompras()
        {
            InitializeComponent();

            ApplicationLookAndFeel.ApplyThemeToAll(this);

            Cargar();
        }

        private void Cargar()
        {
            LoadAutoCompleteTextBox();
            LoadGrids();
            LoadLists();

            currentModoPeso = MODO_KG;
            proveedorSeleccionado = false;
            currentIdCuentaProveedor = 0;
        }

        private void LoadLists()
        {
            listProducto = new List<Producto>();
            listGarron = new List<Garron>();
            currentMontoCompra = decimal.Zero;
            lblSaldo.Text = "$$";
        }

        private void LoadGrids()
        {
            currentCompraDetalleGarron = GetTableGarron();

            gridGarron.ColumnHeadersVisible = false;
            gridGarron.AllowUserToAddRows = false;
            gridGarron.Columns.Add(new DataGridViewImageColumn() { Image = Properties.Resources.x_icon_30x30_white, Width = 30 });
            gridGarron.DataSource = currentCompraDetalleGarron;
            gridGarron.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridGarron.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridGarron.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            currentCompraDetalleProducto = GetTableProducto();
            gridProductos.ColumnHeadersVisible = false;
            gridProductos.AllowUserToAddRows = false;
            gridProductos.Columns.Add(new DataGridViewImageColumn() { Image = Properties.Resources.x_icon_30x30_white, Width = 30 });
            gridProductos.DataSource = currentCompraDetalleProducto;
            gridProductos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridProductos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProductos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProductos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProductos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            table.Columns.Add("Cant.", typeof(string));
            table.Columns.Add("Cant. Entregada", typeof(string));
            table.Rows.Clear();

            return table;
        }

        private void LoadAutoCompleteTextBox()
        {
            LoadTextBoxProveedor();
            textBoxProveedor.Text = "(Ingrese nombre de proveedor)";
            LoadTextBoxPlu();
            textBoxPLU.Text = "(Ingrese PLU)";
            LoadTextBoxDescripProd();
            textBoxDescrip.Text = "(Ingrese Descripcion)";
        }

        private void LoadTextBoxProveedor()
        {
            string consulta = QueryManager.Instance().GetProveedoresCuentaBanco();
            AutoCompleteStringCollection collection = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 0);
            if (collection != null)
            {
                textBoxProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxProveedor.AutoCompleteCustomSource = collection;
            }
        }

        private void LoadTextBoxPlu()
        {
            string consulta = QueryManager.Instance().GetProductosSearchDataConPlu();
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
            string consulta = QueryManager.Instance().GetProductosSearchDataAll();
            AutoCompleteStringCollection collection = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 1);
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
                labelProdSelec.Text = lastProdSelected.DescripcionBreve;
                CheckTipoProducto(lastProdSelected);
                textBoxDescrip.Text = string.Empty;
            }
        }

        private void textBoxDescrip_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                lastProdSelected = FuncionesProductos.GetProductoByDescrip(text);
                labelProdSelec.Text = lastProdSelected.DescripcionBreve;
                CheckTipoProducto(lastProdSelected);
                textBoxPLU.Text = string.Empty;
            }
        }

        private void CheckTipoProducto(Producto lastProdSelected)
        {
            // Producto tipo kiosco por unidades
            if (lastProdSelected.TipoProducto.Id.Equals(4))
            {
                currentModoPeso = MODO_UNIDAD;
                Peso.Text = "Unidades";
                label4.Visible = false;
                textBoxPesoEntregado.Visible = false;
                textBoxPeso.KeyPress -= textBoxDecimal_KeyPress;
                textBoxPeso.KeyPress += textBoxInteger_KeyPress;
                textBoxPeso.Text = "1";
                textBoxPeso.Focus();
            }
            else
            // Productos por KG.
            {
                currentModoPeso = MODO_KG;
                Peso.Text = "Peso";
                label4.Visible = true;
                textBoxPesoEntregado.Visible = true;
                textBoxPeso.KeyPress -= textBoxInteger_KeyPress;
                textBoxPeso.KeyPress += textBoxDecimal_KeyPress;
                textBoxPeso.Focus();
            }
        }

        private void textBoxProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                currentIdCuentaProveedor = int.Parse(text.Substring(text.LastIndexOf("idCuenta:") + 9));
                string nameProveedor = text.Substring(0, text.LastIndexOf(" - CBU"));
                provSelec = FuncionesProveedores.GetProveedorByName(nameProveedor);
                labelProveedorSeleccionado.Text = provSelec.RazonSocial;
                proveedorSeleccionado = true;
                ((TextBox)sender).SelectionLength = 0;

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
            panelPaint(sender, e, panelFinalizarCompra, 2);
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
                proveedorSeleccionado = true;
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
                AgregarGarronToGrid(newGarron);
            }
        }

        private void AgregarGarronToGrid(Garron newGarron)
        {
            // Agregamos a la lista y mostramos en grid
            currentCompraDetalleGarron.Rows.Add(newGarron.Numero, "$ " + newGarron.MontoCompra.ToString(), newGarron.Peso.ToString() + " kg.", newGarron.TipoGarron.Descripcion);

            currentMontoCompra += newGarron.MontoCompra;
            listGarron.Add(newGarron);

            ActualizarSaldoLabel(currentMontoCompra);

            if (!gridGarron.ColumnHeadersVisible)
                gridGarron.ColumnHeadersVisible = true;
        }
        private void bAgregarProducto_Click(object sender, EventArgs e)
        {
            if (validarProductoToGrid())
            {
                AgregarProductoToGrid(lastProdSelected);
                LimpiarInputsDeProducto();
            }
        }

        private void LimpiarInputsDeProducto()
        {
            
            textBoxDescrip.Text = "(buscar por descripcion)";
            textBoxPeso.Text = "(ingrese peso del producto)";
            textBoxPesoEntregado.Text = "";
            textBoxMonto.Text = "(ingrese monto)";
            textBoxPLU.Text = "(buscar por plu)";
            label1.Focus();
        }

        private void AgregarProductoToGrid(Producto producto)
        {
            decimal auxprecio = decimal.Parse(textBoxMonto.Text);
            decimal auxcantidad = decimal.Parse(textBoxPeso.Text);
            decimal auxcantidadEntregada = decimal.Parse(textBoxPesoEntregado.Text);

            producto.CantidadEntregada = auxcantidadEntregada;
            producto.Cantidad = auxcantidad;
            producto.Precio = auxprecio;

            listProducto.Add(producto);

            if (currentModoPeso.Equals(MODO_KG))
                currentCompraDetalleProducto.Rows.Add(producto.DescripcionBreve, "$ " + textBoxMonto.Text, textBoxPeso.Text + " kg.", textBoxPesoEntregado.Text + " kg.");
            
            if (currentModoPeso.Equals(MODO_UNIDAD))
                currentCompraDetalleProducto.Rows.Add(producto.DescripcionBreve, "$ " + textBoxMonto.Text, " x"+ textBoxPeso.Text, " x" + textBoxPesoEntregado.Text);

            currentMontoCompra += producto.Precio;

            ActualizarSaldoLabel(currentMontoCompra);

            if (!gridProductos.ColumnHeadersVisible)
                gridProductos.ColumnHeadersVisible = true;
        }

        private bool validarProductoToGrid()
        {
            FormMessageBox dialog = new FormMessageBox();
            if (lastProdSelected == null)
            {
                dialog.ShowErrorDialog("Se debe seleccionar un producto para continuar. ");
                return false;
            }
            if ((textBoxPeso.Text.Equals("(ingrese peso)")) || (textBoxPeso.Text.Equals("")))
            {
                dialog.ShowErrorDialog("Se debe indicar un peso para cada producto comprado. ");
                textBoxPeso.Focus();
                return false;
            }
            if ((textBoxMonto.Text.Equals("(ingrese monto)"))|| (textBoxPeso.Text.Equals("")))
            {
                dialog.ShowErrorDialog("Se debe indicar un precio para cada producto comprado. ");
                textBoxMonto.Focus();
                return false;
            }
            if (textBoxPesoEntregado.Text.Equals("") && currentModoPeso.Equals(MODO_KG))
            {
                dialog.ShowErrorDialog("Se debe indicar un peso entregado para cada producto comprado. ");             
                textBoxPeso_Leave(null, null);
                return false;
            }else if (textBoxPesoEntregado.Text.Equals("") && currentModoPeso.Equals(MODO_UNIDAD))
            {
                textBoxPesoEntregado.Text = textBoxPeso.Text;
            }

            return true;        
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridGarron_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eliminar venta detalle de la grilla (aun no se guardo nada)
            if (e.ColumnIndex.Equals(0))
            {
                EliminarFilaGarron(sender);
            }
        }

        private void gridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eliminar venta detalle de la grilla (aun no se guardo nada)
            if (e.ColumnIndex.Equals(0))
            {
                EliminarFilaProducto(sender);
            }
        }

        private void EliminarFilaGarron(object sender)
        {
            DataGridView grid = (DataGridView)sender;

            int selectedrowindex = grid.SelectedCells[0].RowIndex;

            currentMontoCompra -= listGarron[selectedrowindex].MontoCompra;

            ActualizarSaldoLabel(currentMontoCompra);

            grid.Rows.RemoveAt(selectedrowindex);
            listGarron.RemoveAt(selectedrowindex);
        }

        private void EliminarFilaProducto(object sender)
        {

            DataGridView grid = (DataGridView)sender;

            int selectedrowindex = grid.SelectedCells[0].RowIndex;

            decimal currentEliminatedPrcio = listProducto[selectedrowindex].Precio;
            currentMontoCompra = currentMontoCompra - currentEliminatedPrcio;

            ActualizarSaldoLabel(currentMontoCompra);

            grid.Rows.RemoveAt(selectedrowindex);
            listProducto.RemoveAt(selectedrowindex);
        }

        void ActualizarSaldoLabel(decimal saldo)
        {
            lblSaldo.Text = " $ " + saldo.ToString();
        }

        private void bFinalizarCompra_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (ValidarCompra())
            {
                if (dialog.ShowConfirmationDialog("¿Desea confirmar la compra?"))
                {
                    if (ConfirmarCompra())
                    {
                        MyTextTimer.TStartFade("Compra confirmada. ", this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                        Cargar();
                    }
                    else
                    {
                        MyTextTimer.TStartFade("No se confirmo la compra. Intente nuevamente.",this.statusStrip1, this.tsslMensaje, MyTextTimer.TIME_LONG);
                    }
                }
            }
            
        }

        private bool ConfirmarCompra()
        {
            // En result queda el ID de Compra si todo salio bien.
            int result = FuncionesCompras.ConfirmarCompraTransaction(currentMontoCompra, currentPagoParcial, provSelec, listGarron, listProducto, currentIdCuentaProveedor);
            if (result.Equals(-1))
            {
                return false;
            }

            FormMessageBox box = new FormMessageBox();
            if (box.ShowConfirmationDialog("Compra #"+result.ToString()+" registrada con exito.¿Desea ubicar los productos?"))
            {
                FormMoverProductos fmp = new FormMoverProductos(FormMoverProductos.MODO_UBICARMERCADERIACOMPRA, listProducto, listGarron);
                fmp.ShowDialog();
            }

            return true;
        }

        private bool ValidarCompra()
        {
            FormMessageBox box = new FormMessageBox();
            // 1. seleccionar alguna opcion en proveedores, si elije sin proveedor mostrar advertencia que no 
            // se registrara en ninguna cuenta
            if (!proveedorSeleccionado)
            {
                box.ShowErrorDialog("Debe seleccionar alguna opción para proveedores.");
                return false;
            }

            // 2. que list garron o list producto tengan al menos 1 item en la grilla
            if (listGarron.Count.Equals(0) && listProducto.Count.Equals(0))
            {
                box.ShowErrorDialog("Debe agregar algun Garron o Producto a la compra.");
                return false;
            }

            if (currentMontoCompra.Equals(decimal.Zero))
            {
                box.ShowErrorDialog("El monto total no puede ser 0.");
                return false;
            }

            // 2a. que saldo sea la suma de los items
            decimal auxMonto = 0;
            foreach ( Garron g in listGarron)
            {
                auxMonto += g.MontoCompra;
            }
            foreach (Producto p in listProducto)
            {
                auxMonto += p.Precio;
            }

            int res = decimal.Compare(auxMonto, currentMontoCompra);
            if (!res.Equals(0))
            {
                box.ShowErrorDialog("Los precios no coinciden. Ocurrio un error.");
                return false;
            }

            // Si no esta chequeado pago total 
            if (!checkTotalPagado.Checked)
            {
                // Y el pago parcial esta vacio
                if (textPagoParcial.Text.Equals(""))
                {
                    if (!box.ShowConfirmationDialog("Se selecciono pago parcial pero no se ingreso monto parcial. Si elige ACEPTAR la compra se registrara impaga."))
                    {
                        return false;
                    }
                    else
                    {
                        currentPagoParcial = decimal.Zero;
                    }
                }
                // sino procedemos con el pago parcial
                else
                {
                    // 3. Si esta chequeado que el pago es parcial, el monto parcial no puede ser mayor ni igual al saldo actual
                    currentPagoParcial = decimal.Parse(textPagoParcial.Text);
                    if (currentPagoParcial >= currentMontoCompra)
                    {
                        box.ShowErrorDialog("El pago parcial solo puede ser menor al saldo total.");
                        return false;
                    }
                }
            }

            return true;
        }

        private void checkProveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (checkProveedores.Checked)
            {
                textBoxProveedor.Text = string.Empty;
                FormMessageBox box = new FormMessageBox();
                box.ShowErrorDialog("Si selecciona esta opción, la compra no se registrara en ninguna cuenta.");
                labelProveedorSeleccionado.Text = "COMPRA SIN PROVEEDOR";
                proveedorSeleccionado = true;
                checkTotalPagado.Checked = true;
                checkTotalPagado_CheckedChanged(sender, e);
                checkTotalPagado.AutoCheck = false;
                textBoxPesoEntregado.ReadOnly = true;
            }
            else
            {
                textBoxPesoEntregado.ReadOnly = false;
                checkTotalPagado.AutoCheck = true;
                labelProveedorSeleccionado.Text = "(Proveedor sin seleccionar)";
            }

        }

        private void textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void textBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.KeyPressIntegerTextField(sender, e);
        }

        private void checkTotalPagado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTotalPagado.Checked)
            {
                textPagoParcial.Visible = false;
                labelPrecioPagado.Visible = false;
            }
            else
            {
                textPagoParcial.Visible = true;
                labelPrecioPagado.Visible = true;
            }
        }

        private void textBoxProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPeso_Leave(object sender, EventArgs e)
        {
            textBoxPesoEntregado.Text = textBoxPeso.Text;
        }

        private void textBoxPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBoxMonto.Focus();
                return;
            }

            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void textBoxMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                bAgregarProducto_Click(null, null);
                return;
            }

            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }
    }
}
