using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLaMejor.datamanager;
using AppLaMejor.formularios.Util;
using AppLaMejor.entidades;
using AppLaMejor.controlmanager;
using AppLaMejor.stylemanager;

namespace AppLaMejor.formularios
{
    public partial class FormClientes : Form
    {

        List<Cliente> listClients;
        DataTable tableClientes;
      
        public FormClientes()
        {
            InitializeComponent();
            CargarDataGrid();
            CargarFilterComboTipoCliente();

            ApplicationLookAndFeel.ApplyTheme(this.tsslMensaje);
            ApplicationLookAndFeel.ApplyThemeToAll(this);
        }

        private void CargarFilterComboTipoCliente()
        {
            // Ejemplo usar nomenclador para filtro
            TipoCliente tcvacio = new TipoCliente();
            tcvacio.Id = 0;
            tcvacio.Descripcion = "";
            List<TipoCliente> listTipoClientes = TiposManager.Instance().GetTipoClienteList();
            listTipoClientes.Add(tcvacio);
            listTipoClientes = listTipoClientes.OrderBy(x => x.Id).ToList();
            BindingList<TipoCliente> objects = new BindingList<TipoCliente>(listTipoClientes);

            comboTipoFilter.ValueMember = null;
            comboTipoFilter.DisplayMember = "Descripcion";
            comboTipoFilter.DataSource = objects;

            comboTipoFilter.SelectedIndex = -1;
        }        

