﻿using System;
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
using AppLaMejor.formularios.MovimientoCuentas;
using AppLaMejor.formularios.Util;
using AppLaMejor.formularios.Caja;

namespace AppLaMejor.formularios
{
    public partial class FormCajaMayorista : Form
    {
        List<VentaDetalle> listDetalleVentas;
        List<Venta> listVentas;
        List<Cliente> listClients;
        DataTable currentVentasDetalle, tableClientes;
        //DataTable dtVentas;

        Cliente miCliente = new Cliente();
        MovimientoCuenta miMovCuenta = new MovimientoCuenta();
        Cuenta miCuenta = new Cuenta();

        decimal currentMontoTotal;

        public FormCajaMayorista()
        {
            InitializeComponent();
            Cargar();
            ApplicationLookAndFeel.ApplyThemeToAll(this);
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

            

            tbCodigo.Focus();
            listDetalleVentas = new List<VentaDetalle>();

            // Obtenemos ventas del dia
            listVentas = FuncionesVentas.ObtenerVentasDelDiaList();
            dataGridVentas.DataSource = listVentas;
            dataGridVentas.AllowUserToAddRows = false;

            // cargar los clientes en el combobox

            tableClientes = FuncionesClientes.fillClientes();
            listClients = FuncionesClientes.listClientes(tableClientes);

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

        private void ProcesarBarra(string text)
        {
            string codigo;
            string entero;
            string decimales;
            string plu;

            codigo = text;
            // Codigo de producto 6 posiciones desde posicion 1 
            plu = codigo.Substring(1, 6);

            // Obtenemos producto por plu
            Producto product = controlmanager.FuncionesVentas.GetProductoByCode(plu);

            // Sino encuentra producto, sale
            if (product == null)
            {
                MyTextTimer.TStartFade("No se encontro PLU de Producto. Verificar codigo de barra.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                return;
            }

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
            vd.idUsuario = 1;
            vd.Producto = product;

            // Agregamos a la lista y mostramos en grid
            listDetalleVentas.Add(vd);

            currentVentasDetalle.Rows.Add(vd.Producto.DescripcionLarga, "$ " + vd.Monto , vd.Peso.ToString() + " kg.");

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

            miMovCuenta.Cuenta = VariablesGlobales.Cuenta_VentaMay;

            if (FuncionesVentas.InsertVentaMayorista(listDetalleVentas, miCliente, miMovCuenta))
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
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex != -1)
            {
                miCliente = (Cliente)combo.SelectedValue;
                //if (nuevaCuenta(client) != null)
                //{
                //    CargarDataGrid();
                //}
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCliente.Text = "Cliente: " + cmbCliente.Text;
           // miCliente.Id = (int)cmbCliente.SelectedValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* Form Entity Input */
            FormMovDetalle dialog = new FormMovDetalle(FormMovDetalle.MODO_AGREGAR, miCliente, currentMontoTotal.ToString());
            dialog.SetTitulo("Cliente: " + miCliente.RazonSocial);
            Boolean result = dialog.Execute(miCliente.Id);
        }

        private void btManual_Click(object sender, EventArgs e)
        {
            FormAgregarManual formAgregarManual = new FormAgregarManual();
            if (formAgregarManual.ShowDialog() == DialogResult.OK)
            {
                //textCodigo.Text = formAgregarManual.codigomanual;

                //string monto = entero + decimales;
                //int imonto = Int32.Parse(monto);
                //decimal montoTicket = (decimal)imonto / 1000;

                // Nueva sub-venta, ventadetalle
                VentaDetalle vd = new VentaDetalle();
                vd.Monto = formAgregarManual.precioFinal;
                vd.Peso = FuncionesProductos.GetPesoProductoPrecio(vd.Monto, formAgregarManual.product);
                vd.idUsuario = 1;
                vd.Producto = formAgregarManual.product;

                // Agregamos a la lista y mostramos en grid
                listDetalleVentas.Add(vd);

                currentVentasDetalle.Rows.Add(vd.Producto.DescripcionLarga, "$ " + vd.Monto, vd.Peso.ToString() + " kg.");

                currentMontoTotal += vd.Monto;

                labelSubTotal.Text = " TOTAL : $ " + currentMontoTotal.ToString();

            }
                //formAgregarManual.ShowDialog();

            
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