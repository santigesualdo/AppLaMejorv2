using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;
using AppLaMejor.datamanager;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.formularios
{
    public partial class FormCaja : Form
    {
        List<VentaDetalle> listDetalleVentas;
        List<Venta> listVentas;
        DataTable currentVentasDetalle;
        //DataTable dtVentas;
        decimal currentMontoTotal;

        Producto productoKioscoSelected;

        public FormCaja()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void Cargar()
        {
            // Armamos la tabla de nueva venta para mostrar en el grid
            currentVentasDetalle = GetTable();

            productoKioscoSelected = null;

            // Configuracion visual del grid
            dataGridNuevaVentaDetalle.ColumnHeadersVisible= false;
            dataGridNuevaVentaDetalle.AllowUserToAddRows = false;
            dataGridNuevaVentaDetalle.Columns.Add(new DataGridViewImageColumn(){Image = Properties.Resources.x_icon_30x30_white,Width = 30});
            dataGridNuevaVentaDetalle.DataSource = currentVentasDetalle;
            dataGridNuevaVentaDetalle.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridNuevaVentaDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridNuevaVentaDetalle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridNuevaVentaDetalle.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tbCodigo.Focus();
            listDetalleVentas = new List<VentaDetalle>();

            // Obtenemos ventas del dia
            listVentas = FuncionesVentas.ObtenerVentasDelDiaList();
            dataGridVentas.DataSource = listVentas;
            dataGridVentas.AllowUserToAddRows = false;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridVentas.Columns.Count; i++)
            {
                dataGridVentas.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
                string name = dataGridVentas.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("IDUSUARIO") || name.ToUpper().Equals("FECHABAJA"))
                {
                    dataGridVentas.Columns[i].Visible = false;
                    continue;
                }
            }

            // Global monto total
            currentMontoTotal = decimal.Zero;

            // 
            ApplicationLookAndFeel.ApplyTheme(labelSubTotal);
            labelSubTotal.Font = new Font("Source Sans Pro", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

            // Cargar AutoCompleteTextBox
            LoadTextBoxs();

            UpdateFont();
        }

        private void LoadTextBoxs()
        {
            string consulta = QueryManager.Instance().GetProductosSearchDataKiosco();
            AutoCompleteStringCollection collectionProducto = QueryManager.Instance().GetAutoCompleteCollection(ConnecionBD.Instance().Connection, consulta, 1 );
            if (collectionProducto != null)
            {
                textBoxProductoK.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBoxProductoK.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxProductoK.AutoCompleteCustomSource = collectionProducto;
            }

        }

        void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dataGridNuevaVentaDetalle.Columns)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font("Source Sans Pro", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                c.DefaultCellStyle.ApplyStyle(style);
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcesarBarra(string text)
        {
            string codigo;
            string entero;
            string decimales;
            string plu;

            codigo = text;
            // Codigo de producto 4 posiciones desde posicion 2 
            plu = codigo.Substring(2, 4);

            // Obtenemos producto por plu
            Producto product = controlmanager.FuncionesVentas.GetProductoByCode(plu);

            // Sino encuentra producto, sale
            if (product == null)
            {
                MyTextTimer.TStartFade("No se encontro PLU de Producto. Verificar codigo de barra.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                return;
            }

            if (!FuncionesProductos.CheckProductExistUbicacionSalida(product.Id))
            {
                MyTextTimer.TStartFade("El producto: "+product.DescripcionBreve+" no existe en la ubicacion de salida "+FuncionesGlobales.ObtenerUbicacionSalida().Descripcion+"\nAsegurese de mover mercaderia a esta ubicacion.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                return;
            }

            ProductoUbicacion pu = FuncionesProductos.GetProductoUbicacion(product, FuncionesGlobales.ObtenerUbicacionSalida().Id);

            // Monto entero 3 posiciones desde posicion 7
            entero = codigo.Substring(7, 3);
            // Monto entero 3 posiciones desde posicion 10
            decimales = codigo.Substring(10, 3);
            // Monto concatenado en string y operatoria para obtener decimal de 3 posiciones
            string monto = entero + decimales;
            int imonto = Int32.Parse(monto);
            decimal montoTicket = (decimal)imonto / 1000;

            // Nueva sub-venta, ventadetalle
            VentaDetalle vd = new VentaDetalle();
            vd.Monto = montoTicket;
            vd.Peso = FuncionesProductos.GetPesoProductoPrecio(montoTicket, product);

            // Validacion extra del ticket sobre la cantidad del producto en SALON DE VENTAS. (aunque si todo funciona bien nunca deberia vender mas de lo que tiene)
            decimal calculo = decimal.Subtract(pu.peso, vd.Peso);
            if (calculo<0)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ticket erroneo. Existen " + pu.peso.ToString() + "kg. de " + product.DescripcionBreve + "en " + FuncionesGlobales.ObtenerUbicacionSalida().Descripcion + ". \nSe intentan vender " + vd.Peso + "kg.");
                return;
            }

            vd.idUsuario = 1;
            vd.Producto = product;

            // Agregamos a la lista y mostramos en grid
            listDetalleVentas.Add(vd);

            currentVentasDetalle.Rows.Add(vd.Producto.DescripcionBreve, "$ " + vd.Monto , vd.Peso.ToString() + " kg.");

            currentMontoTotal += vd.Monto;

            labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

        }

        private static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Producto", typeof(string));
            table.Columns.Add("Monto", typeof(string));
            table.Columns.Add("Peso", typeof(string));
            table.Rows.Clear();
            
            return table;
        }

        private void dataGridNuevaVentaDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eliminar venta detalle de la grilla (aun no se guardo nada)
            if (e.ColumnIndex.Equals(0))
            {
                EliminarFila(sender);
            }
        }

        private void EliminarFila(object sender)
        {
            DataGridView grid = (DataGridView)sender;

            int selectedrowindex = grid.SelectedCells[0].RowIndex;

            currentMontoTotal -= listDetalleVentas[selectedrowindex].Monto;
            labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

            grid.Rows.RemoveAt(selectedrowindex);

            listDetalleVentas.RemoveAt(selectedrowindex);
        }

        private void agregarVenta_Click(object sender, EventArgs e)
        {

            if (listDetalleVentas.Count.Equals(0)) {
                MyTextTimer.TStartFade("No se encontro PLU de Producto. Verificar codigo de barra.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                return;
            }

            if (FuncionesVentas.InsertVenta(listDetalleVentas))
            {
                MyTextTimer.TStartFade("Se inserto venta  correctamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                currentVentasDetalle.Clear();
                listDetalleVentas.Clear();
                Cargar();
            }
            else
            {
                MyTextTimer.TStartFade("Fallo la nueva venta. Intente nuevamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
            }
        }

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {
            // Barra de 13 caracteres
            if (textCodigo.Text.Length == 13)
            {
                ProcesarBarra(textCodigo.Text);
                textCodigo.Text = String.Empty;
            }
        }

        private void textCodigo_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Text = string.Empty;
        }

        private void textBoxProductoK_Click(object sender, EventArgs e)
        {
            textBoxProductoK.Text = string.Empty;
        }

        private void bAgregarProduKiosco_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (productoKioscoSelected == null)
            {
                dialog.ShowErrorDialog("Debe seleccionar un Producto Kiosco para agregar.");
                textBoxProductoK.Focus();
                return;
            }

            if (textBoxCantidadK.ToString().Equals("")|| textBoxCantidadK.ToString().Equals(string.Empty))
            {
                textBoxCantidadK.Focus();
                dialog.ShowErrorDialog("Debe seleccionar una cantidad de unidades para el producto.");
                return;
            }

            // Nueva sub-venta, ventadetalle
            VentaDetalle vd = new VentaDetalle();
            decimal unidades;
            decimal.TryParse(textBoxCantidadK.Text, out unidades);
            vd.Peso = unidades;
            vd.Monto = productoKioscoSelected.Precio * vd.Peso;
            vd.idUsuario = 1;
            vd.Producto = productoKioscoSelected;

            // Agregamos a la lista y mostramos en grid
            listDetalleVentas.Add(vd);

            currentVentasDetalle.Rows.Add(vd.Producto.DescripcionBreve, "$ " + vd.Monto, " x "+ vd.Peso.ToString());

            currentMontoTotal += vd.Monto;

            productoKioscoSelected = null;

            labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();
            tbCodigo.Focus();

        }

        private void textBoxProductoK_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                string text = ((TextBox)sender).Text;
                productoKioscoSelected = FuncionesProductos.GetProductoByDescrip(text);


                

                textBoxCantidadK.Focus();

                decimal pesoMax = FuncionesProductos.GetPesoMaxByProdByUbi(productoKioscoSelected, FuncionesGlobales.ObtenerUbicacionSalida().Id);

                if (pesoMax.Equals(decimal.Zero))
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Ocurrio un error, el peso no puede ser 0.");
                    return;
                }

                // Si ya utilizamos este producto en un movimiento anterior para la misma ubicacion, el peso max disponible cambia
                pesoMax = CheckProductoUbicacionUtilizado(pesoMax, productoKioscoSelected, FuncionesGlobales.ObtenerUbicacionSalida().Id);

                textBoxCantidadK.Text = "(CantidadMax: " + pesoMax.ToString() + ")";

            }
        }

        private void textBoxCantidadK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.Equals(Keys.Return))
            {
                FuncionesGlobales.KeyPressIntegerTextField(sender, e);
            }else
            {
                bAgregarProduKiosco.Focus();
            }
        }

        

        private decimal CheckProductoUbicacionUtilizado(decimal pesoMax, Producto producto, int origenSeleccionado)
        {
            if (listDetalleVentas.Count.Equals(0))
                return pesoMax;

            decimal pesoMaxNuevo = pesoMax;
            foreach (VentaDetalle m in listDetalleVentas)
            {
                if (m.Producto.Id.Equals(producto.Id))
                {
                    pesoMaxNuevo -= m.Peso;
                }
            }
            return pesoMaxNuevo;
        }


        //Proceso:
        //EntraProducto
        //- Entra código de producto, se busca el producto en la bd. Se encuentra.
        //- Obtenemos entidad producto.
        //- Añadimos la entidad a la grid (posibilidad de eliminar, no editar)
        //- EntraProducto o FinalizarVenta

        //FinalizarVenta
        //- Se inserta el registro venta sus ventadetalle.
        //- Se refresca la grilla de ventas anteriores.
        //- Se limpian todos los controles.



    }
}