        private void CargarDataGrid()
        {
            // Trae la tabla clientes en DataTable y la mapea a en List<Clientes>
            tableClientes = FuncionesClientes.fillClientes();
            listClients = FuncionesClientes.listClientes(tableClientes);
            ApplicationLookAndFeel.ApplyTheme(dataGridClientes);

            for (int j = 0; j < tableClientes.Rows.Count; j++)
            {
                for (int i = 0; i < tableClientes.Columns.Count; i++)
                {
                    // Sabemos que el nomenclador es ID Tipo Cliente
                    if (tableClientes.Columns[i].ColumnName.Equals("TipoCliente"))
                    {
                        tableClientes.Rows[j][i] = listClients[j].TipoCliente.Descripcion;
                    }
                }
            }          
            
            dataGridClientes.DataSource = tableClientes;
            dataGridClientes.AllowUserToAddRows = false;

            // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
            for (int i = 0; i < dataGridClientes.Columns.Count; i++)
            {
                dataGridClientes.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Hacemos que todas las columnas cambien su tamaño a lo ancho para que se vea toda la info
                string name = dataGridClientes.Columns[i].Name;
                if (name.ToUpper().Equals("ID") || name.ToUpper().Equals("USUARIO") || name.ToUpper().Equals("FECHABAJA"))
                {
                    dataGridClientes.Columns[i].Visible = false;
                    continue;
                }
            }

            
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            // Seteamos fecha baja en el registro por ID de Cliente
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected = listClients.First(s => s.Id == i);

            FormMessageBox dialog = new FormMessageBox();
			if (dialog.ShowConfirmationDialog("¿Eliminar registro del cliente " + clientSelected.RazonSocial + " ?")){
                    string consultaEliminar = QueryManager.Instance().GetDeleteClient(clientSelected.Id.ToString(), DateTime.Now);
                    if (QueryManager.Instance().ExecuteSQL(ConnecionBD.Instance().Connection, consultaEliminar))
                    {
                        MyTextTimer.TStartFade("Cliente eliminado correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                        CargarDataGrid();
                    }                   
				
			}
        }

        private void ModoEdicion(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected = listClients.First(s => s.Id == i);
            int idCliente = clientSelected.Id;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_EDITAR, formTittleText.Text);
            Boolean result = dialog.Execute(clientSelected, idCliente);

            if (result)
            {
                Cliente client = (Cliente)dialog.SelectedObject;
                /* Update en BD */

                if (FuncionesClientes.UpdateCliente(client))
                {
                    // se actualizo bien
                    CargarDataGrid();
                    MyTextTimer.TStartFade("Cliente actualizado correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }
                else
                {
                    // se actualizo mal
                    MyTextTimer.TStartFade("Cliente NO se actualizo correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }
                
            }
        }

        private void ModoVer(object sender, EventArgs e)
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected= listClients.First(s => s.Id == i);
            int idCliente = clientSelected.Id;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null,FormEntityInput.MODO_VER, formTittleText.Text);
            Boolean result = dialog.Execute(clientSelected, idCliente);
        }

        private void AgregarCliente()
        {
            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            Cliente newClient = new Cliente();
            newClient.FechaDesde = DateTime.Now;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_INSERTAR, formTittleText.Text);
            Boolean result = dialog.Execute(newClient);
            if (result)
            {
                newClient = (Cliente)dialog.SelectedObject;
                /* Insert en BD */

                if (FuncionesClientes.InsertCliente(newClient))
                {
                    CargarDataGrid();
                    MyTextTimer.TStartFade("Se guardo cliente " + newClient.RazonSocial.ToUpper() + ".", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);    
                }
                else
                {
                    MyTextTimer.TStartFade("No se guardo el cliente. Ocurrio un error.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }                    
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

        private void bEliminar_Click(object sender, EventArgs e)
        {
           EliminarRegistro(sender, e);
        }
        
        private void bAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }

        private void bVer_Click(object sender, EventArgs e)
        {
            ModoVer(sender, e);
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            ModoEdicion(sender, e);
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!filterTextBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(filterTextBox.Text)))
                {
                    filter.Append("RazonSocial Like '%" + filterTextBox.Text + "%'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void filterCodClienteTextBox_TextChanged(object sender, EventArgs e)
        {
            // Aplicar filtro a data grid por texto en Razon Social
            if (!filterTextBox.Text.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(filterTextBox.Text)))
                {
                    filter.Append("CodCliente Like '%" + filterTextBox.Text + "%'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }

        }
        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dtpFilter.Value.Date.ToString("yyyy-MM-dd");

             //Aplicar filtro a data grid por texto fecha en Razon Social
            if (!theDate.Equals(""))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(theDate)))
                {
                    filter.Append("FechaDesde = '" + theDate + "'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void comboTipoFilterOnChange(object sender, EventArgs e)
        {
            comboNomencladorFilterChange(sender);
        }

        private void comboNomencladorFilterChange(object sender)
        {
            ComboBox combo = (ComboBox)sender;
            TipoCliente tipoCliente = (TipoCliente)combo.SelectedValue;

            //Aplicar filtro a data grid por texto fecha en Razon Social
            if ( tipoCliente!=null && !string.IsNullOrEmpty(tipoCliente.Descripcion))
            {
                StringBuilder filter = new StringBuilder();
                if (!(string.IsNullOrEmpty(tipoCliente.Descripcion)))
                {
                    filter.Append("TipoCliente = '" + tipoCliente.Descripcion + "'");
                    (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = filter.ToString();
                }
            }
            else
            {
                (dataGridClientes.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void filterTextBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void bCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAgregarCuenta_Click(object sender, EventArgs e)
        {
            AgregarCuenta();
        }

        private void AgregarCuenta()
        {
            int i = FuncionesGlobales.obtenerIndexDeListFromGrid(dataGridClientes);
            Cliente clientSelected = listClients.First(s => s.Id == i);
            int idCliente = clientSelected.Id;

            /* Obtenemos los datos de la fila seleccionada y la convertimos a entidad Cliente */
            Cuenta newCuenta= new Cuenta();
            newCuenta.FechaUltimaActualizacion = DateTime.Now;

            /* Form Entity Input */
            FormEntityInput dialog = new FormEntityInput(null, FormEntityInput.MODO_INSERTAR, "Cuenta de cliente. ");
            Boolean result = dialog.Execute(newCuenta);
           
            if (result)
            {
                newCuenta = (Cuenta)dialog.SelectedObject;
                /* Insert en BD */

                if (FuncionesClientes.InsertCuenta(newCuenta,idCliente.ToString()))
                {
                    MyTextTimer.TStartFade("Cuenta se guardo correctamente", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);    
                }
                else
                {
                    MyTextTimer.TStartFade("No se guardo cuenta.", statusStrip1, tsslMensaje, MyTextTimer.TIME_SHORT);
                }

            }


        }



    }
}
