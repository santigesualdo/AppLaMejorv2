using AppLaMejor.controlmanager;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;
using AppLaMejor.formularios.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AppLaMejor.formularios.Productos
{
    public partial class FormHistoricoPrecios : Form
    {

        List<PrecioHistorico> listHistorico;
        int idProducto;

        PrecioHistorico precioActual;
        PrecioHistorico precioAnterior;

        bool primerHistorico;

        public FormHistoricoPrecios()
        {
            InitializeComponent();

            if (VariablesGlobales.idProductoHistorico.Equals(-1))
            {
                FormMessageBox dialog = new FormMessageBox();
                dialog.ShowErrorDialog("Ocurrio un error con el id de producto: " + VariablesGlobales.idProductoHistorico.ToString() + ". No se puede continuar. ");
                this.Close();
            }

            CargarDatos();

        }

        private void CargarDatos()
        {
            idProducto = VariablesGlobales.idProductoHistorico;
            listHistorico = FuncionesPrecios.fillHistoricoByIdProducto(idProducto);
            primerHistorico = false;

            if (listHistorico.Count > 0)
            {
                precioActual = listHistorico.ElementAt(0);
                formTittleText.Text = "Precios de : " + precioActual.Producto.DescripcionBreve.ToUpper();

                lActualFechaDesde.Text = "Desde de : " + precioActual.Desde.ToString("MM/dd/yyyy");
                lActualPrecio.Text = "PRECIO: $ " + precioActual.Precio.ToString();

                if (listHistorico.Count > 1)
                {
                    precioAnterior = listHistorico.ElementAt(1);
                    lFechaDesde.Text = "Desde " + precioAnterior.Desde.ToString("MM/dd/yyyy");
                    lFechaHasta.Text = "Hasta " + precioAnterior.Hasta.Value.ToString("MM/dd/yyyy");
                    lPrecioAnterior.Text = " PRECIO: $ " + precioAnterior.Precio.ToString();
                }
                else if (listHistorico.Count.Equals(1))
                {
                    lFechaDesde.Text = "-";
                    lFechaHasta.Text = "-";
                    lPrecioAnterior.Text = "-";
                }
            }else
            {
                primerHistorico = true;
                lFechaDesde.Text = "-";
                lFechaHasta.Text = "-";
                lPrecioAnterior.Text = "-";

                lActualFechaDesde.Text = "-";
                lActualPrecio.Text = "-";
            }


            ApplicationLookAndFeel.ApplyThemeToAll(this);

            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            radioNuevoPrecio.Checked = true;
            textNuevoPrecio.ReadOnly = false;
            textNuevoPrecio.Focus();

            radioNuevoPrecio.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioAumentarActual.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            // Reseteamos los radio buttons.
            RadioButtonsChanged();

        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsChanged();
        }

        private void RadioButtonsChanged()
        {
            textAumentarActual.Text = string.Empty;
            textNuevoPrecio.Text = string.Empty;

            labelNuevoPrecio.Text = string.Empty;
            labelAgregar.Text = string.Empty;          

            if (radioNuevoPrecio.Checked)
            {
                textNuevoPrecio.ReadOnly = false;
                textNuevoPrecio.Focus();

                textAumentarActual.ReadOnly = true;
            }
            else if (radioAumentarActual.Checked)
            {
                textAumentarActual.ReadOnly = false;
                textAumentarActual.Focus();

                textNuevoPrecio.ReadOnly = true;
            }
        }
        
        private bool GuardarPrecioActual()
        {

            FormMessageBox dialog = new FormMessageBox();

            if (radioNuevoPrecio.Checked)
            {
                if (textNuevoPrecio.Text.Equals("") || textNuevoPrecio.Text.Equals("0"))
                {
                    dialog.ShowErrorDialog("El precio ingresado es incorrecto. Ingresar nuevamente. ");
                    return false;
                }
            }
            else if (radioAumentarActual.Checked)
            {
                if (textAumentarActual.Text.Equals("") || textAumentarActual.Text.Equals("0"))
                {
                    dialog.ShowErrorDialog("El precio ingresado es incorrecto. Ingresar nuevamente. ");
                    return false;
                }
            }

            decimal precioNuevo = GetPrecioNuevo();

            if (precioNuevo.Equals(decimal.Zero))
            {
                dialog.ShowErrorDialog("El precio ingresado es incorrecto. Ingresar nuevamente. ");
                return false;
            }

            // Verificamos que el precio actual, tiene la misma fecha desde que el proximo a ingresar.
            if (precioActual != null && precioActual.Desde.ToString("MM/dd/yyyy").Equals(DateTime.Now.ToString("MM/dd/yyyy")))
            {
                if (!dialog.ShowConfirmationDialog("Ya cambio el precio de este producto el dia de hoy, ¿desea reemplazarlo por el precio nuevo?"))
                {
                    Reset();
                    return false;
                }
                else
                {
                    return ModificarPrecioActual(precioNuevo);
                }
            }

            return InsertarPrecioHistorico(precioNuevo);
        }

        private bool InsertarPrecioHistorico(decimal precioNuevo)
        {
            //0. begin transaction
            //1. Se cierra el historico anterior con la fecha actual
            //2. Se inserta nuevo historico del producto seleccionado, con fecha hasta null
            //3. Se modifica el precio de producto en tabla productos
            //4. end transaction

            MySqlConnection connection = ConnecionBD.Instance().Connection;
            using (connection)
            {
                MySqlTransaction tran = null;
                try
                {
                    if (connection.State.Equals(ConnectionState.Closed))
                    {
                        connection.Open();
                    }

                    tran = connection.BeginTransaction();
                    QueryManager manager = QueryManager.Instance();                  
                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    if (!primerHistorico)
                    {
                        //1. Se cierra el historico anterior con la fecha actual
                        consulta = manager.ClosePrecioHistorico(precioActual.Id);
                        command.CommandText = consulta;
                        command.ExecuteNonQuery();
                    }

                    // segunda ejecucion             
                    //2. Se inserta nuevo historico del producto seleccionado, con fecha hasta null   
                    consulta = manager.CreateHistoricoNuevo(precioNuevo, idProducto);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    // tercera ejecucion
                    //3. Se modifica el precio de producto en tabla productos
                    consulta = manager.UpdateProductoPrecio(precioNuevo, idProducto);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    tran.Commit();
                    // Transaccion 
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    dialog.ShowErrorDialog("Error: " + e.Message);
                    if (tran == null)
                    {
                        return false;
                    }
                    tran.Rollback();
                    return false;
                }
            }
        }

        private bool ModificarPrecioActual(decimal precioNuevo)
        {
            // 0. modificar precio actual.
            // 1. modificar precio en productos.
            MySqlConnection connection = new MySqlConnection(ConnecionBD.Instance().connstring);
            using (connection)
            {
                MySqlTransaction tran = null;
                try
                {
                    if (connection.State.Equals(ConnectionState.Closed))
                    {
                        connection.Open();
                    }

                    tran = connection.BeginTransaction();

                    QueryManager manager = QueryManager.Instance();

                    // Transaccion - 
                    // primera ejecucion 
                    // 1 modificar precio actual.

                    string consulta = "";
                    MySqlCommand command = new MySqlCommand(consulta, connection, tran);

                    consulta = manager.UpdatePrecioHistorico(precioNuevo, idProducto);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    // tercera ejecucion
                    //2. Se modifica el precio de producto en tabla productos
                    consulta = manager.UpdateProductoPrecio(precioNuevo, idProducto);
                    command.CommandText = consulta;
                    command.ExecuteNonQuery();

                    tran.Commit();
                    // Transaccion 
                    return true;
                }
                catch (Exception e)
                {
                    FormMessageBox dialog = new FormMessageBox();
                    try
                    {
                        if (tran != null)
                            tran.Rollback();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        dialog.ShowErrorDialog(ioe.Message);
                    }
                    catch (MySqlException es)
                    {
                        dialog.ShowErrorDialog(es.Message);
                    }
                    return false;
                }
            }
        }

        private decimal GetPrecioNuevo()
        {
            decimal result = decimal.Zero;

            if (radioNuevoPrecio.Checked)
            {
                return decimal.Parse(textNuevoPrecio.Text);
            }
            else if (radioAumentarActual.Checked)
            {
                result = decimal.Parse(textAumentarActual.Text);
                return precioActual.Precio + result;                
            }

            return result; 
        }
   
        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Desea aplicar los cambios?"))
            {
                if (GuardarPrecioActual())
                {
                    FormMessageBox dialogConn = new FormMessageBox();
                    dialogConn.ShowConfirmationDialog("Se guardo precio correctamente. ");
                }
                Reset();
            }
        }

        private void Reset()
        {
            CargarDatos();
        }

        private void bDescartar_Click(object sender, EventArgs e)
        {
            FormMessageBox dialog = new FormMessageBox();
            if (dialog.ShowConfirmationDialog("¿Desea descartar los cambios?"))
            {
                Reset();
            }
        }

        private void textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionesGlobales.DecimalTextBox_KeyPress(sender, e);
        }

        private void textBoxPreCalculate_KeyUp(object sender, KeyEventArgs e)
        {
            if (radioAumentarActual.Checked)
            {
                if (textAumentarActual.Text.Equals("") || textAumentarActual.Text.Equals("0")){
                    labelAgregar.Visible = false;
                    return;
                }else
                {
                    labelAgregar.Visible = true;
                }
                
                decimal agregar = decimal.Parse(textAumentarActual.Text);
                labelAgregar.Text = "$" + (precioActual.Precio + agregar).ToString();
            }
        }

        private void textNuevoPrecio_Enter(object sender, EventArgs e)
        {
            radioNuevoPrecio.Checked = true;
            radioAumentarActual.Checked = false;
            RadioButtonsChanged();
        }

        private void textPorcen_Enter(object sender, EventArgs e)
        {
            radioNuevoPrecio.Checked = false;
            radioAumentarActual.Checked = false;
            RadioButtonsChanged();
        }

        private void textAumentarActual_Enter(object sender, EventArgs e)
        {
            radioNuevoPrecio.Checked = false;
            radioAumentarActual.Checked = true;
            RadioButtonsChanged();
        }
    }
}
