using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;
using AppLaMejor.Reports;
using AppLaMejor.formularios.Util;

namespace AppLaMejor.formularios.Caja
{
    public partial class FormCajaMayorista : Form
    {
        List<VentaDetalle> listDetalleVentas;
        List<Venta> listVentas;
        List<Cliente> listClients;
        DataTable currentVentasDetalle, tableClientes;

        Cuenta cuentaSelected;
        Cliente clienteSelected;

        decimal currentMontoTotal;
        private List<GarronDeposte> listDeposte;

        public FormCajaMayorista()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        public FormCajaMayorista(List<GarronDeposte> listDeposte)
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);

            this.listDeposte = listDeposte;

            foreach(GarronDeposte gd in listDeposte)
            {
                if (!gd.yaDepostado)
                {
                    VentaDetalle vd = new VentaDetalle();
                    vd.Monto = gd.Precio;
                    vd.Peso = gd.Peso;
                    vd.Producto = gd.Producto;

                    listDetalleVentas.Add(vd);

                    currentVentasDetalle.Rows.Add(vd.Producto.DescripcionLarga, "$ " + vd.Monto, vd.Peso.ToString() + " kg.");
                    currentMontoTotal += vd.Monto;

                    labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();
                }
            }
        }

        private void Cargar()
        {
            // Armamos la tabla de nueva venta para mostrar en el grid
            currentVentasDetalle = GetTable();

            // Configuracion visual del grid
            dataGridNuevaVentaDetalle.ColumnHeadersVisible= false;
            dataGridNuevaVentaDetalle.AllowUserToAddRows = false;
            dataGridNuevaVentaDetalle.Columns.Add(new DataGridViewImageColumn(){Image = Properties.Resources.x_icon_30x30,Width = 30});
            dataGridNuevaVentaDetalle.DataSource = currentVentasDetalle;
            dataGridNuevaVentaDetalle.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridNuevaVentaDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridNuevaVentaDetalle.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridNuevaVentaDetalle.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tableDatos.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            

            tbCodigo.Focus();
            listDetalleVentas = new List<VentaDetalle>();

            // Obtenemos ventas del dia
            listVentas = FuncionesVentas.ObtenerVentasDelDiaList();
            dataGridVentas.DataSource = listVentas;
            dataGridVentas.AllowUserToAddRows = false;

            // cargar los clientes en el combobox

            listClients = FuncionesClientes.GetClientesMayoristasConCuenta();

            BindingList<Cliente> objects = new BindingList<Cliente>(listClients);

            cmbCliente.ValueMember = null;
            cmbCliente.DisplayMember = "RazonSocial";
            cmbCliente.DataSource = objects;

            cmbCliente.SelectedIndex = -1;


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

            UpdateFont();
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

            if (clienteSelected == null)
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Debe seleccionar un cliente mayorista para la operacion.");
                return;
            }
            else
            {
                List<Cuenta> cuentasCliente = FuncionesClientes.GetCuentaEfectivoCliente(clienteSelected.Id);
                foreach(Cuenta c in cuentasCliente)
                {
                    if (c.Descripcion.Equals("EFECTIVO"))
                    {
                        cuentaSelected = c;
                        break;
                    }
                }
            }

            if (listDetalleVentas.Count.Equals(0)) {
                MyTextTimer.TStartFade("No se inserto detalle de la venta.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                return;
            }

            if (FuncionesVentas.InsertVentaMayorista(listDetalleVentas, clienteSelected, cuentaSelected))
            {

                MyTextTimer.TStartFade("Se inserto venta  correctamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
                
                listDetalleVentas.Clear();
                Cargar();
            }
            else
            {
                MyTextTimer.TStartFade("Fallo la nueva venta. Intente nuevamente.", statusStrip1, tsslMensaje, MyTextTimer.TIME_LONG);
            }
        }

        private void cmbCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCliente.Text = "Cliente: " + cmbCliente.Text;
            ComboBox combo = (ComboBox)sender;
            clienteSelected = (Cliente)combo.SelectedItem;
        }

        private void btManual_Click(object sender, EventArgs e)
        {
            FormAgregarManual formAgregarManual = new FormAgregarManual(listDetalleVentas);

            if (formAgregarManual.ShowDialog() == DialogResult.OK)
            {
                // Nueva sub-venta, ventadetalle
                VentaDetalle vd = new VentaDetalle();
                vd.Monto = formAgregarManual.precioFinal;
                vd.Peso = formAgregarManual.cantidad;  
                vd.Producto = formAgregarManual.selectedProducto;

                // Agregamos a la lista y mostramos en grid
                listDetalleVentas.Add(vd);

                currentVentasDetalle.Rows.Add(vd.Producto.DescripcionLarga, "$ " + vd.Monto, vd.Peso.ToString() + " kg.");
                currentMontoTotal += vd.Monto;

                labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

            }            
        }

        private void btRemito_Click(object sender, EventArgs e)
        {
               FormReportes fmr = new FormReportes();
               fmr.ShowDialog();
        }      
    }
}
